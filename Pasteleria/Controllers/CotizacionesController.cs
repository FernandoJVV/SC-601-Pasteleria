using Pasteleria.Models.Modelos;
using Pasteleria.Models.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Web;
using System.Web.Mvc;

namespace Pasteleria.Controllers
{
    public class CotizacionesController : Controller
    {
        private CotizacionModel _cotizacionModel = new CotizacionModel();
        private ComentarioModel _comentarioModel = new ComentarioModel();
        private OpcionModel _opcionesModel = new OpcionModel();

        [FiltroSesiones]
        // GET: Cotizaciones
        public ActionResult Index()
        {
            try {
                var lista = _cotizacionModel.ObtenerCotizaciones();
                return View(lista);
            }
            catch (Exception) {

                return View();
            }
        }

        [FiltroSesiones("Usuario")]
        public ActionResult Detalles(int id) {
            try {
                var cotizacion = _cotizacionModel.ObtenerCotizacion(id);
                var opciones = new List<SelectListItem>();
                var opcionesCotizacion = new List<OpcionObj>();
                foreach (var item in _cotizacionModel.ObtenerEstados())
                    opciones.Add(new SelectListItem { Text = item.Descripcion, Value = item.Id.ToString() });

                opcionesCotizacion = _cotizacionModel.ObtenerOpcionesCotizacion(id);

                var comentarios = _comentarioModel.ObtenerComentarios(id);

                ViewBag.Opciones = opcionesCotizacion;
                ViewBag.ComboEstados = opciones;
                ViewBag.Comentarios = comentarios;
                if (TempData["Mensaje"] != null) {
                    ViewBag.MsjExito = TempData["Mensaje"].ToString();
                }else if (TempData["Error"] != null) {
                    ViewBag.MsjInicio = TempData["Error"].ToString();
                }
                return View(cotizacion);
            }
            catch (Exception) {

                return View();
            }
        }

        [FiltroSesiones]
        [HttpPost]
        public ActionResult Editar(int COT_ID, decimal COT_ESTIMADO, int COT_EST_DESC) {
            try {
                var cotizacion = _cotizacionModel.ActualizarCotizacion(COT_ID, COT_ESTIMADO, COT_EST_DESC);
                TempData["Mensaje"] = "Modificación realizada con exito";

                return RedirectToAction("Detalles", new { id = COT_ID });
            }
            catch (Exception) {
                TempData["Error"] = "Error";
                return RedirectToAction("Detalles", new { id = COT_ID });
            }
        }

        [FiltroSesiones("Usuario")]
        [HttpPost]
        public ActionResult AgregarComentario(ComentarioObj com) {
            try {
                var email = Session["CorreoUsuario"].ToString();

                var cotizacion = _comentarioModel.AgregarComentarios(email, com);
                TempData["Mensaje"] = "Comentario añadido exitosamente";

                return RedirectToAction("Detalles", new { id = com.IdCotizacion });
            }
            catch (Exception) {
                TempData["Error"] = "Error al agregar comentario";
                return RedirectToAction("Detalles", new { id = com.IdCotizacion });
            }
        }

        [FiltroSesiones("Usuario")]
        [HttpGet]
        public ActionResult Listar() {
            try {
                var resultado = _opcionesModel.OpcionesHabilitadas();
                var niveles = new List<SelectListItem>();
                var sabor = new List<SelectListItem>();
                var color = new List<SelectListItem>();
                var decoracion = new List<SelectListItem>();
                var forma = new List<SelectListItem>();

                foreach (var item in (from x in resultado where x.NombreCategoria =="Niveles" select x).ToList()) {
                    niveles.Add(new SelectListItem {
                        Text = item.Descripcion,
                        Value = item.OpcionId.ToString()
                    });
                }
                foreach (var item in (from x in resultado where x.NombreCategoria == "Sabor" select x).ToList()) {
                    sabor.Add(new SelectListItem {
                        Text = item.Descripcion,
                        Value = item.OpcionId.ToString()
                    });
                }
                foreach (var item in (from x in resultado where x.NombreCategoria == "Color externo" select x).ToList()) {
                    color.Add(new SelectListItem {
                        Text = item.Descripcion,
                        Value = item.OpcionId.ToString()
                    });
                }
                foreach (var item in (from x in resultado where x.NombreCategoria == "Decoración" select x).ToList()) {
                    decoracion.Add(new SelectListItem {
                        Text = item.Descripcion,
                        Value = item.OpcionId.ToString()
                    });
                }
                foreach (var item in (from x in resultado where x.NombreCategoria == "Forma" select x).ToList()) {
                    forma.Add(new SelectListItem {
                        Text = item.Descripcion,
                        Value = item.OpcionId.ToString()
                    });
                }
                ViewBag.Niveles = niveles;
                ViewBag.Sabores = sabor;
                ViewBag.Colores = color;
                ViewBag.Decoraciones = decoracion;
                ViewBag.Formas = forma;

                var email = Session["CorreoUsuario"].ToString();
                var lista = _cotizacionModel.ListarCotizacionUsuario(email);
                return View(lista);
            }
            catch (Exception) {

                return View();
            }
        }
    }
}