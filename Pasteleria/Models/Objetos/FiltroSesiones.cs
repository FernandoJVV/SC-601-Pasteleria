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

        public FiltroSesiones(string permitir)
        {
            if (permitir == "Usuario")
            {
                this.allowUser = true;
            }
        }
        public FiltroSesiones()
        {
            this.allowUser = false;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var rolNulo = filterContext.HttpContext.Session["RolUsuario"] == null;

            if (filterContext.HttpContext.Session["CodigoSeguridad"] == null || rolNulo)
            {
                filterContext.Result = cambiarRuta();
                base.OnActionExecuting(filterContext);
                return;
            }

            if (!rolNulo)
            {
                var rol = filterContext.HttpContext.Session["RolUsuario"].ToString();

                if (rol == "Usuario" && !allowUser)
                {
                    filterContext.Result = cambiarRuta();
                }
            }

            base.OnActionExecuting(filterContext);
        }

        private RedirectToRouteResult cambiarRuta()
        {
            return new RedirectToRouteResult(new RouteValueDictionary
                {
                    { "controller", "Home" },
                    { "action", "Index" }
                });
        }

    }//class
}