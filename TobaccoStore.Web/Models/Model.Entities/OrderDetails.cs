using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using TobaccoStore.Web.Models.Model.Entities;

namespace TobaccoStore.Web.Models
{
    [DataContract]
    public class OrderDetails : IDbEntity
    {
        [DataMember]
        [Key]
        public int Id { get; set; }
        [DataMember]
        public DateTime DateTime { get; set; }
        [DataMember]
        public string FullName { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string PatronymicName { get; set; }
        [DataMember]
        public string DelieveryAddress { get; set; }
        [DataMember]
        public decimal Cost { get; set; }
        [DataMember]
        public string MobilePhone { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public decimal Discount { get; set; } // calculates on product discounts
        [DataMember]
        public string UserAccessToken { get; set; }
        // displays if user has access to view its
        [DataMember]
        public bool UserAccessPermition { get; set; }

        [DataMember]
        public ICollection<OrderItem> Cart { get; set; }
    }
}