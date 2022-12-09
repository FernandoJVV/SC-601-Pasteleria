using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pasteleria.Models.Modelos
{
    public class TipoUsuarioModel
    {
        public int id { get; set; }
        public string descripcion { get; set; }

        public TipoUsuarioModel(int id, string descripcion)
        {
            this.id = id;
            this.descripcion = descripcion;
        }

        public TipoUsuarioModel()
        {
        }
    }
}