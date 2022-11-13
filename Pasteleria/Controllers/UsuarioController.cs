using Pasteleria.Models.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pasteleria.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioModel modelUsuario = new UsuarioModel();
        public ActionResult UsuariosConsulta()
        {
            var resultado = modelUsuario.UsuariosLista();
            if (resultado != null)
                return View(resultado);
            else
                return View("Error");
        }



    }
}