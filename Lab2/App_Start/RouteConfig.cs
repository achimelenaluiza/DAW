using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Lab2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "RegexNumerePare",
                url: "regex/ex3/{numar}",
                defaults: new { controller = "Exercitii", action = "ParsareRegex", numar = UrlParameter.Optional },
                constraints: new { numar = @"^\d{2,6}[02468]$" }
                // orice numar par cu lungime de 3-7 cifre (regex)
            );

            routes.MapRoute(
                name: "ContineCuvantOptional",
                url: "cautare/ex2/{cuvant}/{propozitie}",
                defaults: new { controller = "Exercitii", action = "CautareSubstringOptional", cuvant = UrlParameter.Optional, propozitie = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Contine Cuvant",
                url: "cautare/ex1/{propozitie}/{cuvant}",
                defaults: new { controller = "Exercitii", action = "CautareSubstring", propozitie = UrlParameter.Optional, cuvant = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }

    }
}
