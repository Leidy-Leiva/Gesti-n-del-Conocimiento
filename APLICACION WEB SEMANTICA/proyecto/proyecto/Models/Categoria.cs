using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto.Models
{
    public class Categoria
    {
        public List<Instituto> Instituto { get; set; }
        public string CatNombre { get; set; }
    }
}