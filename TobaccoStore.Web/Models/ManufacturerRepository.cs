using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TobaccoStore.Web.Models
{
    public class ManufacturerRepository : EfRepository<ProductManufacturer, int>
    {
        public ManufacturerRepository() : base(new ApplicationDbContext())
        {

        }
    }
}