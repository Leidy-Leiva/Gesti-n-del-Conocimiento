using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto.Models
{
    public class Instituto
    {
        public List<Categoria> Categoria { get; set; }
        public List<Estilo> Estilo { get; set; }
        public List<Metodos> Metodos { get; set; }
        public List<Niveles> Niveles { get; set; }
        public List<Alumno> Alumno { get; set; }
        public List<Maestro> Maestro { get; set; }
        public string nombreInstituto { get; set; }
        public string capacidad_alumno { get; set; }
    }
}