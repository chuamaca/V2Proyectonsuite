using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;


namespace proyecto.Areas.Admin.Controllers
{
    public class ServiciosController : Controller
    {


        private Servicio servicio = new Servicio();
        // GET: Admin/Servicios
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Crud(int id = 0)
        {
            return View(
                id == 0 ? new Servicio()
                        : servicio.Obtener(id)
            );
        }

        public JsonResult GuardarServicio(Servicio model, mesServicio modelServicio, String[] Objmeses = null)
        {
            var rm = new ResponseModel();
         
            if (ModelState.IsValid)
            {
                rm = model.Guardar();
                var idservicio = model.idservicio;
                if (rm.response)
                {
                    modelServicio.idServicio = idservicio;
                    modelServicio.estado = 1;
                    if (MesServicioInserta(modelServicio, Objmeses))
                    {
                        rm.message = "Guardado Correctamente -" + model.idservicio.ToString();
                    }else
                    {
                        rm.message = "Error al Guardar";
                        rm.response=false;
                    }                                   
                }
            }
            return Json(rm);
        }

        public bool MesServicioInserta(mesServicio model, string[] messs)
        {

            var rm = new ResponseModel();
            var ctx = new ProyectoContext();
            bool rpt;
            if (messs != null)
            {
                //  string[] mmmm = messs.Split(',');
                try
                {
                    foreach (var m in messs)
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
                }
                catch (Exception)
                {
                    rpt = false;
                  //  throw;
                }
                
                
            }
            else
            {
                rpt = false;
            }            
            return rpt;
        }
    }
}