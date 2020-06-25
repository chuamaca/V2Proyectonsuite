

namespace Model
{


    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.SqlClient;
    public class Reporting
    {



        public int hardwareprod { get; set; }
        public int hardwareclose { get; set; }
        public int hardwarecambio { get; set; }
        public int warehousehw { get; set; }

        public int sinatencion { get; set; }

        public virtual List<Reporting> GetRPT_Hardware_produccion()
        {
            var ctx = new ProyectoContext();
            //    SqlParameter param1 = new SqlParameter("@idhardware", idhardware);
            return ctx.Database.SqlQuery<Reporting>("RPT_Hardware_produccion").ToList();
        }





        public int hardwareprodempresa { get; set; }
        public int hardwarecloseempresa { get; set; }
        public int hardwarecambioempresa { get; set; }
     
        public int sinatencionempresa { get; set; }


        //VISTA PARA CLIENTES DE PROCESOS Y EQUIPOS ACTIVOS

        public virtual List<Reporting> GetRPT_Hardware_produccion_for_empresa(string empresa)
        {
            var ctx = new ProyectoContext();
            SqlParameter param1 = new SqlParameter("@empresa", empresa);
            return ctx.Database.SqlQuery<Reporting>("RPT_Hardware_produccion_for_empresa @empresa", param1).ToList();
        }

        //PARA MOSTRAR EL LISTADO DE PROCESOS A LOS CLIENTES
        public AnexGRIDResponde ListarPorEmpresa(AnexGRID grid , string empresafilter)
        {
            try
            {
                using (var ctx = new ProyectoContext())
                {
                    grid.Inicializar();

                    var query = ctx.Orden.Where(x => x.idorden > 0)
                                           .Where(x => x.empresaorden == empresafilter);

                    // Ordenamiento
                    if (grid.columna == "idorden")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.idorden)
                                                             : query.OrderBy(x => x.idorden);
                    }


                    if (grid.columna == "codigoorden")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.codigoorden)
                                                             : query.OrderBy(x => x.codigoorden);
                    }

                    if (grid.columna == "empresaorden")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.empresaorden)
                                                             : query.OrderBy(x => x.empresaorden);
                    }
                    if (grid.columna == "clienteorden")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.clienteorden)
                                                             : query.OrderBy(x => x.clienteorden);
                    }

                    if (grid.columna == "ordenservicio")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.ordenservicio)
                                                             : query.OrderBy(x => x.ordenservicio);
                    }

                    if (grid.columna == "produccion")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.produccion)
                                                             : query.OrderBy(x => x.produccion);
                    }


                    if (grid.columna == "estadoorden")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.estadoorden)
                                                             : query.OrderBy(x => x.estadoorden);
                    }

                    var orden = query.Skip(grid.pagina)
                                       .Take(grid.limite)
                                       .ToList();

                    var total = query.Count();

                    grid.SetData(
                        from a in orden
                        select new
                        {
                            a.idorden,
                            a.codigoorden,
                            a.empresaorden,
                            a.clienteorden,
                            a.ordenservicio,
                            a.produccion,
                            a.estadoorden
                        },
                        total
                    );
                }
            }
            catch (Exception E)
            {

                throw;
            }

            return grid.responde();
        }


        public string equipousuarioorden { get; set; }

        public string telefonousuarioorden { get; set; }
        //PARA BUSCAR EN VISTA PARCIAL INVENTARIO LOS USUARIOS FINALES DEL EQUIPO POR EL ORDEN ID.
        public virtual List<Reporting> Get_usuario_final_host(int id)
        {

            
            var ctx = new ProyectoContext();
            SqlParameter param1 = new SqlParameter("@idordenuser", id);
            return ctx.Database.SqlQuery<Reporting>("SP_RPT_BUSCARUSUARIOFINAL @idordenuser", param1).ToList();
        }


       //public string numeroorden { get; set; }
       // public virtual List<Reporting> GetRPT_numeroorden_por_id(int idorden)
       // {
       //     var ctx = new ProyectoContext();
       //         SqlParameter param1 = new SqlParameter("@idorden", idorden);
       //     return ctx.Database.SqlQuery<Reporting>("RPT_orden_por_id @idorden", param1).ToList();
       // }
    }
}
