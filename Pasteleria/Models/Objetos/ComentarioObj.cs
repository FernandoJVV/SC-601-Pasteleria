using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pasteleria.Models.Objetos
{
    public class ComentarioObj
    {
        public int IdCotizacion { get; set; }
        public string Usuario { get; set; }
        public string Comentario { get; set; }
    }
}