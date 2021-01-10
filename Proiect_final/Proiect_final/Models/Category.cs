using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.SqlServer.Server;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Proiect_final.Models
{
    public class Category
    {
        [Key, Column("Category_id")]
        public int CategoryId { get; set; }

        [MinLength(5, ErrorMessage = "Category name cannot be less than 5"),
            MaxLength(20, ErrorMessage = "Category name cannot be more than 20")]
        public string Name { get; set; }

        // many-to-one relationship         
        public virtual ICollection<Product> Products { get; set; }
    }
}