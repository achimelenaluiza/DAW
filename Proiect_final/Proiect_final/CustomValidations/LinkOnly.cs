using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proiect_final.CustomValidations
{
    public class LinkOnly : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string link = value.ToString();

            return link.ToLower().Contains("https:");
        }
    }
}