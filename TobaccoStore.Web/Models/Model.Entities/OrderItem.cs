using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TobaccoStore.Web.Models
{
    [DataContract]
    public class OrderItem
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

        // nav prop-s
        public virtual ProductInfo Product { get; set; }
        public virtual OrderDetails Order { get; set; }
    }
}