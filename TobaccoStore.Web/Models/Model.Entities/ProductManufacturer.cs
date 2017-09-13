using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using TobaccoStore.Web.Models.Model.Entities;

namespace TobaccoStore.Web.Models
{
    [DataContract]
    public class ProductManufacturer : IDbEntity
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }

        // navs
        public ICollection<ProductInfo> Products { get; set; }
    }
}