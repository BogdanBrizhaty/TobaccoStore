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
    }
    public class TobaccoRepository2
    {
        private readonly ApplicationDbContext _db = null;
        public TobaccoRepository2(ApplicationDbContext context)
        {
            _db = context;
        }
        public TobaccoRepository2() : this(ApplicationDbContext.GetInstance())
        {

        }
        public DataPortion<ProductInfo> GetMany(int page, int pageSize = 10, Ordering<ProductInfo> ordering = null)
        {
            var query = (ordering == null)
                ? _db.TobaccoProducts
                : ordering.Apply(_db.TobaccoProducts);

            var totalItems = query.Count();

            if (page * pageSize > totalItems && page != 1)
                throw new Exception("Page number is too big");

            var resultationEntities = (page == 1) 
                ? query.Take(pageSize) 
                : query.Skip((page - 1) * pageSize).Take(pageSize);

            return new DataPortion<ProductInfo>(resultationEntities, totalItems);
        }
        public ProductInfo GetById(int id)
        {
            var result = _db.TobaccoProducts.Find(id);
            //var result = _db.TobaccoProducts.Where(p => p.Id == id).FirstOrDefault();

            if (result == null)
                throw new Exception("Object not found");

            return result;
        }
        public void Add(ProductInfo product)
        {
            _db.TobaccoProducts.Add(product);
            _db.SaveChanges();
        }
        public void Delete(int id)
        {
            var item = _db.TobaccoProducts.Find(id);
            _db.TobaccoProducts.Remove(item);
            _db.SaveChanges();
        }
        public void Delete(ProductInfo item)
        {
            _db.TobaccoProducts.Remove(item);
            _db.SaveChanges();
        }
        public bool Exists(ProductInfo item)
        {
            return _db.TobaccoProducts.Any(t => t.Id == item.Id);// (_db.TobaccoProducts.Find(item) == null) ? false : true;
        }
        public void Update(ProductInfo item)
        {
            _db.TobaccoProducts.Attach(item);
            _db.Entry(item).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }
        public DataPortion<ProductInfo> FindByName(string q, int page, int pageSize = 10, Ordering<ProductInfo> ordering = null)
        {
            var keywords = q.Split(new char[] { ' ', '.', ',' }, StringSplitOptions.RemoveEmptyEntries);

            var result = new List<ProductInfo>();

            // test this
            var query = _db.TobaccoProducts.Where(i => keywords.Any(kw => i.Name.Contains(kw)));

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

    }
}