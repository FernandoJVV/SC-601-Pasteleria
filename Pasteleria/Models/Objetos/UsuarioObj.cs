using Pasteleria.Models.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pasteleria.Models.Objetos
{
    public class UsuarioObj
    {
        public int id { get; set; }
        public string correo { get; set; }
        public string password { get; set; }
        public int telefono { get; set; }
        public TipoUsuarioModel tipoUsuario { get; set; }
        public bool estado { get; set; }
        public string token { get; set; }
    }
}