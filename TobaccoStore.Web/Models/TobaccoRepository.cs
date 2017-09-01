using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;

namespace TobaccoStore.Web.Models
{
    public class TobaccoRepository
    {
        private readonly ApplicationDbContext _db = null;
        public TobaccoRepository(ApplicationDbContext context)
        {
            _db = context;
        }
        public TobaccoRepository() : this(ApplicationDbContext.GetInstance())
        {

        }
        public DataPortion<TobaccoInfo> GetMany(int page, int pageSize = 10, Ordering<TobaccoInfo> ordering = null)
        {
            var query = (ordering == null)
                ? _db.TobaccoProducts
                : ordering.Apply(_db.TobaccoProducts);

            var totalItems = query.Count();

            //if (totalItems <= pageSize)

            if (page * pageSize > totalItems && page != 1)
                throw new Exception("Page number is too big");

            var resultationEntities = (page == 1) 
                ? query.Take(pageSize) 
                : query.Skip((page - 1) * pageSize).Take(pageSize);

            return new DataPortion<TobaccoInfo>(resultationEntities, totalItems);
        }
        public TobaccoInfo GetById(int id)
        {
            var result = _db.TobaccoProducts.Find(id);
            //var result = _db.TobaccoProducts.Where(p => p.Id == id).FirstOrDefault();

            if (result == null)
                throw new Exception("Object not found");

            return result;
        }
        public void Add(TobaccoInfo product)
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
        public void Delete(TobaccoInfo item)
        {
            _db.TobaccoProducts.Remove(item);
            _db.SaveChanges();
        }
        public bool Exists(TobaccoInfo item)
        {
            return _db.TobaccoProducts.Any(t => t.Id == item.Id);// (_db.TobaccoProducts.Find(item) == null) ? false : true;
        }
        public void Update(TobaccoInfo item)
        {
            _db.TobaccoProducts.Attach(item);
            _db.Entry(item).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }

    }
}