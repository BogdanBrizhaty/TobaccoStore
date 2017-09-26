using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TobaccoStore.Web.Models
{
    public class OrderRepository : EfRepository<OrderDetails, int>
    {
        public OrderRepository() : base(ApplicationDbContext.GetInstance())
        {

        }
        public DataPortion<OrderDetails> GetByCustomerName(string name, int page, int pageSize, Ordering<OrderDetails> ordering = null)
        {
            var query = DataContext.Set<OrderDetails>().Where(o => o.FullName.Contains(name));

            query = (ordering == null)
                ? DataContext.Set<OrderDetails>().Include("Cart")
                : ordering.Apply(DataContext.Set<OrderDetails>().Include("Cart"));

            var totalItemsInTable = query.Count();

            if ((page - 1) * pageSize > totalItemsInTable)
                throw new ArgumentOutOfRangeException("Attempt to access elements outside of " + typeof(OrderDetails) + " table bounds in the database");

            var resultationEntities = (page == 1) ? query.Take(pageSize) : query.Skip((page - 1) * pageSize).Take(pageSize);

            return new DataPortion<OrderDetails>(resultationEntities, totalItemsInTable);
        }
        public override DataPortion<OrderDetails> GetMany(int page, int pageSize = 10, Ordering<OrderDetails> order = null)
        {
            // IQueriable<TEntity> goes here
            var query = (order == null)
                ? DataContext.Set<OrderDetails>().Include("Cart")
                : order.Apply(DataContext.Set<OrderDetails>().Include("Cart"));

            var totalItemsInTable = query.Count();

            if ((page - 1) * pageSize > totalItemsInTable)
                throw new ArgumentOutOfRangeException("Attempt to access elements outside of " + typeof(OrderDetails) + " table bounds in the database");

            var resultationEntities = (page == 1) ? query.Take(pageSize) : query.Skip((page - 1) * pageSize).Take(pageSize);

            return new DataPortion<OrderDetails>(resultationEntities, totalItemsInTable);
        }
    }
}