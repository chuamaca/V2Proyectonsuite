using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Helper;
using Model;

using Helper;
using proyecto.Areas.Admin.Filters;
namespace proyecto.Areas.Admin.Controllers
{

    [Autenticado]
    public class UsuarioController : Controller
    {

   
        private Usuario usuario = new Usuario();
        private Empresa miempresalista = new Empresa();
        // GET: Admin/Usuario
        public ActionResult Index()
        {

           
            return View();
        }

        public JsonResult cargarUsuario(AnexGRID grid)
        {
            return Json(usuario.Listar(grid));
        }

        public ActionResult Crud(int id = 0)
        {
            ViewBag.miempresa = miempresalista.ListarEmpresa();
            return View(
                id == 0 ? new Usuario()
                        : usuario.Obtener(id)
            );
            
        }

        public JsonResult Guardar(Usuario model)
        {
            var rm = new ResponseModel();

            if (ModelState.IsValid)
            {
                //var clave="";
                if (model.clave !=null)
                {
                    var clave = HashHelper.MD5(model.clave);
                      
                        model.clave = clave;
                }else
                {
                    model.clave = model.clave;
                   // clave = "no viene calve";
                }
               
               // rm.message = clave;
                rm = model.Guardar();

                if (rm.response)
                {
                    rm.message = "Guardado correctamente";
                    rm.href = Url.Content("~/Admin/usuario/");
                }
            }

            return Json(rm);
        }

        public ActionResult Eliminar(int id)
        {
            usuario.idusuario = id;
            usuario.Eliminar();
            return Redirect("~/admin/usuario/");
        }






    }
}