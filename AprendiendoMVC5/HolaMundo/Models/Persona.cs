using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HolaMundo.Models
{
    public class Persona
    {
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public bool EsMayor { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}