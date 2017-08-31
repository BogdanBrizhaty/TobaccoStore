using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TobaccoStore.Web.Models
{
    [DataContract]
    public class ProductInfo
    {
        [DataMember]
        public int Id { get; set; }
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
        [IgnoreDataMember]
        public byte Discount { get; set; } // from 0 to 100 !!!
    }
}