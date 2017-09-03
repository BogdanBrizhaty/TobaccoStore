using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TobaccoStore.Web.Models
{
    public class DiscountRepository : EfRepository<Discount, int>
    {
        public DiscountRepository() : base(ApplicationDbContext.GetInstance())
        {

        }
        public DataPortion<Discount> FindByProductName(string q, int page, int pageSize = 10, Ordering<Discount> ordering = null)
        {
            var keywords = q.Split(new char[] { ' ', '.', ',' }, StringSplitOptions.RemoveEmptyEntries);

            // test this
            var query = DataContext.Set<Discount>().Where(i => keywords.Any(kw => i.Product.Name.Contains(kw)));

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
            return new DataPortion<Discount>(resultationEntities, totalItems);
        }
    }
}