using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proiect_final.Models
{
    public class Testimonial
    {
        [Key] 
        public int TestimonialId { get; set; }
        public string Comment { get; set; }

        // one-to one-relationship
        [Required]
        public virtual CelebrityWhoRecommands CelebrityWhoRecommands { get; set; }
    }
}