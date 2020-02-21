using HolaMundo.Models;
using HolaMundo.Services;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public HttpStatusCodeResult Error()
        {
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound, "Hola");
            //return View();
        }

        public FileResult Descargar()
        {
            var ruta = Server.MapPath("El lenguaje de programación C#.pdf");
            return File(ruta, "application/pdf", "ApendiendoC#.pdf");
        }

        public RedirectToRouteResult IrUrl()
        {
            //return Redirect("https://www.google.com");
            return RedirectToAction("Personas", "Home");

        }

        public ActionResult UsoViewBag()
        {
            ViewBag.miMensaje = "Nuevo Mensaje usando ViewBag";
            ViewData["Mensaje"] = "Mensaje con ViewData";
            ViewData["Fecha"] = DateTime.Now.ToString();
            return View();
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

            return Json(new List<Persona> { persona1, persona2, persona3, persona4, persona5 }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Peliculas(string titulo)
        {
            ViewBag.Titulo = titulo;
            var peliculasService = new PeliculasService();
            var peliculas = peliculasService.ObtenerPeliculas();

            return View(peliculas);
        }
        public ContentResult Test()
        {
            return Content("<b>Fernando</b><h1>TEST</h1>");
            //return View();
        }

        [ChildActionOnly] //Este atributo define que esta accion solamente se va ejecutar dentro de una vista
        public ActionResult Info(string nombres)
        {
            ViewBag.nombre = nombres;
            return View();
        }

        public ActionResult Display()
        {
            var pelicula = new Pelicula { Titulo = "Nuevo Libro", Duracion = 32, Pais = "Nicaragua", EstaEnCartelera = true, Publicacion = DateTime.Now };
            ViewBag.Pelicula = pelicula;

            return View();
        }


        //Funcion que permite usar reflexion para recorrer genericos tipo SelectListItem
        //Permite utilizar el atributo descripcion de una lista Enum y utilizarlo como la descripcion del elemento
        private List<SelectListItem> ToListSelectItem<T>()
        {
            var t = typeof(T);

            if (!t.IsEnum) { throw new ApplicationException("Tipo debe ser enum"); }

            var members = t.GetFields(BindingFlags.Public | BindingFlags.Static);

            var result = new List<SelectListItem>();

            foreach (var member in members)
            {
                var attributeDescription = member.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
                var descripcion = member.Name;

                if (attributeDescription.Any())
                {
                    descripcion = ((System.ComponentModel.DescriptionAttribute)attributeDescription[0]).Description;
                }

                var valor = ((int)Enum.Parse(t, member.Name));
                result.Add(new SelectListItem()
                {
                    Text = descripcion,
                    Value =valor.ToString()
                });
            }
            return result;
        }

        public ActionResult DropDownList()
        {
            var listado = new List<SelectListItem>() {
                new SelectListItem()
                {
                    Text="Si",
                    Value="1"
                },
                new SelectListItem()
                {
                    Text="No",
                    Value="2",
                    Disabled=true
                },
                new SelectListItem()
                {
                    Text="Quizas",
                    Value="3"
                }
            };

            ViewBag.miListado = listado;
            ViewBag.miListadoEnum = ToListSelectItem<ResultadoOperacion>();
            return View();
        }

        
        public ActionResult Formulario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Formulario(Pelicula pelicula)
        {
            ViewBag.Mensaje = "Exitoso";
            return View(pelicula);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";


            return View();
        }


        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(string nombre, int edad)
        {
            ViewBag.Message = "Your contact page." + nombre + edad.ToString();

            return View();
        }

        public ActionResult Map()
        {
            ViewBag.Message = "Mi Mapa";

            return View();
        }
    }
}