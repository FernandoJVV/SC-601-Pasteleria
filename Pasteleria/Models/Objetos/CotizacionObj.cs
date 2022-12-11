using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pasteleria.Models.Objetos
{
    public class CotizacionObj
    {
        public int COT_ID { get; set; }
        public string COT_USU_MAIL { get; set; }
        public string COT_EST_DESC { get; set; }
        public decimal COT_ESTIMADO { get; set; }
    }

    public class DTOCotizacion
    {
        public int COT_ID { get; set; }
        public int COT_USU_ID { get; set; }
        public int COT_EST_ID { get; set; }
        public decimal COT_ESTIMADO { get; set; }

    }
}