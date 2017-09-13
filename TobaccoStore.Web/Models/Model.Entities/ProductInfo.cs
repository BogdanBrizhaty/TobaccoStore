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
    public class ProductInfo : IDbEntity
    {
        [DataMember]
        [Key]
        public int Id { get; set; }
        [DataMember]
        public byte[] Photo { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [IgnoreDataMember]
        public int Rating { get; set; }
        [IgnoreDataMember]
        public int Votes { get; set; }
        [DataMember]
        public bool IsAvailable { get; set; }
        //[IgnoreDataMember]
        //public byte Discount { get; set; } // from 0 to 100 !!! In percentage
        [DataMember]
        public int PackageWeight { get; set; } // IN GRAMS !!!
        [DataMember]
        public decimal Price { get; set; }

        [ForeignKey("Manufacturer")]
        [DataMember]
        public int Manufacturer_Id { get; set; }

        // nav props
        public virtual ProductManufacturer Manufacturer { get; set; }
    }
}