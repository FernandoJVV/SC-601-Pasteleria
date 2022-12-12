using Pasteleria.Models.Modelos;
using Pasteleria.Models.Objetos;
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
        [FiltroSesiones]
        public ActionResult OpcionesLista()
        {
            var resultado = model.OpcionesLista();
            if (resultado != null)
                return View(resultado);
            else
                return View("Error");
        }

        [FiltroSesiones]
        [HttpGet]
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

        [FiltroSesiones]
        [HttpPost]
        public ActionResult RegistroOpcion(OpcionObj obj)
        {
            var resultado = model.OpcionRegistrar(obj);

            if (resultado != null)
                return RedirectToAction("OpcionesLista", "Opcion");
            else
                return View("Error");
        }

        [FiltroSesiones]
        [HttpGet]
        public ActionResult EditaOpcion(int id)
        {
            var resultado = model.GetCategorias();

            if (resultado != null)
            {
                var categorias = new List<SelectListItem>();

                foreach (var item in resultado)
                    categorias.Add(new SelectListItem { Text = item.Descripcion, Value = item.CatId.ToString() });

                ViewBag.ComboCategorias = categorias;

                //Consulta el usuario a editar
                var opcion = model.ConsultaOpcion(id);

                if (opcion != null)
                    return View(opcion);
                else
                    return View("Error");

            }
            else
                return View("Error");
        }

        [FiltroSesiones]
        [HttpPost]
        public ActionResult EditaOpcion(OpcionObj obj)
        {
            var resultado = model.OpcionActualizar(obj);

            if (resultado != null)
                return RedirectToAction("OpcionesLista", "Opcion");
            else
                return View("Error");
        }

        [FiltroSesiones]
        [HttpDelete]
        public string EliminarOpcion(int id)
        {
            var resultado = model.EliminarOpcion(id);
            return resultado;
        }

    }

}