using Pasteleria.Models.Modelos;
using Pasteleria.Models.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Pasteleria.Controllers
{
    [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]
    public class HomeController : Controller
    {

        //Instancia
        UsuarioModel modelUsuario = new UsuarioModel();


        [HttpGet]
        public ActionResult Index()
        {
            Session.Clear();
            Session.Abandon();

            if (TempData.ContainsKey("mensaje"))
            {
                ViewBag.MsjInicio = TempData["mensaje"].ToString();
            }; 

            return View();
        }

        public ActionResult Registrar() {
            return View();
        }

        [FiltroSesiones]
        [HttpGet]
        public ActionResult Principal()
        {

            return View();
        }

        public ActionResult Logout() {
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

    }
}