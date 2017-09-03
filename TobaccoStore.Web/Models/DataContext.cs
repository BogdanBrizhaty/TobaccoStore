﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TobaccoStore.Web.Models
{
    public partial class ApplicationDbContext
    {
        public DbSet<ProductInfo> TobaccoProducts { get; set; }
        public DbSet<ProductManufacturer> Manufacturers { get; set; }
        public DbSet<OrderDetails> Orders { get; set; }
        public DbSet<Discount> Discounts { get; set; }
    }
}