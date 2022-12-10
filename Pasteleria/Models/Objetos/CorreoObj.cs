using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pasteleria.Models.Objetos
{
    public class CorreoObj
    {
        public string Destinatario { get; set; }
        public string Asunto { get; set; }
        public string Mensaje { get; set; }

        public int codigo { get; set; }

        public int idUsuario { get; set; }
    }
}