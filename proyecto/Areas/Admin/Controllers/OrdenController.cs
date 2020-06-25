
using System.Web.Mvc;
using Model;
using proyecto.Areas.Admin.Filters;
using proyecto.Areas.Admin.formatos;
using System.Linq;
using System.Data.Sql;
using System.Collections.Generic;
using System.Data;
using System;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using System.Configuration;
using Helper;

namespace proyecto.Areas.Admin.Controllers
{
    [Autenticado]

    public class OrdenController : Controller
    {
        private Reporting thisreport = new Reporting();

        private ReportingNumOrden thisnumeroorden = new ReportingNumOrden();

        private Orden orden = new Orden();
        private Empresa miempresalista = new Empresa();
        private Sucursal misucursal = new Sucursal();

        private DetalleOrden detalleorden = new DetalleOrden();
        private Hardware inventario = new Hardware();

        private HardwareInfo hwdetail = new HardwareInfo();

        private Reporting mireporte = new Reporting();

        public string numeroorden { get; set; }

        // GET: Admin/Empresa
        public ActionResult Index()

        {
            return View();
        }
        //PARA CONSULTAR LAS CARACTERITICAS COMPLETAS DEL HARDWARE
        public JsonResult GetHardwareDetail(int idhardware = 0)
        {

            var lista_hardwaredetail = hwdetail.GetHardwareDetail(idhardware);

            return Json(lista_hardwaredetail, JsonRequestBehavior.AllowGet);

        }



        public ActionResult formatos()

        {
            return View();
        }

        public ActionResult gremission()

        {
            return View();
        }

        public JsonResult CargarOrden(AnexGRID grid)
        {
            return Json(orden.Listar(grid));
        }

        //PARA CARGAR DETALLE ORDEN - 
        //public JsonResult CargarDetalleOrden(AnexGRID grid)
        //{
        //    return Json(orden.ListarDetalleOrden(grid));
        //}



        public ActionResult Crud(int id = 0, int id_em = 3)
        {
            //ViewBag.miempresa = miempresalista.ListarEmpresa();

            //para mostrar empresa
            Cascada empresasucursal = new Cascada();
            var list_empresa = empresasucursal.GetEmpresa();
            ViewBag.miempresa = list_empresa;


            return View(
                id == 0 ? new Orden()
                        : orden.Obtener(id)
            );
        }

        public ActionResult Fose()
        {

            return View();
        }

