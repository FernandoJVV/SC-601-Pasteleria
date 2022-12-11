using Pasteleria.Models.Modelos;
using Pasteleria.Models.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pasteleria.Controllers
{
    [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]
    public class UsuarioController : Controller
    {
        UsuarioModel modelUsuario = new UsuarioModel();

        [HttpPost]
        public ActionResult Validar(UsuarioObj usuario)
        {

            TempData["mensaje"] = string.Empty;
            var resultado = modelUsuario.ValidarUsuario(usuario);

            if (resultado != null && resultado.token != null)
            {
                Session["CodigoSeguridad"] = resultado.token;
                Session["CorreoUsuario"] = resultado.correo;
                Session["RolUsuario"] = resultado.tipoUsuario.descripcion;
                Session["IdUsuario"] = (int)resultado.id;
                return RedirectToAction("Principal", "Home");
            }
            else
            {
                TempData["mensaje"] = "Datos de inicio de sesion incorrectos";
                return RedirectToAction("Index", "Home");
            }

        }

        [FiltroSesiones]
        [HttpGet]
        public ActionResult UsuariosConsulta()
        {
            var resultado = modelUsuario.UsuariosLista();
            if (resultado != null)
                return View(resultado);
            else
                return View("Error");
        }

        [FiltroSesiones]
        [HttpGet]
        public ActionResult UsuariosRegistrar()
        {
            //Consulta tipos de usuario y llena select
            var opciones = modelUsuario.ListarTipoUsuarios();
            ViewBag.ComboTiposUsuario = opciones;
            
            return View();
        }

        [FiltroSesiones]
        [HttpPost]
        public ActionResult UsuariosRegistrar(UsuarioObj obj)
        {

            var resultado = modelUsuario.RegistrarUsuario(obj);

            if (resultado != null)
                return RedirectToAction("UsuariosConsulta", "Usuario");
            else
                return View("Error");
            
        }

        [FiltroSesiones]
        [HttpGet]
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


        [FiltroSesiones]
        [HttpPost]
        public ActionResult UsuariosActualizar(UsuarioObj obj)
        {
            var resultado = modelUsuario.ActualizarUsuario(obj);

            if (resultado != null)
                return RedirectToAction("UsuariosConsulta", "Usuario");
            else
                return View("Error");   

        }

        [FiltroSesiones]
        [HttpPost]
        public ActionResult CambiarEstadoUsuario(int id)
        {
            var obj = new UsuarioObj();
            obj.id = id;
            obj.correo = Session["CorreoUsuario"].ToString();

            var resultado = modelUsuario.CambiarEstadoUsuario(obj);

            if (resultado != null)
                return Json("OK", JsonRequestBehavior.AllowGet);
            else
                return Json(null, JsonRequestBehavior.DenyGet);
        }


    }
}