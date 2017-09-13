using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TobaccoStore.Web.Models.Model.Entities;

namespace TobaccoStore.Web.Models
{
    /// <summary>
    /// Abstract EF repository class. supports inheritance
    /// </summary>

    public class EfRepository<TEntity, TKey> where TEntity : class, IDbEntity// : IRepository<TEntity, TKey> where TEntity : class, IDbEntity
    {
        // dbcontext placeholder, DbContext property backing field
        private readonly DbContext _dataContext = null;

        // ctor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">DataBase context</param>
        /// <exception cref="ArgumentNullException">passing nullable dbcontext parameter to the contstructor</exception>
        public EfRepository(DbContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            _dataContext = context;
        }

        // DbContext accessor. Is protected to allow inherited repositories access dbcontext
        protected DbContext DataContext
        {
            get { return _dataContext; }
        }

        // Repository interface implementation
        public virtual DataPortion<TEntity> GetMany(int page, int pageSize = 10, Ordering<TEntity> order = null)
        {
            // IQueriable<TEntity> goes here
            var query = (order == null)
                ? DataContext.Set<TEntity>()
                : order.Apply(DataContext.Set<TEntity>());

            var totalItemsInTable = query.Count();

            if ((page - 1) * pageSize > totalItemsInTable)
                throw new ArgumentOutOfRangeException("Attempt to access elements outside of " + typeof(TEntity) + " table bounds in the database");

            var resultationEntities = (page == 1) ? query.Take(pageSize) : query.Skip((page - 1) * pageSize).Take(pageSize);

            return new DataPortion<TEntity>(/*new List<TEntity>()*/resultationEntities, totalItemsInTable);
        }
        public virtual void Add(TEntity item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            DataContext.Set<TEntity>().Add(item);
            DataContext.SaveChanges();
        }

        public virtual void Delete(TEntity item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            DataContext.Set<TEntity>().Remove(item);
            DataContext.Entry(item).State = EntityState.Deleted;
            DataContext.SaveChanges();
        }

        public virtual TEntity GetById(TKey id)
        {
            var resultationEntity = DataContext.Set<TEntity>().Find(id);

            if (resultationEntity == null)
                throw new KeyNotFoundException("No entity with such key was not found");

            return resultationEntity;
        }

        public virtual void Update(TEntity item)
        {
            //DataContext.Set<TEntity>().Attach(item);
            var dbItem = DataContext.Set<TEntity>().Find(item.Id);

            if (dbItem == null)
                return;

            DataContext.Entry(dbItem).CurrentValues.SetValues(item);

            DataContext.Entry(dbItem).State = EntityState.Modified;
            DataContext.SaveChanges();
        }
        public virtual bool Exists(TKey id)
        {
            return (DataContext.Set<TEntity>().Find(id) == null)
                ? false
                : true;
        }
        public virtual bool Exists(TEntity item)
        {
            return DataContext.Set<TEntity>().Local.Any(e => e == item);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    //_dataContext.Dispose();
                }

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}