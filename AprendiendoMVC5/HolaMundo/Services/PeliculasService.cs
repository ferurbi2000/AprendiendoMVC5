using HolaMundo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HolaMundo.Services
{
    public class PeliculasService
    {
        public Pelicula ObtenerPelicula()
        {
            return new Pelicula()
            {
                Titulo = "Mi primer Libro",
                Duracion = 2,
                Pais = "Nicaragua",
                Publicacion = DateTime.Now
            };
        }
    }
}