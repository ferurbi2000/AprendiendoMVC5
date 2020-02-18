using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace HolaMundo.Models
{
    public enum ResultadoOperacion
    {
        Aprobado = 1,
        Rechazado = 2,
        Pendiente = 3,        
        [Description("Pendiente Aprobacion")]
        PendienteAprobacion = 4
    }
}