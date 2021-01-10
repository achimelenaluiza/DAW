using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Proiect_final.Models
{
    public class Product
    {
        [Key, Column("Product_id")]
        public int ProductId { get; set; }

        [MinLength(5, ErrorMessage = "Product name cannot be less than 5"),
            MaxLength(50, ErrorMessage = "Product name cannot be more than 50")]
        public string Name { get; set; }
        
        public string Description { get; set; }

        public double Price { get; set; }

        // one to many
        [Column("Category_id")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        //many to many
        public virtual ICollection<CelebrityWhoRecommands> CelebritiesWhoRecommand { get; set; }

        //one to one
        public virtual Gallery Gallery { get; set; }
    }

    public class DbCtx : DbContext
    {
        public DbCtx() : base("DbConnectionString")
        {
            //set the initializer here
            Database.SetInitializer<DbCtx>(new Initp());
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CelebrityWhoRecommands> CelebrityWhoRecommands { get; set; }
    }

    public class Initp : DropCreateDatabaseAlways<DbCtx>
    {
        //custom initializer
        protected override void Seed(DbCtx ctx)
        {
            ctx.Products.Add(new Product
            {
               Name = "Little Black Dress",
               Price = 105.50,
               Description = "blabla",
               Category = new Category 
               {
                   Name = "Clothes"
               },
               CelebritiesWhoRecommand = new List<CelebrityWhoRecommands>
               {
                   new CelebrityWhoRecommands 
                   {
                       Name = "Rihanna",
                       Testimonial = new Testimonial
                       {
                           Comment = "My favourite dress of all times!"
                       }
                   }
               },
               Gallery = new Gallery
               {
                   NumberOfPictures = 3,
                   ImageUrls = new string[] { "~/Content/blue-shopping-bag-md.png", "~/Content/blue-shopping-bag-md.png", "~/Content/blue-shopping-bag-md.png" }
               }
            });
            
            ctx.SaveChanges();
            base.Seed(ctx);
        }
    }
}