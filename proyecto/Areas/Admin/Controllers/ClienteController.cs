using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

using proyecto.Areas.Admin.Filters;

namespace proyecto.Areas.Admin.Controllers
{
    [Autenticado]
    public class ClienteController : Controller
    {
        // GET: Admin/Cliente

        private Cliente cliente = new Cliente();
        private Empresa miempresalista = new Empresa();

        public ActionResult Index()
        {
            return View();
        }


        public JsonResult CargarCliente(AnexGRID grid)
        {
            return Json(cliente.Listar(grid));
        }

        public ActionResult Crud(int id = 0)
        {
            ViewBag.miempresa = miempresalista.ListarEmpresa();
            return View(
                id == 0 ? new Cliente()
                        : cliente.Obtener(id)
            );
        }

        public JsonResult Guardar(Cliente model)
        {
            var rm = new ResponseModel();

            if (ModelState.IsValid)
            {
                rm = model.Guardar();

                if (rm.response)
                {
                    rm.message = "Guardado Correctamente";
                    rm.href = Url.Content("~/Admin/cliente/");
                }
            }
            else
            {
                rm.message = "datos Invalidos";
            }

            return Json(rm);
        }

        public ActionResult Eliminar(int id)
        {
            cliente.idcliente = id;
            cliente.Eliminar();
            return Redirect("~/admin/cliente/");
        }



    }
}