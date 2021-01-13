using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proiect_final.CustomValidations;

namespace Proiect_final.Models
{
    public class Product
    {
        [Key, Column("Product_id")]
        public int ProductId { get; set; }

        [MinLength(5, ErrorMessage = "Product name cannot be less than 5"),
            MaxLength(50, ErrorMessage = "Product name cannot be more than 50")]
        public string Name { get; set; }

        [MinLength(20, ErrorMessage = "Product description cannot be less than 20")]
        public string Description { get; set; }

        [Range(1,1000)]
        public double Price { get; set; }

        [LinkOnly(ErrorMessage = "Link must be secured! https://")]
        public string ShopLink { get; set; }

        // one to many
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        //many to many
        public virtual ICollection<CelebrityWhoRecommands> CelebritiesWhoRecommand { get; set; }

        //one to one
        public virtual Gallery Gallery { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
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

        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
    }

    public class Initp : DropCreateDatabaseAlways<DbCtx>
    {
        //custom initializer
        protected override void Seed(DbCtx ctx)
        {
            Category clothes = new Category { CategoryId = 1, Name = "Clothes" };
            Category shoes = new Category { CategoryId = 2, Name = "Shoes" };

            ctx.Categories.Add(clothes);
            ctx.Categories.Add(shoes);

            ctx.Products.Add(new Product
            {
               Name = "Little Black Dress",
               Price = 54.00,
               ShopLink = "https://www.asos.com/us/asos-design/asos-design-cami-mini-slip-dress-in-high-shine-satin-with-lace-up-back/prd/20041579?affid=14309&channelref=product+search&mk=abc&ppcadref=291849059|1262239970495202|pla-4582489599544111&gclid=e54dfe318661190e5db5a1cda8618c33&gclsrc=3p.ds&msclkid=e54dfe318661190e5db5a1cda8618c33",
               Description = "If you've been on the hunt for the perfect little black dress—you know, " +
               "the one that you can wear out at night and during the daytime—Hailey Baldwin has you covered. The simple LBD she wore to Drake's " +
               "birthday bash can easily be dressed up for an evening on the town or dressed down with sneakers for a casual day of shopping. And if " +
               "you're not quite convinced yet that its versatile nature is reason enough to buy it, just take a look at its price tag. At $54, this" +
               " little black dress from Aussie brand Meshki is a steal.",
               CategoryId = clothes.CategoryId,
               CelebritiesWhoRecommand = new List<CelebrityWhoRecommands>
               {
                   new CelebrityWhoRecommands 
                   {
                       Name = "Hailey Baldwin (now Bieber)",
                       Testimonial = new Testimonial
                       {
                           Comment = "My favourite dress of all times!"
                       }
                   }
               },
               Gallery = new Gallery
               {
                   ImageUrl1 = "~/Content/Images/prod11.jpg",
                   ImageUrl2 = "~/Content/Images/prod12.jpg",
                   ImageUrl3 = "~/Content/Images/prod13.jpg"
               }
            });

            ctx.Products.Add(new Product
            {
                Name = "Red YSL Pants",
                Price = 105.50,
                ShopLink = "https://www.mytheresa.com/en-de/saint-laurent-high-rise-corduroy-flared-pants-1585903.html?utm_source=affiliate&utm_medium=affiliate.cj.int&cjevent=4410c19d53ff11eb817902cc0a180512",
                Description = " This week, in New York, Victoria Beckham showed that these 'hated' red trousers can look high fashion by wearing a pair of suit trousers from her" +
                              "own collection with a colourful striped knit and a matching red bag. VB stuck to her signature trouser silhouette, " +
                              "opting for high - waisted, wide - leg trousers that cover her shoes.However, if you're more into a cropped silhouette, we have found the perfect pair at Topshop.",
                CategoryId = clothes.CategoryId,
                CelebritiesWhoRecommand = new List<CelebrityWhoRecommands>
               {
                   new CelebrityWhoRecommands
                   {
                       Name = "Victoria Beckham",
                       Testimonial = new Testimonial
                       {
                           Comment = "Any woman can wear it, every woman should! Simple as that!"
                       }
                   }
               },
                Gallery = new Gallery
                {
                    ImageUrl1 = "~/Content/Images/prod21.jpg",
                    ImageUrl2 = "~/Content/Images/prod22.jpg",
                    ImageUrl3 = "~/Content/Images/prod23.jpg"
                }
            });

            ctx.Products.Add(new Product
            {
                Name = "Over the Knee animal print Heeled Boots",
                Price = 405.50,
                ShopLink = "https://www.dillards.com/p/antonio-melani-hendri-leopard-print-haircalf-tall-shaft-boots/511498867?cm_mmc=Yahoo_BingPAs-_-Category+-+Womens+Boots+-+Shopping-_-o-_-53d6d871d66f100fcce4878de6a58083&msclkid=53d6d871d66f100fcce4878de6a58083&utm_source=bing&utm_medium=cpc&utm_campaign=Category%20-%20Womens%20Boots%20-%20Shopping&utm_term=4580702889677753&utm_content=All%20Womens%20Boots",
                Description = "Saweetie was feeling catty on Saturday, wearing Christian Louboutin thigh high leopard print boots as she stepped out for a date night with beau Quavo." +
                              "The “Icy Girl” rapper let the boots,which feature silver spikes cascading down the front," +
                              "be the statement of her ensemble as she paired the bold choice with a simple black turtleneck and gray denim. "+
                              "While animal print designs are a trend that will obviously never go away, leopard, zebra and snakeskin patterns were seen on the fall / winter 2020 runways of Miu Miu, Rochas," +
                              "Versace and more.Saweetie sported tiger print boots when she appeared in the music video for the remix of Mulatto’s song “B * tch from Da Souf,” which was released in March.",
                CategoryId = shoes.CategoryId,
                CelebritiesWhoRecommand = new List<CelebrityWhoRecommands>
               {
                   new CelebrityWhoRecommands
                   {
                       Name = "Saweetie",
                       Testimonial = new Testimonial
                       {
                           Comment = "I believe these are my signature boots and they represent all of me!"
                       }
                   }
               },
                Gallery = new Gallery
                {
                    ImageUrl1 = "~/Content/Images/prod31.jpg",
                    ImageUrl2 = "~/Content/Images/prod32.png",
                    ImageUrl3 = "~/Content/Images/prod33.jpg"
                }
            });

            ctx.Products.Add(new Product
            {
                Name = "Air Jordan 1 retro high",
                Price = 105.50,
                ShopLink = "https://stockx.com/air-jordan-1-retro-high-travis-scott",
                Description = "Travis Scott’s Nike collaborations have become so enormously popular that selling them is hazardous to stores. " +
                "I’m not kidding! For his latest sneaker, a take on the iconic Nike Dunk, Scott gave local skate shops first dibs on sales. This would seem to be a golden" +
                " opportunity: all of Scott’s collaborative shoes attract a massive amount of attention and sell out instantly.",
                CategoryId = shoes.CategoryId,
                CelebritiesWhoRecommand = new List<CelebrityWhoRecommands>
               {
                   new CelebrityWhoRecommands
                   {
                       Name = "Travis Scott",
                       Testimonial = new Testimonial
                       {
                           Comment = "The perfect storm, handpicked by me."
                       }
                   },
                   new CelebrityWhoRecommands
                   {
                       Name = "Wu",
                       Testimonial = new Testimonial
                       {
                           Comment = "This design language, his love for sneakers, his fashion choice and his character are what makes his sneakers special"
                       }
                   }
               },
                Gallery = new Gallery
                {
                    ImageUrl1 = "~/Content/Images/prod41.png",
                    ImageUrl2 = "~/Content/Images/prod42.png",
                    ImageUrl3 = "~/Content/Images/prod43.png"
                }
            });

            ctx.SaveChanges();
            base.Seed(ctx);
        }
    }
}