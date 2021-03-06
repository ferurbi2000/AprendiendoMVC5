﻿using HolaMundo.Models;
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

        public List<Pelicula> ObtenerPeliculas()
        {
            var pelicula1 = new Pelicula()
            {
                Titulo = "Mi primer Libro1",
                Duracion = 2,
                Pais = "USA",
                Publicacion = DateTime.Now,
                EstaEnCartelera = true
            };


            //Peligroso pasar scripts en los registros
            var pelicula2 = new Pelicula()
            {
                //Titulo = "<b>Mi primer Libro2</b><script>alert('hackeado')</script>",
                Titulo = "<b>Mi primer Libro2</b>",
                Duracion = 29,
                Pais = "UCRA",
                Publicacion = DateTime.Now,
                EstaEnCartelera=true
            };
            
            var pelicula3 = new Pelicula()
            {
                Titulo = "Mi primer Libro2",
                Duracion = 29,
                Pais = "UCRA",
                Publicacion = DateTime.Now,
                EstaEnCartelera=false
            };

            return new List<Pelicula> {
                pelicula1, pelicula2, pelicula3 
            };
        }
    }
}