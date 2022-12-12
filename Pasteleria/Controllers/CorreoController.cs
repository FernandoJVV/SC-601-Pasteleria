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
    public class CorreoController : Controller
    {
        CorreoModel modelCorreo = new CorreoModel();

        //ingresar a pantalla donde se ingresa el email
        [AllowAnonymous]
        [HttpGet]
        public ActionResult RecuperarCorreo()
        {

            return View();
        }

        //enviarCorreo con codigo
        [AllowAnonymous]
        [HttpPost]
        public ActionResult RecuperarCorreo(CorreoObj correo)
        {
            var resultado = modelCorreo.ExisteCorreo(correo);
            if (resultado != null)
                return RedirectToAction("CodigoCorreo", "Correo", new { id = resultado.idUsuario, codigo = resultado.codigo});
            else
                return View("RecuperarCorreo");
        }


        //ingresar a pantalla
        [AllowAnonymous]
        [HttpGet]
        public ActionResult CodigoCorreo(int id, int codigo)
        {
            CorreoObj datos = new CorreoObj();
            datos.idUsuario = id;
            datos.codigo = codigo;
            return View(datos);
        }

        //Verificacion de codigo 
        [AllowAnonymous]
        [HttpPost]
        public ActionResult CodigoCorreo(CorreoObj correo)
        {
            if (correo != null)
                return RedirectToAction("CambiaContrasena", "Correo", new { id = correo.idUsuario});
            else
                return View("CodigoCorreo", new { id = correo.idUsuario, codigo = correo.codigo });
        }


        //entrar en pantalla
        [AllowAnonymous]
        [HttpGet]
        public ActionResult CambiaContrasena(int id)
        {
            UsuarioObj datos = new UsuarioObj();
            datos.id = id;
            return View(datos);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult CambiaContrasena(UsuarioObj datos)
        {

            var resultado = modelCorreo.CambiarContrasenaRecuperacionModel(datos);

            if (resultado != null)
                return RedirectToAction("Index", "Home");
            else
                return View("CambiaContrasena", new { id = datos.id });
        }


       



    }
}