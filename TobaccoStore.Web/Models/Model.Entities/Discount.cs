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
    public class Discount
    {
        [DataMember]
        [Key]
        public int Id { get; set; }
        [DataMember]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [DataMember]
        public int Amount { get; set; }
        [DataMember]
        public decimal Cashback { get; set; }
        // nav prop-s
        public virtual ProductInfo Product { get; set; }
    }
}