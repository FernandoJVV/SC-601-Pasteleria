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
    public class HomeController : Controller
    {

        //Instancia
        UsuarioModel modelUsuario = new UsuarioModel();


        [HttpGet]
        public ActionResult Index()
        {
            Session.Clear();
            Session.Abandon();
            return View();
        }


        public ActionResult prueba()
        {
            ViewBag.Message = "prueba";

            return View();
        }

        [FiltroSesiones]
        [HttpGet]
        public ActionResult Principal()
        {
            
            return View();
        }

    }
}