using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TobaccoStore.Web.Models.Model.Entities
{
    public interface IDbEntity
    {
        int Id { get; set; }
    }
}