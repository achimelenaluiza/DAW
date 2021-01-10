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
        public int NumberOfPictures { get; set; }
        public string[] ImageUrls { get; set; }

        // one-to one-relationship
        [Required]
        public virtual Product Product { get; set; }
    }
}