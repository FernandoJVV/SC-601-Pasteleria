using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pasteleria.Models.Objetos
{
    public class OpcionObj
    {
        public int OpcionId { get; set; }
        public int CategoriaId { get; set; }
        public string NombreCategoria { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public bool Estado { get; set; }

    }
}