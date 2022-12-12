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
    public class DTOOpcionXCotizacionObj
    {
        public int OXC_ID { get; set; }
        public int OXC_COT_ID { get; set; }
        public int OXC_OPC_ID { get; set; }

    }
    public class CategoriaObj
    {
        public int CatId { get; set; }
        public string Descripcion { get; set; }

    }

}