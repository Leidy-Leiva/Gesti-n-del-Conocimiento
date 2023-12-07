using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto.Models
{
    public class Estilo 
    {
        public string Identificador { get; set; }
        public string NomEstilo { get; set; }
        public string DesEstilo { get; set; }
        public string Categoria { get; set; }
        public string Maestro { get; set; }
    }
}