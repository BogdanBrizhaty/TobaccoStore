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

            if (page * pageSize > totalItems)
                throw new Exception("Page number is too big");

            return new DataPortion<TobaccoInfo>(query.Skip(page * pageSize + 1).Take(pageSize), totalItems);
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
        public void Update(TobaccoInfo item)
        {
            _db.Entry(item).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }

    }
}