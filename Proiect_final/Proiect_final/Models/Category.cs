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
            MaxLength(100, ErrorMessage = "Category name cannot be more than 100")]
        public string Name { get; set; }
        
        [NotMapped]
        public DateTime LoadedFromDatabase { get; set; }

        public string Description { get; set; }
    }

    public class DbCtx : DbContext
    {
        public DbCtx() : base("DbConnectionString")
        {
            //set the initializer here
            Database.SetInitializer<DbCtx>(new Initp());
        }
        public DbSet<Category> Categories { get; set; }
    }

    public class Initp : DropCreateDatabaseAlways<DbCtx>
    {
        //custom initializer
        protected override void Seed (DbCtx ctx)
        {
            ctx.Categories.Add(new Category 
            { 
                Name = "Clothes",
                Description = "blabla"
            });
            ctx.Categories.Add(new Category 
            { 
                Name = "Shoes",
                Description = "blabla"
            });
            ctx.SaveChanges();
            base.Seed(ctx);
        }
    }
}