using Pasteleria.Models.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pasteleria.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        [FiltroSesiones]
        public ActionResult Principal()
        {
            return View();
        }

        public ActionResult Registrar() {
            return View();
        }
    }
}