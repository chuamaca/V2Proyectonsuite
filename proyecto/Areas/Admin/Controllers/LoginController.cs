using Helper;
using Model;
using proyecto.Areas.Admin.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace proyecto.Areas.Admin.Controllers
{
  
    public class LoginController : Controller
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

                rm.message = "Acceso correcto";
                rm.href = Url.Content("~/admin/default");
            }

            return Json(rm);
        }

        public ActionResult Logout() 
        {
            SessionHelper.DestroyUserSession();
            
            return Redirect("~/admin/login");
        }
    }
}