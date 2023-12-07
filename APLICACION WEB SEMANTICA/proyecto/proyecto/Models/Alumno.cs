using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto.Models
{
    public class Alumno 
    {
        public List<Instituto> Instituto { get; set; }
        public string NumIdentificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Edad { get; set; }
        public string Sexo { get; set; }
    }
}