using HolaMundo.Models;
using HolaMundo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HolaMundo.Controllers
{

    public class Persona
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var peliculaService = new PeliculasService();
            var model = peliculaService.ObtenerPeliculas();

            return View(model);
        }

        public RedirectToRouteResult IrUrl()
        {
            //return Redirect("https://www.google.com");
            return RedirectToAction("Personas", "Home");

        }

        public ActionResult IrOtro()
        {
            return RedirectToRoute("Test");
        }

        public ActionResult Personas()
        {
            var persona1 = new Persona { Name = "Fernando Urbina", Age = 42 };
            var persona2 = new Persona { Name = "Heydi Lanzas", Age = 39 };
            var persona3 = new Persona { Name = "Fernando Urbina", Age = 42 };
            var persona4 = new Persona { Name = "Heydi Lanzas", Age = 39 };
            var persona5 = new Persona { Name = "Maria Fernando", Age = 17 };

            return Json(new List<Persona> { persona1, persona2, persona3, persona4, persona5}, JsonRequestBehavior.AllowGet);
        }

        public ContentResult Test()
        {
            return Content("<b>Fernando</b><h1>TEST</h1>");
            //return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Map()
        {
            ViewBag.Message = "Mi Mapa";

            return View();
        }
    }
}