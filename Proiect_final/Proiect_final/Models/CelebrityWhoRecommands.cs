using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proiect_final.Models
{
    public class CelebrityWhoRecommands
    {
        [Key]
        public int CelebrityId { get; set; }
        public string Name { get; set; }
        // many-to-many relationship
        public virtual ICollection<Product> Products { get; set; }
    }
}