using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2.Controllers
{
    public class ExercitiiController : Controller
    {
        // GET: Exercitii
        public ActionResult Index()
        {
            return View();
        }

        // Exercitiul 1:
        // https://localhost:44376/cautare/ex1/bunaziua/buna 

        public ContentResult CautareSubstring(string cuvant, string propozitie)
        {
            string mesaj = "Propozitia '" + propozitie + "' contine cuvantul '" + cuvant + "' !";
            string error1 = "Propozitia '" + propozitie + "'NU contine cuvantul '" + cuvant + "' !";
            string error2 = "Lipseste un parametru";

            if (propozitie != null && cuvant != null)
            {
                if (propozitie.Contains(cuvant))
                    return Content(mesaj);
                return Content(error1);
            }
            return Content(error2);
        }
        // Exercitiul 2:
        // https://localhost:44376/cautare/ex2/buna/sal
        public ActionResult CautareSubstringOptional(string cuvant, string? propozitie)
        {
            ViewBag.message = "Propozitia `" + propozitie + "` contine cuvantul `" + cuvant + "`";

            if (propozitie == null)
            {
                return HttpNotFound("Parametrul propozitie lipseste!");
            }
            if (!propozitie.Contains(cuvant))
            {
                ViewBag.message = "Propozitia `" + propozitie + "` NU contine cuvantul `" + cuvant + "`";
            }
            return View();
        }

        // Exercitiul 3:
        // https://localhost:44376/regex/ex3
        //[Route("Exercises/Ex3/{numar:regex(^\\d{2,6}[02468]$)}")]
        public string ParsareRegex(int? numar)
        {
            return "Numarul introdus este " + numar.ToString();
        }
    }
    
}