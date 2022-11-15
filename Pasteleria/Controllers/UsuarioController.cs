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

        public ActionResult UsuariosRegistrar()
        {
            var opciones = modelUsuario.ListarTipoUsuarios();
            //opciones.Add(new SelectListItem { Text = "Administrador", Value = "1" });
           //opciones.Add(new SelectListItem { Text = "Usuario", Value = "2" });

            ViewBag.ComboTiposUsuario = opciones;

            return View();
        }

        public ActionResult UsuariosActualizar(int id)
        {
            return View();
        }

    }
}