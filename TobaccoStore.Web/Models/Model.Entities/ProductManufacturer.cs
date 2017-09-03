using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TobaccoStore.Web.Models
{
    [DataContract]
    public class ProductManufacturer
    {
        [DataMember]
        public int Id { get; set; }
        public string Name { get; set; }

        // navs
        public ICollection<ProductInfo> Products { get; set; }
    }
}