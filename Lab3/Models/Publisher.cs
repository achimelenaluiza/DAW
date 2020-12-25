using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3.Models
{
    public class Publisher
    {
        public int PublisherId { get; set; }
        public string Name { get; set; }

        // one to many
        public virtual ICollection<Book> Books { get; set; }

        // one to one 
        public virtual ContactInfo ContactInfo { get; set; }
    }
}