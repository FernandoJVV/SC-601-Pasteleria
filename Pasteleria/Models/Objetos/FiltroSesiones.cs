using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Pasteleria.Models.Objetos
{
    public class FiltroSesiones : ActionFilterAttribute
    {
        private bool allowUser;

        public FiltroSesiones(string permitir) {
            if (permitir == "Usuario") {
                this.allowUser = true;
            }
        }
        public FiltroSesiones() {
            this.allowUser = false;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["CodigoSeguridad"] == null || filterContext.HttpContext.Session["RolUsuario"] == null)
            {
                filterContext.Result = cambiarRuta();
            }
            if (filterContext.RouteData.Values["controller"].ToString() != "Home") {
                var rol = filterContext.HttpContext.Session["RolUsuario"].ToString();

                if (rol == "Usuario" && !allowUser) {
                    filterContext.Result = cambiarRuta();
                }
            }

            base.OnActionExecuting(filterContext);
        }

        private RedirectToRouteResult cambiarRuta() {
            return new RedirectToRouteResult(new RouteValueDictionary
                {
                    { "controller", "Home" },
                    { "action", "Index" }
                });
        }

    }//class
}