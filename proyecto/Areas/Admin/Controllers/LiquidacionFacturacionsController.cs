using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model;
using Helper;

using proyecto.Areas.Admin.Filters;
using System.Data.SqlClient;

namespace proyecto.Areas.Admin.Controllers
{
    [Autenticado]
    public class LiquidacionFacturacionsController : Controller
    {

        public int afectado = 0;

        private ProyectoContext db = new ProyectoContext();

        // GET: Admin/LiquidacionFacturacions
        public ActionResult Index()
        {
            return View(db.LiquidacionFacturacion.ToList());
        }

        // GET: Admin/LiquidacionFacturacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LiquidacionFacturacion liquidacionFacturacion = db.LiquidacionFacturacion.Find(id);
            if (liquidacionFacturacion == null)
            {
                return HttpNotFound();
            }
            return View(liquidacionFacturacion);
        }

        // GET: Admin/LiquidacionFacturacions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LiquidacionFacturacions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idLiquidacionesFacturacion,procesos,estado,contratointerno,refacturable,mes,referencia,doc,numerodocumento,c_fact,fechaemision,fechainicio,fechafin,credito,rucempresa,empresa,contratomarco,grupoeconomico,ubicacion,red,responsable,telefonoresponsable,sucursal,ruccliente,cliente,usuariofinal,telefonousuario,tipousuario,ordenservicio,fechaordenservicio,rqcliente,contrato,guiaremision,tipo,tipohardwareestado,descripciontipohardwareestado,codigoequipo,tipoequipo,serie,marca,modelo,parnumber,bateria,cargador,procesador,velocidad,ram,disco,licencia,nombreequipo,usuariooficce,cableseguridad,mouse,maletin,softwareadicional,accesorios,observaciones,moneda,valor,igv,total,sefacturo")] LiquidacionFacturacion liquidacionFacturacion)
        {
            if (ModelState.IsValid)
            {
                db.LiquidacionFacturacion.Add(liquidacionFacturacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(liquidacionFacturacion);
        }

        // GET: Admin/LiquidacionFacturacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LiquidacionFacturacion liquidacionFacturacion = db.LiquidacionFacturacion.Find(id);
            if (liquidacionFacturacion == null)
            {
                return HttpNotFound();
            }
            return View(liquidacionFacturacion);
        }

        // POST: Admin/LiquidacionFacturacions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idLiquidacionesFacturacion,procesos,estado,contratointerno,refacturable,mes,referencia,doc,numerodocumento,c_fact,fechaemision,fechainicio,fechafin,credito,rucempresa,empresa,contratomarco,grupoeconomico,ubicacion,red,responsable,telefonoresponsable,sucursal,ruccliente,cliente,usuariofinal,telefonousuario,tipousuario,ordenservicio,fechaordenservicio,rqcliente,contrato,guiaremision,tipo,tipohardwareestado,descripciontipohardwareestado,codigoequipo,tipoequipo,serie,marca,modelo,parnumber,bateria,cargador,procesador,velocidad,ram,disco,licencia,nombreequipo,usuariooficce,cableseguridad,mouse,maletin,softwareadicional,accesorios,observaciones,moneda,valor,igv,total,sefacturo")] LiquidacionFacturacion liquidacionFacturacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(liquidacionFacturacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(liquidacionFacturacion);
        }

        // GET: Admin/LiquidacionFacturacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LiquidacionFacturacion liquidacionFacturacion = db.LiquidacionFacturacion.Find(id);
            if (liquidacionFacturacion == null)
            {
                return HttpNotFound();
            }
            return View(liquidacionFacturacion);
        }

        // POST: Admin/LiquidacionFacturacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LiquidacionFacturacion liquidacionFacturacion = db.LiquidacionFacturacion.Find(id);
            db.LiquidacionFacturacion.Remove(liquidacionFacturacion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }



        public JsonResult GenerarLiquidacionFacturacion(string valoridentificadorG)
        {
            var rm = new ResponseModel();
            //HAy que validar que estos se genere una sola vez al mes
            //Es decir que si es marzo solo tenga una vez registrada ese mes


            Usuario user = new Usuario();

            var usuarioEjecuto = user.ObtenerPerfil(SessionHelper.GetUser());
            var valor = usuarioEjecuto.nombre;

            RRR_Liquidacion_mensual(valoridentificadorG, valor);


            if (afectado != -1)
            {
                rm.response = true;
                rm.message = "SE AFECTO [ " + afectado + " ]  FILAS";
                rm.href = Url.Content("~/admin/liquidacionFacturacions/index");
                // ViewBag.rta = "LAs columnas afectadas fueron" + afectado;
            }
            else
            {
                rm.response = false;
                rm.message = "YA EXISTE LIQUIDACION FACTURACION DEL MES ACTUAL";
                rm.href = "self";
            }
            return Json(rm, JsonRequestBehavior.AllowGet);

            //  return Redirect("~/admin/liquidacion/index");


        }


        /// <summary>
        /// para trasladar a facturacion la lquidacion con el codigo identificador y quien lo genera.
     

        public void RRR_Liquidacion_mensual(string valoridentificadorG, string genera)
        {
           
            using (var ctx = new ProyectoContext())
            {
                afectado =  ctx.Database.ExecuteSqlCommand("RRR_insert_facturacion @identificadorGeneral, @usuarioEjecuto", new Object[]
                    {new SqlParameter ("@identificadorGeneral",valoridentificadorG ), new SqlParameter("@usuarioEjecuto",genera)});
            }


            

            //var ctx = new ProyectoContext();
            ////SqlParameter param1 = new SqlParameter("@MES", mes);
            ////SqlParameter param2 = new SqlParameter("@EMPRESA", empresa);
            //return ctx.Database.SqlQuery<Facturacion>("Rpt_detalle_facturacion @MES, @EMPRESA", new Object[]
            //    {new SqlParameter ("@MES",mes ), new SqlParameter("@EMPRESA",empresa)}).ToList();
        }



        //Usuario user = new Usuario();

        //var usuarioEjecuto = user.ObtenerPerfil(SessionHelper.GetUser());
        //var generador = usuarioEjecuto.nombre;

        //SqlParameter param2 = new SqlParameter("@usuarioEjecuto", generador);
        //afectado = ctx.Database.ExecuteSqlCommand("RRR_insert_liquidacion @usuarioEjecuto", param2);








    }
}
