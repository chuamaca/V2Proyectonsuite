using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model;
using proyecto.Areas.Admin.Filters;

namespace proyecto.Areas.Admin.Controllers
{
    [Autenticado]
    public class DetalleOrdensController : Controller
    {
        private ProyectoContext db = new ProyectoContext();
        private Orden orden = new Orden();
        private DetalleOrden detalleorden = new DetalleOrden();
        private Hardware inventario = new Hardware();


        // GET: Admin/DetalleOrdens
        public ActionResult Index()
        {
            var detalleOrden = db.DetalleOrden.Include(d => d.Hardware).Include(d => d.Orden);
            return View(detalleOrden.ToList());
        }

        // GET: Admin/DetalleOrdens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleOrden detalleOrden = db.DetalleOrden.Find(id);
            if (detalleOrden == null)
            {
                return HttpNotFound();
            }
            return View(detalleOrden);
        }

        // GET: Admin/DetalleOrdens/Create
        public ActionResult Create()
        {
            ViewBag.Hardware_Id = new SelectList(db.Hardware, "idhw", "seriehw");
            ViewBag.Orden_Id = new SelectList(db.Orden, "idorden", "codigoorden");
            return View();
        }

        // POST: Admin/DetalleOrdens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "iddetalleorden,Orden_Id,Hardware_Id,seriedt,usuariof,telefonof,ubicacion,cableseg,mouse,maleta,accesorio,valor,IGV,total,obscambio,estadodetalleorden")] DetalleOrden detalleOrden)
        {
            if (ModelState.IsValid)
            {
                db.DetalleOrden.Add(detalleOrden);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Hardware_Id = new SelectList(db.Hardware, "idhw", "codigontb", detalleOrden.Hardware_Id);
            ViewBag.Orden_Id = new SelectList(db.Orden, "idorden", "codigoorden", detalleOrden.Orden_Id);
            return View(detalleOrden);
        }


      //  GET: Admin/DetalleOrdens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleOrden detalleOrden = db.DetalleOrden.Find(id);
            if (detalleOrden == null)
            {
                return HttpNotFound();
            }

         
            ViewBag.Hardware_Id = new SelectList(db.Hardware.Where(g => g.idhw == detalleOrden.Hardware_Id), "idhw", "seriehw", detalleOrden.Hardware_Id);
            ViewBag.Orden_Id = new SelectList(db.Orden.Where(dt => dt.idorden == detalleOrden.Orden_Id), "idorden", "codigoorden", detalleOrden.Orden_Id);
            return View(detalleOrden);

        }

       

        // POST: Admin/DetalleOrdens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
  //      [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "iddetalleorden,Orden_Id,Hardware_Id,seriedt,usuariof,telefonof,ubicacion,cableseg,mouse,maleta,accesorio,valor,IGV,total,obscambio,estadodetalleorden,fregistro, gremision, grecepcion, codigontb, typedevice, seriehw, nmbrand, nmmodel, partnumberhw, snbatery, sncharger, nmprocessor, ghzprocessor, mcapacity, capacitystorage, lic, nmequipo, obshw, sefacturo, tipohardwareestado, descripciontipohardwareestado,moneda, identificador ")] DetalleOrden detalleOrden)
        {
            // db.DetalleOrden['estdodetalee'];
            var estadodetalleorden = detalleorden.Orden_Id;
            bool mensaje;

            if (ModelState.IsValid)
            {
               db.Entry(detalleOrden).State = EntityState.Modified;
               db.SaveChanges();
                // return RedirectToAction("Index");
                mensaje = true;
                return Json(mensaje);
            }

           

            ViewBag.Hardware_Id = new SelectList(db.Hardware, "idhw", "seriehw", detalleOrden.Hardware_Id);
            ViewBag.Orden_Id = new SelectList(db.Orden, "idorden", "codigoorden", detalleOrden.Orden_Id);
            return View(detalleOrden);
        }

        // GET: Admin/DetalleOrdens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleOrden detalleOrden = db.DetalleOrden.Find(id);
            if (detalleOrden == null)
            {
                return HttpNotFound();
            }
            return View(detalleOrden);
        }

        // POST: Admin/DetalleOrdens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleOrden detalleOrden = db.DetalleOrden.Find(id);
            db.DetalleOrden.Remove(detalleOrden);
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


        //Una Vista Parcial
        public PartialViewResult InventarioDetalle(int orden_id)
        {

            //lISTAMOS LOS EQUIPOS EN PROCESO

            ViewBag.InventarioElegido = detalleorden.Listar(orden_id);


            //pasamos todos el inventario por un viewbag

            ViewBag.Inventarios = inventario.Todos(orden_id);

            detalleorden.Orden_Id = orden_id;
            return PartialView(detalleorden);

        }

    }
}
