using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proiect.Models
{
    public class IdentityHelper
    {
        internal static void SeedIdentities(ApplicationDbContext ctx)
        {
            ctx.Books.Add(new Book
            {
                Title = "The Canterbury Tales",
                Author = "Geoffrey Chaucer"
            });
            ctx.SaveChanges();
        }
    }
}