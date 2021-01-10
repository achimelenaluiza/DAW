using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Proiect_final.Models
{
    public class Gallery
    {
        [Key, Column("Gallery_id")]
        public int GalleryId { get; set; }
        public string ImageUrl1 { get; set; }
        public string ImageUrl2 { get; set; }
        public string ImageUrl3 { get; set; }



        // one-to one-relationship
        [Required]
        public virtual Product Product { get; set; }
    }
}