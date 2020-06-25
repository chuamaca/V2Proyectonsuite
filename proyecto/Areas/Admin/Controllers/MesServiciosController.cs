using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Helper;
using System.Data.SqlClient;
using System.Data.Sql;

using proyecto.Areas.Admin.Filters;

namespace proyecto.Areas.Admin.Controllers
{
    [Autenticado]
    public class MesServiciosController : Controller
    {

         mesServicio messerv = new mesServicio(); 
        // GET: Admin/MesServicios
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Crud(int id = 0)
        {
            return View(
                id == 0 ? new mesServicio()
                        : messerv.Obtener(id)
            );
        }

   

        [HttpPost]
        public JsonResult GuardarMesServicio(mesServicio model, String Objmeses = null)
        {
            var rm = new ResponseModel();

            var ctx = new ProyectoContext();
          

            if (Objmeses != null)
            {
                string[] mmmm = Objmeses.Split(',');

                foreach (var m in mmmm)
                {

                    var OMesServ = new mesServicio();
                    OMesServ.idorden = model.idorden;
                    OMesServ.idServicio = model.idServicio;
                    OMesServ.estado = model.estado;
                    OMesServ.meses = m;

                    ctx.mesServicio.Add(OMesServ);
                    ctx.SaveChanges();

                }
                rm.message = "Guardado correctamente";
                rm.SetResponse(true);
            }
            

            return Json(rm);
        }


        public bool ServicioInserta(mesServicio model, string mesess, int idservicio)
        {

            var rm = new ResponseModel();

            var ctx = new ProyectoContext();

            bool rpt;
            if (mesess != null)
            {
                string[] mmmm = mesess.Split(',');

                foreach (var m in mmmm)
                {

                    var OMesServ = new mesServicio();
                    OMesServ.idorden = model.idorden;
                    OMesServ.idServicio = model.idServicio;
                    OMesServ.estado = model.estado;
                    OMesServ.meses = m;

                    ctx.mesServicio.Add(OMesServ);
                    ctx.SaveChanges();

                }
                rpt = true;
            }else
            {
                rpt =false;
            }


            return rpt;

        }

        //PARA LISTAR LAS OS QUE TIENE ASIGANDAS CADA PROCESO DE ALQUILER
    
        //public JsonResult Listar_MesServicio(int idalquiler)
        //{
        //    using (var ctx= new ProyectoContext())
        //    {

        //        var query = ctx.mesServicio.Where(z => z.idorden == idalquiler)
        //                .Select(z => new
        //                {
        //                    z.idServicioMes,
        //                    z.idorden,
        //                    z.idServicio,
        //                    z.meses,
        //                    z.estado
        //                }).ToList();

        //        return Json(query, JsonRequestBehavior.AllowGet);
        //    }
        //}

        public JsonResult Listar_MesServicio(int idalquiler)
        {
            using (var ctx = new ProyectoContext())
            {

                var query = from messerv in ctx.mesServicio
                            join serv in ctx.Servicio
                            on messerv.idServicio equals serv.idservicio
                            where messerv.idorden == idalquiler
                            select new
                            {
                                messerv.idServicioMes,
                                messerv.idorden,
                                messerv.idServicio,
                                messerv.meses,
                                serv.os,
                                serv.rq,
                                serv.aprobador,
                                messerv.estado
                            };
                var jsonlista = query.ToList();
                return Json(jsonlista, JsonRequestBehavior.AllowGet);
            }
        }




        ///PARA LISTAR PORCESOS QUE NOT EGAN MESES DE ALQUILER
    

        public JsonResult ListarOrdenesSinMes(string abc)
        {
            var listarmesinos = messerv.get_ListarOrdenesSinMes();

            return Json(listarmesinos,JsonRequestBehavior.AllowGet);
        }



      



        public JsonResult Guardar(mesServicio model)
        {
            var rm = new ResponseModel();

            if (ModelState.IsValid)
            {
                rm = model.Guardar();
                var idredirect = model.idorden;

                if (rm.response)
                {
                    rm.message = "Guardado Correctamente";
                   rm.href = Url.Content("~/Admin/orden/crud/" +idredirect );
                }
            }

            return Json(rm);
        }

    

    }
}