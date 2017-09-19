using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using TobaccoStore.Web.Models.Model.Entities;

namespace TobaccoStore.Web.Models
{
    [DataContract]
    public class OrderItem : IDbEntity
    {
        [DataMember]
        [Key]
        public int Id { get; set; }
        [DataMember]
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        [ForeignKey("Product")]
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public int Amount { get; set; } // ??
        [DataMember]
        public int ListPrice { get; set; }
        [DataMember]
        public int PackageWeight { get; set; }
        //[DataMember]
        //[ForeignKey("PackageInfo")]
        //public int PackgeInfoId { get; set; }

        // nav prop-s
        public virtual ProductInfo Product { get; set; }
        public virtual OrderDetails Order { get; set; }
        //public virtual PackageInfo PackageInfo { get; set; }
    }
}