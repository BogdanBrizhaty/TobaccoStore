using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;

namespace TobaccoStore.Web.Models
{
    public class TobaccoRepository : EfRepository<ProductInfo, int>
    {
        public TobaccoRepository() : base(ApplicationDbContext.GetInstance())
        {

        }
        public DataPortion<ProductInfo> FindByName(string q, int page, int pageSize = 10, Ordering<ProductInfo> ordering = null)
        {
            var keywords = q.Split(new char[] { ' ', '.', ',' }, StringSplitOptions.RemoveEmptyEntries);

            // test this
            var query = DataContext.Set<ProductInfo>().Where(i => keywords.Any(kw => i.Name.Contains(kw)));

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
            var query = DataContext.Set<ProductInfo>().Where(p => p.Manufacturer_Id == id).OrderBy(p => p.Id);

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
    }
}