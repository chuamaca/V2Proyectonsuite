using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Model;
using Helper;
using proyecto.Areas.Client.Filters;

namespace proyecto.Areas.Client.Controllers
{

    public class InicioController : Controller
    {
        private Usuario usuario = new Usuario();

        [NoLogin]
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Acceder(string cuenta, string clave)
        {
            var rm = usuario.Acceder(cuenta, clave);

            if (rm.response)
            {
                rm.message = "Acceso Correcto";
                rm.href = Url.Content("~/client/renting/index");
            }

            return Json(rm);
        }

        public ActionResult Logout()
        {
            SessionHelper.DestroyUserSession();
            return Redirect("~/client/inicio/index");
        }
    }
}