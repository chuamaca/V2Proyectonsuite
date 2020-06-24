namespace Model
{
    using Helper;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Data.Entity.Validation;
    using System.IO;
    using System.Linq;
    using System.Web;


    [Table("Orden")]
    public class Orden
    {



        public Orden()
        {

            DetalleOrden = new HashSet<DetalleOrden>();
            mesServicio = new HashSet<mesServicio>();
        }





        //Pedido Del Usuario
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idorden { get; set; }

   
        [DisplayName("Fose")]
        [StringLength(50)]
        public string numeroorden { get; set; }

        [Required]
        [DisplayName("Codigo Orden")]
        [StringLength(10)]
        public string codigoorden { get; set; }

        [Required]
        [DisplayName("Empresa")]
        public string empresaorden { get; set; }

        [Required]
        [DisplayName("Sucursal")]
        public string sucursalorden { get; set; }


        [Required]
        [DisplayName("Cliente")]
        public string clienteorden { get; set; }

        [DisplayName("Contrato Interno")]
        [StringLength(50)]
        public string contratointernoorden { get; set; }

        [DisplayName("Refacturable")]
        [StringLength(50)]
        public string refacturableorden { get; set; }


        [DisplayName("Usuario Orden")]
        [StringLength(50)]
        public string generateuserorden { get; set; }

        [DisplayName("Empresa Orden")]
        [StringLength(50)]
        public string generateempresaorden { get; set; }

        [DisplayName("Fecha Solicitud")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yy}")]
        public string fsolicitudorden { get; set; }

        [DisplayName("Fecha Entrega")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yy}")]
        public string fentregaorden { get; set; }

        [Required]
        [DisplayName("Responsable")]
        [StringLength(50)]
        public string responsableorden { get; set; }


        [Required]
        [DisplayName("Telefono Responsable")]
        [StringLength(50)]
        public string telefonoresponsableorden { get; set; }


        [DisplayName("Tipo Usuario")]
        [StringLength(50)]
        public string tipousuarioorden { get; set; }


        [Required]
        [DisplayName("Usuario")]
        [StringLength(50)]
        public string equipousuarioorden { get; set; }


        [Required]
        [DisplayName("Telefono")]
        [StringLength(50)]
        public string telefonousuarioorden { get; set; }

        [DisplayName("En red")]
        [StringLength(50)]
        public string redequipoorden { get; set; }


        [Required]
        [DisplayName("Ubicación")]
        [StringLength(50)]
        public string ubicacionequipoorden { get; set; }

        [DisplayName("Observaciones")]
        [StringLength(50)]
        public string Observacionesorden { get; set; }

        [DisplayName("OS-OC")]
        [StringLength(50)]
        public string ordenservicio { get; set; }

        [DisplayName("RQ")]
        [StringLength(50)]
        public string rqservicio { get; set; }

        [DisplayName("Ajunto")]
        [StringLength(50)]
        public string adjuntoorden { get; set; }


        [DisplayName("Aprobador RQ-OS-OC")]
        [StringLength(50)]
        public string aprobadorrq { get; set; }

        [DisplayName("Correo")]
        [StringLength(50)]
        public string correoaprobador { get; set; }

        [DisplayName("Motivo")]
        [StringLength(50)]
        public string motivorenting { get; set; }

        [DisplayName("Contrato Marco")]
        [StringLength(50)]
        public string contratomarco { get; set; }


        [DisplayName("Tipo Cliente")]
        [StringLength(50)]
        public string tipocliente { get; set; }


        [DisplayName("Grupo")]
        [StringLength(50)]
        public string grupoeconomico { get; set; }



        [DisplayName("Fecha Inicio")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yy}")]
        public string rentinginicio { get; set; }



        [DisplayName("Fecha Fin")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yy}")]
        public string rentingfin { get; set; }


        [Required]
        [DisplayName("Hardware")]
        [StringLength(50)]
        public string hardwaredevice { get; set; }


        [Required]
        [DisplayName("Cantidad")]
        [StringLength(50)]
        public string cantidadhardware { get; set; }

        [Required]
        [DisplayName("Tipo Hardware")]
        [StringLength(50)]
        public string tipohardware { get; set; }

        [DisplayName("Sofware Adicional")]
        [StringLength(50)]
        public string sofwareorden { get; set; }


        [DisplayName("Estado Orden")]
        [StringLength(50)]
        public string estadoorden { get; set; }

        [DisplayName("Atencion")]
        [StringLength(50)]
        public string tipoatencionorden { get; set; }


        //PARA LA FACTURACION

        [DisplayName("Factura")]
        public string factura { get; set; }


        [DisplayName("Fecha Emision")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yy}")]
        public string ftemision { get; set; }


        [DisplayName("Produccion")]
        public int produccion { get; set; }





        public virtual ICollection<DetalleOrden> DetalleOrden { get; set; }


        public virtual ICollection<mesServicio> mesServicio { get; set; }


        //public Orden ObtenerOrden(int relacion, string valor)
        //{
        //    var dato = new Orden();

        //    try
        //    {
        //        using (var ctx = new ProyectoContext())
        //        {
        //            dato = ctx.Orden.Where(x => x.idorden == relacion)
        //                                .Where(x => x.numeroorden == valor)
        //                                .SingleOrDefault();
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //    return dato;
        //}


        public Orden ObtenerVerorden(int id)
        {
            var orden = new Orden();

            try
            {
                using (var ctx = new ProyectoContext())
                {
                    orden = ctx.Orden.Where(x => x.idorden == id)
                                       .SingleOrDefault();

                    //orden = ctx.Orden.Include("OrdenDetalle")
                    //                   .Include("OrdenDetalle.Inventario")
                    //                   .Where(x => x.idorden == id)
                    //                   .SingleOrDefault();
                }
            }
            catch (Exception E)
            {

                throw;
            }

            return orden;
        }

        public List<Orden> ListarOrden()
        {
            var listaorden = new List<Orden>();

            try
            {
                using (var ctx = new ProyectoContext())
                {
                    listaorden = ctx.Orden.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return listaorden;
        }








        public AnexGRIDResponde Listar(AnexGRID grid)
        {
            try
            {
                using (var ctx = new ProyectoContext())
                {
                    grid.Inicializar();

                    var query = ctx.Orden.Where(x => x.idorden > 0);

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

  

        public Orden Obtener(int id)
        {
            var orden = new Orden();

            try
            {
                using (var ctx = new ProyectoContext())
                {
                    orden = ctx.Orden.Where(x => x.idorden == id)
                                       .SingleOrDefault();
                }
            }
            catch (Exception E)
            {

                throw;
            }

            return orden;
        }

        public ResponseModel Guardar()
        {
            var rm = new ResponseModel();

            try
            {
                using (var ctx = new ProyectoContext())
                {
                    if (this.idorden > 0)
                    {
                        ctx.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        ctx.Entry(this).State = EntityState.Added;
                    }

                    rm.SetResponse(true);
                    ctx.SaveChanges();
                }
            }
            catch (Exception E)
            {
                throw;
            }

            return rm;
        }

        public void Eliminar()
        {
            try
            {
                using (var ctx = new ProyectoContext())
                {
                    ctx.Entry(this).State = EntityState.Deleted;
                    ctx.SaveChanges();
                }
            }
            catch (Exception E)
            {

                throw;
            }
        }






    }
}
