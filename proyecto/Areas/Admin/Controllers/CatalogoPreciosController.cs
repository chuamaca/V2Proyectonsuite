using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

using Helper;

using proyecto.Areas.Admin.Filters;

namespace proyecto.Areas.Admin.Controllers
{
    [Autenticado]
    public class CatalogoPreciosController : Controller
    {

        private CatalogoPrecios catalogoprecio = new CatalogoPrecios();
        // GET: Admin/CatalogoPrecios
        public ActionResult Index()
        {
            return View();
        }

       
        // GET: Admin/Empresa
    
            //CARAGA EN LA VISTA CON EL JAVASCRIP LOAD
        public JsonResult CargaCatalogoPrecio(AnexGRID grid)
        {
            return Json(catalogoprecio.Listar(grid));
        }

        public ActionResult Crud(int id = 0)
        {
            return View(
                id == 0 ? new CatalogoPrecios()
                        : catalogoprecio.Obtener(id)
            );
        }

        public JsonResult Guardar(CatalogoPrecios model)
        {
            var rm = new ResponseModel();

            if (ModelState.IsValid)
            {
                rm = model.Guardar();

                if (rm.response)
                {
                    rm.message = "Guardado Correctamente";
                    rm.href = Url.Content("~/Admin/catalogoprecios/");
                }else
                {
                    rm.message = "err";
                }
            }

            return Json(rm);
        }

        public ActionResult Eliminar(int id)
        {
            catalogoprecio.idCatalogoPrecio = id;
            catalogoprecio.Eliminar();
            return Redirect("~/admin/catalogoprecios/");
        }

        //Para Buscar Cliente
        [HttpPost]
        public JsonResult Search_Empresa(string Prefix_empresa)
        {
            using (ProyectoContext ctx = new ProyectoContext())
            {

                var resultado = (from N in ctx.Empresa.ToList()
                                 where N.nmempresa.ToLower().StartsWith(Prefix_empresa.ToLower())
                                 select new { N.nmempresa });

                return Json(resultado, JsonRequestBehavior.AllowGet);

            }
        }




    }
}