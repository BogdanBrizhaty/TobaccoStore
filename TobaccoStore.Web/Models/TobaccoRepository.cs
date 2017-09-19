using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using TobaccoStore.Web.Models.Model.Entities;

namespace TobaccoStore.Web.Models
{
    public class TobaccoRepository : EfRepository<ProductInfo, int>
    {
        public int PackageInfoe { get; private set; }

        public TobaccoRepository() : base(ApplicationDbContext.GetInstance())
        {

        }
        public DataPortion<ProductInfo> FindByName(string q, int page, int pageSize = 10, Ordering<ProductInfo> ordering = null)
        {
            var keywords = q.Split(new char[] { ' ', '.', ',' }, StringSplitOptions.RemoveEmptyEntries);

            // test this
            var query = DataContext.Set<ProductInfo>().Include("PackageInfoes").Where(i => keywords.Any(kw => i.Name.Contains(kw)));

            //skip take
            if (ordering != null)
                query = ordering.Apply(query);

            var totalItems = query.Count();

            if (page * pageSize > totalItems && page != 1)
                throw new Exception("Page number is too big");

            var resultationEntities = (page == 1)
                ? query.Take(pageSize)
                : query.Skip((page - 1) * pageSize).Take(pageSize);
            // temporarily
            return new DataPortion<ProductInfo>(resultationEntities, totalItems);
        }
        public DataPortion<ProductInfo> FilterByManufacturer(int id, int page, int pageSize = 10, Ordering<ProductInfo> ordering = null)
        {
            var query = DataContext.Set<ProductInfo>()
                .Include("PackageInfoes")
                .Where(p => p.Manufacturer_Id == id)
                .OrderBy(p => p.Id);

            if (ordering != null)
                query = ordering.Apply(query);

            var totalItems = query.Count();

            if ((page - 1) * pageSize > totalItems && page != 1)
                throw new Exception("Page number is too big");

            var resultationEntities = (page == 1)
                ? query.Take(pageSize)
                : query.Skip((page - 1) * pageSize).Take(pageSize);
            // temporarily
            return new DataPortion<ProductInfo>(resultationEntities, totalItems);
        }

        public override void Update(ProductInfo item)
        {
            //DataContext.Set<TEntity>().Attach(item);
            var dbItem = DataContext.Set<ProductInfo>().Include("PackageInfoes").Where( p => p.Id == item.Id).FirstOrDefault();
            //.Find(item.Id);               //var dbPackageInfoes = DataContext.Set<PackageInfo>().Where(p => p.ProductInfoId == )

            //IEnumerable<PackageInfo> dbPackageInfoes = DataContext.Set<PackageInfo>().Where(p => p.ProductInfoId == item.Id).ToList();

            if (dbItem == null)
                return;

            DataContext.Entry(dbItem).CurrentValues.SetValues(item);
            //DataContext.Entry(dbPackageInfoes).CurrentValues.SetValues(dbPackageInfoes);
            foreach(var packageInfo in dbItem.PackageInfoes)
                if (!item.PackageInfoes.Any(e => e.Id == packageInfo.Id))
                    DataContext.Set<PackageInfo>().Remove(packageInfo);

            foreach(var packageInfo in item.PackageInfoes)
            {
                var dbEntry = dbItem.PackageInfoes.SingleOrDefault(e => e.Id == packageInfo.Id);
                if (dbEntry != null)
                    DataContext.Entry(dbEntry).CurrentValues.SetValues(packageInfo);
                else
                    DataContext.Set<PackageInfo>().Add(packageInfo);
            }

            DataContext.Entry(dbItem).State = EntityState.Modified;
            DataContext.SaveChanges();
        }
    }
}