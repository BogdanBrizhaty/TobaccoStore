using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TobaccoStore.Web.Models.Model.Entities
{
    [DataContract]
    public class PackageInfo : IDbEntity
    {
        [DataMember]
        [Key]
        public int Id { get; set; }
        [DataMember]
        public int Weight { get; set; }
        [DataMember]
        public decimal ListPrice { get; set; }

        [DataMember]
        [ForeignKey("ProductInfo")]
        public int ProductInfoId { get; set; }
        

        // nav
        public virtual ProductInfo ProductInfo { get; set; }
    }
}