using proyecto.Areas.Admin.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace proyecto.Areas.Admin.Controllers
{
    [Autenticado]
    public class SucursalController : Controller
    {
        private Sucursal sucursal = new Sucursal();
        private Empresa miempresalista = new Empresa();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Crud(int id = 0)
        {
            ViewBag.miempresa = miempresalista.ListarEmpresa();
            return View(
                id == 0 ? new Sucursal()
                        : sucursal.Obtener(id)
            );
        }

        public JsonResult cargarSucursal(AnexGRID grid)
        {
            return Json(sucursal.Listar(grid));
        }

        public JsonResult Guardar(Sucursal model)
        {
            var rm = new ResponseModel();

            if (ModelState.IsValid)
            {
                rm = model.Guardar();

                if (rm.response)
                {
                    rm.message = "Guardado Correctamente";
                    rm.href = Url.Content("~/admin/sucursal/");
                }
            }
            return Json(rm);
        }

        public ActionResult Eliminar(int id)
        {
            sucursal.idsucursal = id;
            sucursal.Eliminar();
            return Redirect("~/admin/sucursal/");
        }

    }
}