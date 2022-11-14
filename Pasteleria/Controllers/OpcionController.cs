using Pasteleria.Models.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pasteleria.Controllers
{
    public class OpcionController : Controller
    {
        OpcionModel model = new OpcionModel();
        // GET: Opcion
        public ActionResult OpcionesLista()
        {
            var resultado = model.OpcionesLista();
            if (resultado != null)
                return View(resultado);
            else
                return View("Error");
        }
    }
}