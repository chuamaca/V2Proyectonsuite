using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



using Model;
using proyecto.Areas.Client.Filters;

using Helper;


namespace proyecto.Areas.Client.Controllers
{
    [Autenticado]
    public class RentingController : Controller
    {
        private Orden orden = new Orden();
        private Empresa miempresalista = new Empresa();
        private Sucursal misucursal = new Sucursal();
        private DetalleOrden detalleorden = new DetalleOrden();
        private Hardware inventario = new Hardware();
        private Reporting thisreport = new Reporting();


        //SE REEMPLAZO EN VEZ DE LA INSTANCIA   EnvioCorreo correoo = new EnvioCorreo();
     //   Cascada correoo = new Cascada();

               


        public JsonResult ListarOrdenPorEmpresa(AnexGRID grid, string empresafilter)
        {
            Usuario user = new Usuario();

            var getemp = user.ObtenerPerfil(SessionHelper.GetUser());

            var thisuser = getemp.razonsocial.ToString();

            return Json(thisreport.ListarPorEmpresa(grid, thisuser));
        }






        public ActionResult Index()
        {
            return View();
        }

        //CRUD DE ORDEN
        public ActionResult generarorden(int id = 0)
        {
            //para mostrar empresa
            Cascada empresasucursal = new Cascada();
            var list_empresa = empresasucursal.GetEmpresa();
            ViewBag.miempresa = list_empresa;


            return View(
                id == 0 ? new Orden()
                        : orden.Obtener(id)
            );
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

        public JsonResult Guardar(Orden model)
        {
            var rm = new ResponseModel();

            if (ModelState.IsValid)
            {
                rm = model.Guardar();

                if (rm.response)
                {
                    rm.href = Url.Content("~/home/index/");
                }
            }

            return Json(rm);
        }


        public JsonResult GuardarFormCopia(Orden model)
        {
            var rm = new ResponseModel();

            if (ModelState.IsValid)
            {
                rm = model.Guardar();

                if (rm.response)
                {
                    string proceso = model.codigoorden;
                    string razonsocial = model.empresaorden;
                    string sucursal = model.sucursalorden;
                    string responsabledelproceso = model.responsableorden;
                    string celulardelresponsabledelproceso = model.telefonoresponsableorden;
                    string usuariodelequipo = model.equipousuarioorden;
                    string tipousuario = model.tipousuarioorden;
                    string celulardelusuarioequipo = model.telefonousuarioorden;
                    string ubicacionfisicadelequipo = model.ubicacionequipoorden;
                    string equipoenred = model.redequipoorden;
                    string nombreclienteasociadoalnumerocontrato = model.clienteorden;
                    string rucclienteasociadoalnumerocontrato = "";
                    string numerocontratointerno = model.contratointernoorden;
                    string refacturable = model.refacturableorden;

                    string tipo = model.tipohardware;
                    string cantidad = model.cantidadhardware;
                    string oc = model.ordenservicio;
                    //var rpt=  EnviarCorreoPedido(proceso, razonsocial, sucursal, responsabledelproceso, celulardelresponsabledelproceso,
                    //     usuariodelequipo, tipousuario, celulardelusuarioequipo, ubicacionfisicadelequipo,
                    //     equipoenred, nombreclienteasociadoalnumerocontrato, rucclienteasociadoalnumerocontrato,
                    //     numerocontratointerno, refacturable, tipo, cantidad, oc);

                    var rpt = EnviarCorreoPedidoo(proceso, razonsocial, sucursal, responsabledelproceso, celulardelresponsabledelproceso,
                       usuariodelequipo, tipousuario, celulardelusuarioequipo, ubicacionfisicadelequipo,
                       equipoenred, nombreclienteasociadoalnumerocontrato, rucclienteasociadoalnumerocontrato,
                       numerocontratointerno, refacturable, tipo, cantidad, oc);

                    rm.message = rpt.Data.ToString();
                 //   rm.message = model.clienteorden;
                    rm.href = Url.Content("~/client/renting/index/");
                }
            }
            return Json(rm);
        }

        public JsonResult GuardarForm(Orden model)
        {
            var rm = new ResponseModel();

            Cascada correoo = new Cascada();

            if (ModelState.IsValid)
            {
                rm = model.Guardar();

                if (rm.response)
                {
                    string proceso = model.codigoorden;
                    string razonsocial = model.empresaorden;
                    string sucursal = model.sucursalorden;
                    string responsabledelproceso = model.responsableorden;
                    string celulardelresponsabledelproceso = model.telefonoresponsableorden;
                    string usuariodelequipo = model.equipousuarioorden;
                    string tipousuario = model.tipousuarioorden;
                    string celulardelusuarioequipo = model.telefonousuarioorden;
                    string ubicacionfisicadelequipo = model.ubicacionequipoorden;
                    string equipoenred = model.redequipoorden;
                    string nombreclienteasociadoalnumerocontrato = model.clienteorden;
                    string rucclienteasociadoalnumerocontrato = "";
                    string numerocontratointerno = model.contratointernoorden;
                    string refacturable = model.refacturableorden;

                    string tipo = model.tipohardware;
                    string cantidad = model.cantidadhardware;
                    string oc = model.ordenservicio;
                    //var rpt=  EnviarCorreoPedido(proceso, razonsocial, sucursal, responsabledelproceso, celulardelresponsabledelproceso,
                    //     usuariodelequipo, tipousuario, celulardelusuarioequipo, ubicacionfisicadelequipo,
                    //     equipoenred, nombreclienteasociadoalnumerocontrato, rucclienteasociadoalnumerocontrato,
                    //     numerocontratointerno, refacturable, tipo, cantidad, oc);


                    try{
                        string stServidor = "smtp.gmail.com";
                        string stUsuario = "renting.soporte@netcorporate.net";
                        string stPassword = "$Renting.2020#1";
                        //string stUsuario = "desarrollo@netcorporate.net";
                        //string stPassword = "**N3t.2020";

                        string asunto = "SERVICIO DE ALQUILER DE LAPTOP -" + nombreclienteasociadoalnumerocontrato + " - " + proceso;
                        string mensaje = "";
                        mensaje += "<b>Hola, por favor nos ayudan con la gestion de este proceso</b><br>";
                        mensaje += "OC: " + oc + "<br>";
                        mensaje += "Tipo :" + tipo + "<br>";
                        mensaje += "Cantidad :" + cantidad + "<br>";
                        mensaje += "<table border='1' bordercolor='666633' cellpadding='2' cellspacing='0'>";
                        /* mensaje += "<thead>";
                         mensaje += "<tr>";
                         mensaje += "<td>";
                         mensaje += "</td>";
                         mensaje += "<td>";
                         mensaje += "</td>";
                         mensaje += "</tr>";
                         mensaje += "</thead>";*/
                        mensaje += "<tbody>";
                        mensaje += "<tr><td><b>Proceso :</b></td><td>" + proceso + "</td></tr>";
                        mensaje += "<tr><td><b>Razón Social :</b></td><td>" + razonsocial + "</td></tr>";
                        mensaje += "<tr><td><b>Sucursal :</b></td><td>" + sucursal + "</td></tr>";
                        mensaje += "<tr><td><b>Responsable del Proceso :</b></td><td>" + responsabledelproceso + "</td></tr>";
                        mensaje += "<tr><td><b>Celular del Responsable del Proceso :</b></td><td>" + celulardelresponsabledelproceso + "</td></tr>";
                        mensaje += "<tr><td><b>Usuario del Equipo :</b></td><td>" + usuariodelequipo + "</td></tr>";
                        mensaje += "<tr><td><b>Tipo de Usuario :</b></td><td>" + tipousuario + "</td></tr>";
                        mensaje += "<tr><td><b>Celular del Usuario del Equipo :</b></td><td>" + celulardelusuarioequipo + "</td></tr>";
                        mensaje += "<tr><td><b>Ubicacion Fisica del Equipo :</b></td><td>" + ubicacionfisicadelequipo + "</td></tr>";
                        mensaje += "<tr><td><b>Equipo en Red :</b></td><td>" + equipoenred + "</td></tr>";
                        mensaje += "<tr><td><b>Nombre del Cliente asociado al número de Contrato :</b></td><td>" + nombreclienteasociadoalnumerocontrato + "</td></tr>";
                        mensaje += "<tr><td><b>RUC de Cliente asociado al Número de contrato :</b></td><td>" + rucclienteasociadoalnumerocontrato + "</td></tr>";
                        mensaje += "<tr><td><b>Numero de Contrato Interno :</b></td><td>" + numerocontratointerno + "</td></tr>";
                        mensaje += "<tr><td><b>Re Facturable :</b></td><td>" + refacturable + "</td></tr>";
                        mensaje += "</tbody>";
                        mensaje += "</table>";

                        string stFrom = "renting.soporte@netcorporate.net";
                        string stNombreFrom = "Renting";
                        string stTo = "chuamani@netcorporate.net";
                        //string stTo = "servicedesk@netcorporate.net";
                        string stoCC = "servicedesk@netcorporate.net";
                        string stArchivo = "";
                        string stArchivo2 = "";

                        correoo.envioMensajeEmail(stServidor, stUsuario, stPassword, stFrom, stNombreFrom, stTo, asunto, mensaje, stArchivo, stArchivo2, stoCC);
                        rm.SetResponse(true);
                        rm.message = "enviado con exito";

                        //   rm.message = model.clienteorden;
                        rm.href = Url.Content("~/client/renting/index/");
                    }
                    catch (Exception ex)
                    {
                        rm.SetResponse(false);
                        //resp = false;
                        rm.message = ex.Message;
                    }
                }
            }
            return Json(rm);
        }
        //PARA VISUALIZAR EQUIPOS EN PRODUCCION CAMBIOS ATENCIONES EN VISTA DEL CLIENTE

        public JsonResult GetRPT_Hardware_produccion_empresa(string empresa)
        {
            Usuario user = new Usuario();

            var getemp = user.ObtenerPerfil(SessionHelper.GetUser());

            var thisuser = getemp.razonsocial.ToString();

            var listaequiposproduccion = thisreport.GetRPT_Hardware_produccion_for_empresa(thisuser);

            return Json(listaequiposproduccion, JsonRequestBehavior.AllowGet);

        }


        public ActionResult ViewDetailorden(int id)
        {

            //PARA PODER TRAER EL LISTADO DE DETALLEORDEN DE ACUERDO AL ID DEL ORDEN

            ViewBag.InventarioElegido = detalleorden.Listar(id);

            return View(orden.ObtenerVerorden(id));
        }

        public JsonResult EnviarCorreoPedidoo(string proceso, string razonsocial, string sucursal,
            string responsabledelproceso, string celulardelresponsabledelproceso, string usuariodelequipo,
            string tipousuario, string celulardelusuarioequipo, string ubicacionfisicadelequipo,
            string equipoenred, string nombreclienteasociadoalnumerocontrato, string rucclienteasociadoalnumerocontrato,
                     string numerocontratointerno, string refacturable, string tipo, string cantidad, string oc)
        {
            Cascada correoo = new Cascada();
            var rm = new ResponseModel();

            bool resp;

          

            try
            {
                //string stServidor = ConfigurationManager.AppSettings["stServidor"].ToString();
                // string stUsuario = ConfigurationManager.AppSettings["stUsuario"].ToString();
                //   string stPassword = ConfigurationManager.AppSettings["stPassword"].ToString();
                // string stPuerto = ConfigurationManager.AppSettings["stPuerto"].ToString();


                string stServidor = "smtp.gmail.com";
                string stUsuario = "renting.soporte@netcorporate.net";
                string stPassword = "$Renting.2020#1";
                //string stUsuario = "desarrollo@netcorporate.net";
                //string stPassword = "**N3t.2020";

                string asunto = "SERVICIO DE ALQUILER DE LAPTOP -" + nombreclienteasociadoalnumerocontrato + " - " + proceso;
                string mensaje = "";
                mensaje += "<b>Hola, por favor nos ayudan con la gestion de este proceso</b><br>";
                mensaje += "OC: " + oc + "<br>";
                mensaje += "Tipo :" + tipo + "<br>";
                mensaje += "Cantidad :" + cantidad + "<br>";
                mensaje += "<table border='1' bordercolor='666633' cellpadding='2' cellspacing='0'>";
                /* mensaje += "<thead>";
                 mensaje += "<tr>";
                 mensaje += "<td>";
                 mensaje += "</td>";
                 mensaje += "<td>";
                 mensaje += "</td>";
                 mensaje += "</tr>";
                 mensaje += "</thead>";*/
                mensaje += "<tbody>";
                mensaje += "<tr><td><b>Proceso :</b></td><td>" + proceso + "</td></tr>";
                mensaje += "<tr><td><b>Razón Social :</b></td><td>" + razonsocial + "</td></tr>";
                mensaje += "<tr><td><b>Sucursal :</b></td><td>" + sucursal + "</td></tr>";
                mensaje += "<tr><td><b>Responsable del Proceso :</b></td><td>" + responsabledelproceso + "</td></tr>";
                mensaje += "<tr><td><b>Celular del Responsable del Proceso :</b></td><td>" + celulardelresponsabledelproceso + "</td></tr>";
                mensaje += "<tr><td><b>Usuario del Equipo :</b></td><td>" + usuariodelequipo + "</td></tr>";
                mensaje += "<tr><td><b>Tipo de Usuario :</b></td><td>" + tipousuario + "</td></tr>";
                mensaje += "<tr><td><b>Celular del Usuario del Equipo :</b></td><td>" + celulardelusuarioequipo + "</td></tr>";
                mensaje += "<tr><td><b>Ubicacion Fisica del Equipo :</b></td><td>" + ubicacionfisicadelequipo + "</td></tr>";
                mensaje += "<tr><td><b>Equipo en Red :</b></td><td>" + equipoenred + "</td></tr>";
                mensaje += "<tr><td><b>Nombre del Cliente asociado al número de Contrato :</b></td><td>" + nombreclienteasociadoalnumerocontrato + "</td></tr>";
                mensaje += "<tr><td><b>RUC de Cliente asociado al Número de contrato :</b></td><td>" + rucclienteasociadoalnumerocontrato + "</td></tr>";
                mensaje += "<tr><td><b>Numero de Contrato Interno :</b></td><td>" + numerocontratointerno + "</td></tr>";
                mensaje += "<tr><td><b>Re Facturable :</b></td><td>" + refacturable + "</td></tr>";
                mensaje += "</tbody>";
                mensaje += "</table>";

                string stFrom = "renting.soporte@netcorporate.net";
                string stNombreFrom = "Renting";
                string stTo = "chuamani@netcorporate.net";
                //string stTo = "servicedesk@netcorporate.net";
                string stoCC = "";
                string stArchivo = "";
                string stArchivo2 = "";

                correoo.envioMensajeEmail(stServidor, stUsuario, stPassword, stFrom, stNombreFrom, stTo, asunto, mensaje, stArchivo, stArchivo2, stoCC);
                 rm.SetResponse(true);
                 rm.message = "enviado con exito";

                //resp = true;
                //Response.Write("<sript>alert('se envioi con exito')<script>");
            }
            catch (Exception ex)
            {
                 rm.SetResponse(false);
                //resp = false;
                rm.message = ex.Message;
            }
            //  return Json(rm, JsonRequestBehavior.AllowGet);
            return Json(rm, JsonRequestBehavior.AllowGet);
        }

        public bool EnviarCorreoPedido(string proceso, string razonsocial, string sucursal,
            string responsabledelproceso, string celulardelresponsabledelproceso, string usuariodelequipo,
            string tipousuario, string celulardelusuarioequipo, string ubicacionfisicadelequipo,
            string equipoenred, string nombreclienteasociadoalnumerocontrato, string rucclienteasociadoalnumerocontrato,
                     string numerocontratointerno, string refacturable, string tipo, string cantidad, string oc)
        {
            Cascada correoo = new Cascada();
            var rm = new ResponseModel();

            bool resp;

            try
            {
                //string stServidor = ConfigurationManager.AppSettings["stServidor"].ToString();
                // string stUsuario = ConfigurationManager.AppSettings["stUsuario"].ToString();
                //   string stPassword = ConfigurationManager.AppSettings["stPassword"].ToString();
                // string stPuerto = ConfigurationManager.AppSettings["stPuerto"].ToString();


                string stServidor = "smtp.gmail.com";
                string stUsuario = "renting.soporte@netcorporate.net";
                string stPassword = "$Renting.2020#1";
                //string stUsuario = "desarrollo@netcorporate.net";
                //string stPassword = "**N3t.2020";

                string asunto = "SERVICIO DE ALQUILER DE LAPTOP -" + nombreclienteasociadoalnumerocontrato + " - " + proceso;
                string mensaje = "";
                mensaje += "<b>Hola, por favor nos ayudan con la gestion de este proceso</b><br>";
                mensaje += "OC: " + oc + "<br>";
                mensaje += "Tipo :" + tipo + "<br>";
                mensaje += "Cantidad :" + cantidad + "<br>";
                mensaje += "<table border='1' bordercolor='666633' cellpadding='2' cellspacing='0'>";
                /* mensaje += "<thead>";
                 mensaje += "<tr>";
                 mensaje += "<td>";
                 mensaje += "</td>";
                 mensaje += "<td>";
                 mensaje += "</td>";
                 mensaje += "</tr>";
                 mensaje += "</thead>";*/
                mensaje += "<tbody>";
                mensaje += "<tr><td><b>Proceso :</b></td><td>" + proceso + "</td></tr>";
                mensaje += "<tr><td><b>Razón Social :</b></td><td>" + razonsocial + "</td></tr>";
                mensaje += "<tr><td><b>Sucursal :</b></td><td>" + sucursal + "</td></tr>";
                mensaje += "<tr><td><b>Responsable del Proceso :</b></td><td>" + responsabledelproceso + "</td></tr>";
                mensaje += "<tr><td><b>Celular del Responsable del Proceso :</b></td><td>" + celulardelresponsabledelproceso + "</td></tr>";
                mensaje += "<tr><td><b>Usuario del Equipo :</b></td><td>" + usuariodelequipo + "</td></tr>";
                mensaje += "<tr><td><b>Tipo de Usuario :</b></td><td>" + tipousuario + "</td></tr>";
                mensaje += "<tr><td><b>Celular del Usuario del Equipo :</b></td><td>" + celulardelusuarioequipo + "</td></tr>";
                mensaje += "<tr><td><b>Ubicacion Fisica del Equipo :</b></td><td>" + ubicacionfisicadelequipo + "</td></tr>";
                mensaje += "<tr><td><b>Equipo en Red :</b></td><td>" + equipoenred + "</td></tr>";
                mensaje += "<tr><td><b>Nombre del Cliente asociado al número de Contrato :</b></td><td>" + nombreclienteasociadoalnumerocontrato + "</td></tr>";
                mensaje += "<tr><td><b>RUC de Cliente asociado al Número de contrato :</b></td><td>" + rucclienteasociadoalnumerocontrato + "</td></tr>";
                mensaje += "<tr><td><b>Numero de Contrato Interno :</b></td><td>" + numerocontratointerno + "</td></tr>";
                mensaje += "<tr><td><b>Re Facturable :</b></td><td>" + refacturable + "</td></tr>";
                mensaje += "</tbody>";
                mensaje += "</table>";

                string stFrom = "renting.soporte@netcorporate.net";
                string stNombreFrom = "Renting";
                string stTo = "chuamani@netcorporate.net";
                //string stTo = "servicedesk@netcorporate.net";
                string stoCC = "";
                string stArchivo = "";
                string stArchivo2 = "";

                correoo.envioMensajeEmail(stServidor, stUsuario, stPassword, stFrom, stNombreFrom, stTo, asunto, mensaje, stArchivo, stArchivo2, stoCC);
                // rm.SetResponse(true);
                // rm.message = "enviado con exito";

                resp = true;
                //Response.Write("<sript>alert('se envioi con exito')<script>");
            }
            catch (Exception ex)
            {
                // rm.SetResponse(false);
                resp = false;
                //rm.message = ex.Message;
            }
            //  return Json(rm, JsonRequestBehavior.AllowGet);
            return resp;
        }


        CatalogoPrecios catalogo = new CatalogoPrecios();

        public JsonResult buscartipohardware(string empresa)
        {
            var buscaempresa = catalogo.ListarCatalogoPorEmpresa(empresa);

            return Json(buscaempresa, JsonRequestBehavior.AllowGet);
        }


        public JsonResult ListarTipoPorEmpresa(string empresanombre)
        {
            using (var ctx = new ProyectoContext())
            {
                var querytipo = ctx.CatalogoPrecios.Where(p => p.empresa == empresanombre)
                     .Select(p => new
                     {

                         p.nombre

                     }).Distinct().ToList();

                return Json(querytipo, JsonRequestBehavior.AllowGet);
                        


            }
        }


    }
}