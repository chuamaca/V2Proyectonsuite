using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Helper;
using System.IO;

using proyecto.Areas.Admin.Filters;

namespace proyecto.Areas.Admin.Controllers
{

    [Autenticado]
    public class PerfilController : Controller
    {

        private Usuario usuario = new Usuario();
        // GET: Admin/Perfil
        public ActionResult Miperfil()
        {
            return View(usuario.ObtenerPerfil(SessionHelper.GetUser()));
        }


        public JsonResult GuardarPerfil(Usuario model, HttpPostedFileBase foto)
        {
            var rm = new ResponseModel();

            //Para Validar que el campo Pasword Nose Guarde
            ModelState.Remove("clave");
            if (ModelState.IsValid)
            {

                rm = model.GuardarPerfil(foto);

                if (rm.response)
                {
                    rm.message = "Guardado correctamente";
                    rm.href = "self";
                }
            }
            return Json(rm);
        }
        
    }
}