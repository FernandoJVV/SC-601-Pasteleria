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

        public ActionResult RegistroOpcion()
        {
            var resultado = model.GetCategorias();

            if (resultado != null)
            {
                var categorias = new List<SelectListItem>();

                foreach (var item in resultado)
                    categorias.Add(new SelectListItem { Text = item.Descripcion, Value = item.CatId.ToString() });

                ViewBag.ComboCategorias = categorias;
                return View();
            }
            else
                return View("Error");
        }

        public ActionResult EditarOpcion(int id) 
        {
            return View(); 
        }


    }


}