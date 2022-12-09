using Pasteleria.Models.Modelos;
using Pasteleria.Models.Objetos;
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

     
        public ActionResult Validar(UsuarioObj usuario) {
            var resultado = modelUsuario.ValidarUsuario(usuario);

            if (resultado != null && resultado.token != null) {
                Session["CodigoSeguridad"] = resultado.token;
                Session["CorreoUsuario"] = resultado.correo;
                Session["RolUsuario"] = resultado.tipoUsuario.descripcion;
                return RedirectToAction("Principal", "Home");
            }
            else
                return RedirectToAction("Index", "Home");
        }

        [FiltroSesiones]
        public ActionResult UsuariosConsulta()
        {
            var resultado = modelUsuario.UsuariosLista();
            if (resultado != null)
                return View(resultado);
            else
                return View("Error");
        }

        [FiltroSesiones]
        public ActionResult UsuariosRegistrar()
        {
            //Consulta tipos de usuario y llena select
            var opciones = modelUsuario.ListarTipoUsuarios();
            ViewBag.ComboTiposUsuario = opciones;
            
            return View();
        }

        [FiltroSesiones]
        public ActionResult UsuariosActualizar(int id)
        {

            //Consulta tipos de usuario y llena select
            var opciones = modelUsuario.ListarTipoUsuarios();
            ViewBag.ComboTiposUsuario = opciones;

            //Consulta usuario a editar
            var resultado = modelUsuario.ConsultarUsuarioID(id);

            if (resultado != null)
            {
                return View(resultado);
            } 
            else
            {
                return View("Error");
            }
        }

    }
}