        public JsonResult enviarFose()
        {
            Usuario user = new Usuario();

            var getemp = user.ObtenerPerfil(SessionHelper.GetUser());

            var thisuser = getemp.correo.ToString();

            //  return Json(thisreport.ListarPorEmpresa(grid, thisuser));
            return Json(thisuser, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetSucursal(int idempresa)
        {

            Cascada sucursal = new Cascada();

            var lista_sucursal = sucursal.GetSucursal(idempresa);

            return Json(lista_sucursal, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCliente(int idempresa)
        {

            Cascada cliente = new Cascada();

            var lista_Cliente = cliente.GetCliente(idempresa);

            return Json(lista_Cliente, JsonRequestBehavior.AllowGet);
        }





        public ActionResult ViewDetailorden(int id)
        {

            //PARA PODER TRAER EL LISTADO DE DETALLEORDEN DE ACUERDO AL ID DEL ORDEN

            ViewBag.InventarioElegido = detalleorden.Listar(id);

            return View(orden.ObtenerVerorden(id));
        }


        [HttpPost]
        public JsonResult Search_Cliente(string Prefix)
        {
            using (ProyectoContext ctx = new ProyectoContext())
            {
                var resultado = (from N in ctx.Cliente.ToList()
                                 where N.nmcliente.ToLower().StartsWith(Prefix.ToLower())
                                 select new { N.nmcliente });

                return Json(resultado, JsonRequestBehavior.AllowGet);

            }
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


        [HttpPost]
        public JsonResult Search_Sucursal(string Prefix_Sucursal)
        {
            using (ProyectoContext ctx = new ProyectoContext())
            {

                var resultado = (from N in ctx.Sucursal.ToList()
                                 where N.nmsucursal.ToLower().StartsWith(Prefix_Sucursal.ToLower())
                                 select new { N.nmsucursal });

                return Json(resultado, JsonRequestBehavior.AllowGet);

            }
        }

        //  public JsonResult generarFose(Orden model,int idorden)
        // {
        //  string numeroorden = model.numeroorden;
        //   var rm = new ResponseModel();
        // pdfFose(idorden, numeroorden);
        /*   if (rm.response)
           {
               rm.message = "pdf generado";
           }*/

        /*   var consulta = 

           if ()
           {

           }*/
        //   return Json(pdfFose, JsonRequestBehavior.AllowGet);
        //    }
        public bool generarFose(int idorden)
        {
            //  var rm = new ResponseModel();
            //if (System.IO.File.Exists("C:/reports/fose/fose" + idorden + ".pdf"))
            //{
            //    rm.message = "El Fichero ya existe, Desea Generar de nuevo";
            //}
            //else
            //{
            rpt_fose formatofose = new rpt_fose();

            //string numeroordenn = orden.numeroorden;}
            //  orden.numeroorden = model.numeroorden;
            bool res;
            try
            {

                formatofose.SetDatabaseLogon(user: "sa", password: "**N3t.2019");
                formatofose.VerifyDatabase();
                
                formatofose.SetParameterValue("@idorden", idorden);
                //--RUta para el servidor
                formatofose.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, "D:/netcorporate.net/rentt/reports/fose/fose" + idorden + ".pdf");
                //-- formatofose.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, "C:/reports/fose/fose" + idorden + ".pdf");
                //  rm.SetResponse(true);
              
                res = true;
                //rm.message = "OK";
            }
            catch (Exception ex)
            {
                // rm.message = ex.Message;
                res = false;
            }
            //}
            //  return Json(res, JsonRequestBehavior.AllowGet);
            return res;
        }

        public bool generarFoseCorreo(int idorden)
        {
            //  var rm = new ResponseModel();
            //if (System.IO.File.Exists("C:/reports/fose/fose" + idorden + ".pdf"))
            //{
            //    rm.message = "El Fichero ya existe, Desea Generar de nuevo";
            //}
            //else
            //{
            rpt_fose formatofose = new rpt_fose();

            //string numeroordenn = orden.numeroorden;}
            //  orden.numeroorden = model.numeroorden;
            bool res;
            try
            {

                formatofose.SetDatabaseLogon(user: "sa", password: "**N3t.2019");
                formatofose.VerifyDatabase();

                formatofose.SetParameterValue("@idorden", idorden);
                //--RUta para el servidor
                formatofose.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, "D:/netcorporate.net/rentt/correo/fose/fose" + idorden + ".pdf");
                //-- formatofose.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, "C:/reports/fose/fose" + idorden + ".pdf");
                //  rm.SetResponse(true);

                res = true;
                //rm.message = "OK";
            }
            catch (Exception ex)
            {
                // rm.message = ex.Message;
                res = false;
            }
            //}
            //  return Json(res, JsonRequestBehavior.AllowGet);
            return res;
        }


        public JsonResult ver_fose(int id)
        {
            var rm = new ResponseModel();
            /*if (System.IO.File.Exists("C:/reports/fose/fose" + id + ".pdf"))
            {
                rm.message = "El Fichero ya existe, Desea Generar de nuevo";
            }else
            {*/
            var resgenerarfose = generarFose(id);
            if (resgenerarfose)
            {
                rm.SetResponse(true);
                rm.href = "http://192.168.0.9/rentt/reports/fose/fose" + id + ".pdf";
            }
            else
            {
                rm.SetResponse(false);
                rm.message = "no se pudo crear el fose";
            }

            // }

            return Json(rm, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ver_guia_re(int id)
        {
            var rm = new ResponseModel();
            /*if (System.IO.File.Exists("C:/reports/fose/fose" + id + ".pdf"))
            {
                rm.message = "El Fichero ya existe, Desea Generar de nuevo";
            }else
            {*/
            var resgenerarguiaremision = generarGuiaRemision(id);
            if (resgenerarguiaremision)
            {
                rm.SetResponse(true);
                rm.href = "http://192.168.0.9/rentt/reports/guiasremision/guiaremision" + id + ".pdf";
            }
            else
            {
                rm.SetResponse(false);
                rm.message = "no se pudo crear la guia de remision";
            }

            // }

            return Json(rm, JsonRequestBehavior.AllowGet);
        }
        public bool generarGuiaRemision(int idorden)
        {
            //  var rm = new ResponseModel();
            //if (System.IO.File.Exists("C:/reports/fose/fose" + idorden + ".pdf"))
            //{
            //    rm.message = "El Fichero ya existe, Desea Generar de nuevo";
            //}
            //else
            //{
            rpt_gremision formatogRemision = new rpt_gremision();

            //string numeroordenn = orden.numeroorden;}
            //  orden.numeroorden = model.numeroorden;
            bool res;
            try
            {

                formatogRemision.SetDatabaseLogon(user: "sa", password: "**N3t.2019");
                formatogRemision.VerifyDatabase();


                formatogRemision.SetParameterValue("@idorden", idorden);
                //--RUta para el servidor
                formatogRemision.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, "D:/netcorporate.net/rentt/reports/guiasremision/guiaremision" + idorden + ".pdf");
                //--  formatogRemision.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, "C:/reports/guiasremision/guiaremision" + idorden + ".pdf");
                //  rm.SetResponse(true);
                res = true;
                //rm.message = "OK";
            }
            catch (Exception ex)
            {
                // rm.message = ex.Message;
                res = false;
            }
            //}
            //  return Json(res, JsonRequestBehavior.AllowGet);
            return res;
        }

        public bool generarGuiaRemisionCorreo(int idorden)
        {
            //  var rm = new ResponseModel();
            //if (System.IO.File.Exists("C:/reports/fose/fose" + idorden + ".pdf"))
            //{
            //    rm.message = "El Fichero ya existe, Desea Generar de nuevo";
            //}
            //else
            //{
            rpt_gremision formatogRemision = new rpt_gremision();

            //string numeroordenn = orden.numeroorden;}
            //  orden.numeroorden = model.numeroorden;
            bool res;
            try
            {

                formatogRemision.SetDatabaseLogon(user: "sa", password: "**N3t.2019");
                formatogRemision.VerifyDatabase();


                formatogRemision.SetParameterValue("@idorden", idorden);
                //--RUta para el servidor
                formatogRemision.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, "D:/netcorporate.net/rentt/correo/guiasremision/guiaremision" + idorden + ".pdf");
                //--  formatogRemision.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, "C:/reports/guiasremision/guiaremision" + idorden + ".pdf");
                //  rm.SetResponse(true);
                res = true;
                //rm.message = "OK";
            }
            catch (Exception ex)
            {
                // rm.message = ex.Message;
                res = false;
            }
            //}
            //  return Json(res, JsonRequestBehavior.AllowGet);
            return res;
        }

        public bool generarGuiaRecepcion(int id)
        {
            RPP_grecepcion formatoGuiaRecepcion = new RPP_grecepcion();
            // var rm = new ResponseModel();
            bool res;
            try
            {
                formatoGuiaRecepcion.SetDatabaseLogon(user: "sa", password: "**N3t.2019");
                formatoGuiaRecepcion.VerifyDatabase();
                formatoGuiaRecepcion.SetParameterValue("@iddetalle", id);
               // formatoGuiaRecepcion.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, "D:/netcorporate.net/renting/reports/guiasremision/guiaremision" + 23 + ".pdf");
                formatoGuiaRecepcion.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, "D:/netcorporate.net/rentt/reports/guiasrecepcion/guiarecepcion" + id +".pdf");
                /* rm.response = true;
                 rm.message = "Creado correctamente";*/
                  res = true;
            }
            catch (Exception ex)
            {
                /*rm.response = false;
                 rm.message = ex.Message;*/

                    res = false;
            }
            //return Json(rm.response, JsonRequestBehavior.AllowGet);
            return res;
        }

        public bool generarGuiaRecepcionCorreo(int id)
        {
            RPP_grecepcion formatoGuiaRecepcion = new RPP_grecepcion();
            // var rm = new ResponseModel();
            bool res;
            try
            {
                formatoGuiaRecepcion.SetDatabaseLogon(user: "sa", password: "**N3t.2019");
                formatoGuiaRecepcion.VerifyDatabase();
                formatoGuiaRecepcion.SetParameterValue("@iddetalle", id);
                // formatoGuiaRecepcion.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, "D:/netcorporate.net/renting/reports/guiasremision/guiaremision" + 23 + ".pdf");
                formatoGuiaRecepcion.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, "D:/netcorporate.net/rentt/correo/guiasrecepcion/guiarecepcion" + id + ".pdf");
                /* rm.response = true;
                 rm.message = "Creado correctamente";*/
                res = true;
            }
            catch (Exception ex)
            {
                /*rm.response = false;
                 rm.message = ex.Message;*/

                res = false;
            }
            //return Json(rm.response, JsonRequestBehavior.AllowGet);
            return res;
        }


        public JsonResult guiaRecepcion(int id, string enviar)
        {
            var rpt = "";
            if (enviar == "")
            {
                var res = generarGuiaRecepcion(id);
               
                if (res)
                {
                    rpt = "true";
                }
                else
                {
                    rpt = "error 1";
                }
            }else
            {
                var res = generarGuiaRecepcion(id);

                if (res)
                {
                    rpt = "true";
                }
                else
                {
                    rpt = "error 2";
                }
            }
           

            return Json(rpt, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ver_guia_recepcion( int id)
        {
            var rm = new ResponseModel();
            /*if (System.IO.File.Exists("C:/reports/fose/fose" + id + ".pdf"))
            {
                rm.message = "El Fichero ya existe, Desea Generar de nuevo";
            }else
            {*/
                var resguiarecepcion = generarGuiaRecepcion(id);
                if (resguiarecepcion)
                {
                    rm.SetResponse(true);
                    rm.href = "http://192.168.0.9/rentt/reports/guiasrecepcion/guiarecepcion" + id+".pdf";
                }else
                {
                    rm.SetResponse(false);
                    rm.message = "no se pudo crear la guia de recepcion";
                }

           // }

            return Json(rm, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Guardar(Orden model)
        {
            var rm = new ResponseModel();
    

            if (ModelState.IsValid)
            {
                rm = model.Guardar();

                if (rm.response)
                {

                   
                    rm.message = "Guardado correctamente";
                    rm.href = Url.Content("~/Admin/orden/");

                }
            }

            return Json(rm, JsonRequestBehavior.AllowGet);
        }

      

        public ActionResult Eliminar(int id)
        {
            orden.idorden = id;
            orden.Eliminar();
            return Redirect("~/admin/orden/");
        }


        //Una Vista Parcial
        public PartialViewResult Inventario(int orden_id, string tipo, string empresa)
        {

            //lISTAMOS LOS EQUIPOS EN PROCESO

            ViewBag.InventarioElegido = detalleorden.Listar(orden_id);

            ViewBag.mitipoelegido = tipo;
            ViewBag.empresaelegida = empresa;
            // var buscarprecio = catalogo.ListarCatalogoPorEmpresayTipo(empresa, tipo, caracteristicas);

            //pasamos todos el inventario por un viewbag

            ViewBag.Inventarios = inventario.Todos(orden_id);

            detalleorden.Orden_Id = orden_id;
            //detalleorden.valor = precios;
            return PartialView(detalleorden);

        }


        //public PartialViewResult Inventario(int orden_id)
        //{

        //    //lISTAMOS LOS EQUIPOS EN PROCESO

        //    ViewBag.InventarioElegido = detalleorden.Listar(orden_id);


        //    //pasamos todos el inventario por un viewbag

        //    ViewBag.Inventarios = inventario.Todos(orden_id);

        //    detalleorden.Orden_Id = orden_id;
        //    return PartialView(detalleorden);

        //}

        // public PartialViewResult InventarioCambio(int orden_id, string ordendetalle, string usuario,decimal valor)

        public PartialViewResult InventarioCambio(int orden_id,string ordendetalle,  string usuario, string celular,
            string ubicacion , string observacion, string cable, string mouse, string maleta, string accesorio,string grecepcion,
            string seriehw, string sefacturo, string tipohardwareestado, string descripciontipohardwareestado, string identificador
            , string moneda, decimal valor = 0, decimal igv = 0, decimal total = 0)
        {

            var nomempresa = nombreempresa(orden_id);
            ViewBag.nomempresa=nomempresa;
      

            //FIN: BUSCAMOS EMPRESA PARA TAER PRECIOS

            //lISTAMOS LOS EQUIPOS EN PROCESO


            ViewBag.InventarioElegido = detalleorden.Listar(orden_id);

            ViewBag.mimouse = detalleorden.mouse;

            //pasamos todos el inventario por un viewbag

            ViewBag.Inventarios = inventario.Todos(orden_id);

            detalleorden.Orden_Id = orden_id;
            detalleorden.valor = valor;
            detalleorden.IGV = igv;
            detalleorden.total = total;
            detalleorden.usuariof = usuario.Replace("-"," ");
            detalleorden.telefonof = celular.Replace("-", " ");
            detalleorden.ubicacion = ubicacion.Replace("-", " ");
            detalleorden.obshw =  observacion.Replace("-", " ");
            detalleorden.obscambio ="INGRESA GR: "+ grecepcion.Replace("-", " ") +" DEL "+ DateTime.Now.ToString("dd/MM/yyyy")+"\n MOTIVO: CAMBIO S/N:"+ seriehw;
            detalleorden.cableseg = cable.Replace("-", " ");
            detalleorden.mouse = mouse.Replace("-", " ");
            detalleorden.maleta = maleta.Replace("-", " ");
            detalleorden.accesorio = accesorio.Replace("-", " ");
            detalleorden.seriedt = ordendetalle.Replace("-", " ");

            detalleorden.sefacturo = sefacturo.Replace("-", " ");
            detalleorden.tipohardwareestado = tipohardwareestado.Replace("-", " ");
            detalleorden.descripciontipohardwareestado = descripciontipohardwareestado.Replace("-", " ");
            detalleorden.identificador = identificador.Replace("-", " ");
            detalleorden.moneda = moneda.Replace("-", " ");

            // detalleorden.usuariof = usuario;

            //var valord = valor;
            //  detalleorden.valor = valor ;
            return PartialView(detalleorden);

        }

        //INICIO TRAER EMPRESA POR IDORDEN

        //INICIO: BUSCAMOS EMPRESA PARA TAER PRECIOS
        public JsonResult nombreempresa (int miid_orden)
        {

            using (var ctx = new ProyectoContext())
            {
                var queryempresa = ctx.Orden.Where(p => p.idorden == miid_orden)
                    .Select(p => new
                    {
                        p.empresaorden
                    }).ToList();

                return Json(queryempresa, JsonRequestBehavior.AllowGet);

                    
            }
        }

      //INICIO TRAER EMPRESA POR IDORDEN


        //public JsonResult listarAlumnos()
        //{
        //    var lista = (bd.Alumno.Where(p => p.BHABILITADO.Equals(1))
        //        .Select(p => new
        //        {
        //            p.IIDALUMNO,
        //            p.NOMBRE,
        //            p.APPATERNO,
        //            p.APMATERNO,
        //            p.TELEFONOPADRE
        //        })).ToList();
        //    return Json(lista, JsonRequestBehavior.AllowGet);
        //}

        private void Consultaempresa(int id_ordenfroempresa)
        {
            using (var ctx = new ProyectoContext())
            {
                var query = ctx.Orden.Where(p => p.idorden == id_ordenfroempresa)
                    .Select(p => new
                    {
                        p.empresaorden
                    }).ToString();
                    

            }

        }


        public JsonResult GuardarInventario(DetalleOrden model)
        {
            var rm = new ResponseModel();

            //Usuario user = new Usuario();

            //var getemp = user.ObtenerPerfil(SessionHelper.GetUser());

            //var correousuario = getemp.correo.ToString();

            var res = "";
            int id = model.Orden_Id;
            if (ModelState.IsValid)
            {
                rm = model.Guardar();

                if (rm.response)
                {
                    
                   
                    rm.function = "CargarInventario()";
                }
            }

            return Json(rm);
        }
        public JsonResult GuardarInventarioo(DetalleOrden model)
        {
            var rm = new ResponseModel();

            //Usuario user = new Usuario();

            //var getemp = user.ObtenerPerfil(SessionHelper.GetUser());

            //var correousuario = getemp.correo.ToString();

            var res = "";
            int id = model.Orden_Id;
            if (ModelState.IsValid)
            {
                rm = model.Guardar();

                if (rm.response)
                {


                    rm.function = "closeCurrentWindow()";
                }
            }

            return Json(rm);
        }

        public JsonResult getUsuarioFinal(int id)
        {

            //  var miid = detalleorden.Orden_Id;

            var kl = mireporte.Get_usuario_final_host(id);

            // var kl = id;

            return Json(kl, JsonRequestBehavior.AllowGet);

        }
       


       

        public bool enviarCorreo(int id)
        {

            Usuario user = new Usuario();

            var getemp = user.ObtenerPerfil(SessionHelper.GetUser());

            var correousuario= getemp.correo.ToString();


            var rm = new ResponseModel();
            EnvioCorreo correo = new EnvioCorreo();
            bool res;
            try
            {
                //string stServidor = ConfigurationManager.AppSettings["stServidor"].ToString();
                // string stUsuario = ConfigurationManager.AppSettings["stUsuario"].ToString();
                //   string stPassword = ConfigurationManager.AppSettings["stPassword"].ToString();
                // string stPuerto = ConfigurationManager.AppSettings["stPuerto"].ToString();


                string stServidor = "smtp.gmail.com";
                string stUsuario = "renting.soporte@netcorporate.net";
                string stPassword = "$Renting.2020#1";

                string asunto = "asunto";
                string mensaje = "mensaje";
                string stFrom = "desarrollo@netcorporate.net";
                string stNombreFrom = "Desarrollo";
                string stTo = correousuario;
                string stoCC = "chuamani@netcorporate.net";
                string stArchivo = "D:/netcorporate.net/rentt/reports/fose/fose" + id + ".pdf";
                string stArchivo2 = "D:/netcorporate.net/rentt/reports/guiasremision/guiaremision" + id + ".pdf";

                

                correo.envioMensajeEmail(stServidor, stUsuario, stPassword, stFrom, stNombreFrom, stTo, asunto, mensaje, stArchivo, stArchivo2, stoCC);
                rm.SetResponse(true);
                res = true;
                //Response.Write("<sript>alert('se envioi con exito')<script>");
            }
            catch (Exception ex)
            {
                // rm.SetResponse(false);
                res = false;
            }
            return res;
        }

        public JsonResult enviarCorreoFose(string correo, int id, string codigoorden, string clienteorden, string numeroorden)
        {
            var rm = new ResponseModel();
            Usuario user = new Usuario();

            var getemp = user.ObtenerPerfil(SessionHelper.GetUser());

            var correousuario = getemp.correo.ToString();
            
            EnvioCorreo correoo = new EnvioCorreo();

            var resgenFose = generarFoseCorreo(id);
            if (resgenFose)
            {
                try
                {
                    //string stServidor = ConfigurationManager.AppSettings["stServidor"].ToString();
                    // string stUsuario = ConfigurationManager.AppSettings["stUsuario"].ToString();
                    //   string stPassword = ConfigurationManager.AppSettings["stPassword"].ToString();
                    // string stPuerto = ConfigurationManager.AppSettings["stPuerto"].ToString();


                    string stServidor = "smtp.gmail.com";
                    string stUsuario = "renting.soporte@netcorporate.net";
                    string stPassword = "$Renting.2020#1";

                    string asunto = "SERVICIO DE ALQUILER DE LAPTOP (fose) - "+ clienteorden + " - "+codigoorden;
                    string mensaje = "Se adjunta el Fose N#" + numeroorden;
                    string stFrom = "renting.soporte@netcorporate.net";
                    string stNombreFrom = "Renting (NetCorporate)";
                    string stTo = correousuario;
                    string stoCC = correo;
                    string stArchivo = "D:/netcorporate.net/rentt/correo/fose/fose" + id + ".pdf";
                    string stArchivo2 = "";

                    correoo.envioMensajeEmail(stServidor, stUsuario, stPassword, stFrom, stNombreFrom, stTo, asunto, mensaje, stArchivo, stArchivo2, stoCC);
                    rm.SetResponse(true);
                    rm.message = "enviado con exito";
                    stArchivo = null;
                    
                    correoo.Dispose();


                    //Response.Write("<sript>alert('se envioi con exito')<script>");
                }
                catch (Exception ex)
                {
                    // rm.SetResponse(false);
                    rm.message = ex.Message;
                }
            }else
            {
                rm.SetResponse(false);
                rm.message = "No se pudo Generar el Fose";
            }
           
            return Json(rm, JsonRequestBehavior.AllowGet);
        }

        public JsonResult enviarCorreoGuiaRemision(string correo, int id, string codigoorden, string clienteorden)
        {
            var rm = new ResponseModel();
            Usuario user = new Usuario();

            var getemp = user.ObtenerPerfil(SessionHelper.GetUser());

            var correousuario = getemp.correo.ToString();

            EnvioCorreo correoo = new EnvioCorreo();

            var resGuiaRem = generarGuiaRemisionCorreo(id);
            if (resGuiaRem)
            {
                try
                {
                    //string stServidor = ConfigurationManager.AppSettings["stServidor"].ToString();
                    // string stUsuario = ConfigurationManager.AppSettings["stUsuario"].ToString();
                    //   string stPassword = ConfigurationManager.AppSettings["stPassword"].ToString();
                    // string stPuerto = ConfigurationManager.AppSettings["stPuerto"].ToString();


                    string stServidor = "smtp.gmail.com";
                    string stUsuario = "renting.soporte@netcorporate.net";
                    string stPassword = "$Renting.2020#1";

                    string asunto = "SERVICIO DE ALQUILER DE LAPTOP (G. Remision) - " + clienteorden + " - " + codigoorden;
                    string mensaje = "Guia de Remision ";
                    string stFrom = "renting.soporte@netcorporate.net";
                    string stNombreFrom = "Renting (NetCorporate)";
                    string stTo = correousuario;
                    string stoCC = correo;
                    string stArchivo = "D:/netcorporate.net/rentt/correo/guiasremision/guiaremision" + id + ".pdf";
                    string stArchivo2 = "";

                    correoo.envioMensajeEmail(stServidor, stUsuario, stPassword, stFrom, stNombreFrom, stTo, asunto, mensaje, stArchivo, stArchivo2, stoCC);
                    rm.SetResponse(true);
                    rm.message = "enviado con exito";
                    stArchivo = null;
                    //Response.Write("<sript>alert('se envioi con exito')<script>");
                }
                catch (Exception ex)
                {
                     rm.SetResponse(false);
                    rm.message = ex.Message;
                }
            }else
            {
                rm.SetResponse(false);
                rm.message = "no se pudo Generar el Pdf";
            }
            return Json(rm, JsonRequestBehavior.AllowGet);
        }

        public JsonResult enviarCorreoGuiaRecepcion(string correo, int id, string marca, string modelo, string serie, string ubicacion)
        {
            var rm = new ResponseModel();
            Usuario user = new Usuario();

            var getemp = user.ObtenerPerfil(SessionHelper.GetUser());

            var correousuario = getemp.correo.ToString();

            EnvioCorreo correoo = new EnvioCorreo();

            var resGuiaRecepcion = generarGuiaRecepcionCorreo(id);
          
            if (resGuiaRecepcion)
            {
                try
                {
                    //string stServidor = ConfigurationManager.AppSettings["stServidor"].ToString();
                    // string stUsuario = ConfigurationManager.AppSettings["stUsuario"].ToString();
                    //   string stPassword = ConfigurationManager.AppSettings["stPassword"].ToString();
                    // string stPuerto = ConfigurationManager.AppSettings["stPuerto"].ToString();


                    string stServidor = "smtp.gmail.com";
                    string stUsuario = "renting.soporte@netcorporate.net";
                    string stPassword = "$Renting.2020#1";

                    string asunto = "Recepcion de Laptop";
                    string mensaje = "Estimados por favor gestionar el recojo de una Laptop";
                    mensaje += "Marca : " + marca +"\n";
                    mensaje += "Modelo : " + modelo + "\n";
                    mensaje += "Serie :" + serie + "\n";
                    mensaje += "La laptop se encuentra en la sede de " + ubicacion;
                    string stFrom = "renting.soporte@netcorporate.net";
                    string stNombreFrom = "Renting (NetCorporate)";
                    string stTo = correousuario;
                    string stoCC = correo;
                    string stArchivo = "D:/netcorporate.net/rentt/correo/guiasrecepcion/guiarecepcion" + id + ".pdf";
                    string stArchivo2 = "";

                    correoo.envioMensajeEmail(stServidor, stUsuario, stPassword, stFrom, stNombreFrom, stTo, asunto, mensaje, stArchivo, stArchivo2, stoCC);
                    rm.SetResponse(true);
                    rm.href = Url.Content("~/Admin/detalleordens/");
                    rm.message = "enviado con exito";
                    stArchivo = null;
                    //Response.Write("<sript>alert('se envioi con exito')<script>");
                }
                catch (Exception ex)
                {
                    // rm.SetResponse(false);
                    rm.message = ex.Message;
                }
            }
            else
            {
                rm.SetResponse(false);
                rm.message = "No se pudo Generar el Fose";
            }

            return Json(rm, JsonRequestBehavior.AllowGet);
        }


        //PARA TRAER CATALOGO DE PRECIOS
        CatalogoPrecios catalogo = new CatalogoPrecios();

        public JsonResult buscartipohardware(string empresa)
        {
            using (var ctx = new ProyectoContext())
            {
                var querytipo = ctx.CatalogoPrecios.Where(p => p.empresa == empresa)
                     .Select(p => new
                     {

                         p.nombre

                     }).Distinct().ToList();

                return Json(querytipo, JsonRequestBehavior.AllowGet);



            }
        }

        //public JsonResult ListarTipoPorEmpresa(string empresanombre)
        //{
        //    using (var ctx = new ProyectoContext())
        //    {
        //        var querytipo = ctx.CatalogoPrecios.Where(p => p.empresa == empresanombre)
        //             .Select(p => new
        //             {

        //                 p.nombre

        //             }).Distinct().ToList();

        //        return Json(querytipo, JsonRequestBehavior.AllowGet);



        //    }
        //}

        public JsonResult ListarCatalogoPorEmpresaTipo(string empresa, string tipo)
        {
            var precio = catalogo.ListarCatalogoPorEmpresaTipo(empresa, tipo);

            return Json(precio, JsonRequestBehavior.AllowGet);
        }

        public JsonResult buscarpreciohardware(string empresa, string tipo, string caracteristicas)
        {
            var buscarprecio = catalogo.ListarCatalogoPorEmpresayTipo(empresa, tipo, caracteristicas);

            return Json(buscarprecio, JsonRequestBehavior.AllowGet);
        }





        public ActionResult prueba()
        {
            return View();
        }

        public JsonResult GetRPT_numeroorden_porid(int idorden)
        {
            var numeroorden = thisnumeroorden.GetRPT_numeroorden_por_id(idorden);
            return Json(numeroorden, JsonRequestBehavior.AllowGet);
        }

        public ActionResult cambiar()
        {
            return View();
        }

        public ActionResult cambio()
        {
            return View();
        }

    }
}