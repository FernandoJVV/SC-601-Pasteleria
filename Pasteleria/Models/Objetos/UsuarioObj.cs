using Pasteleria.Models.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Pasteleria.Models.Objetos
{
    public class UsuarioObj
    {
        public int id { get; set; }

        [DisplayName("Correo")]
        public string correo { get; set; }

        [DisplayName("Contraseña")]
        public string password { get; set; }

        [DisplayName("Teléfono")]
        public int telefono { get; set; }

        [DisplayName("Tipo de usuario")]
        public TipoUsuarioModel tipoUsuario { get; set; }

        [DisplayName("Estado")]
        public bool estado { get; set; }
        public string token { get; set; }
    }
}