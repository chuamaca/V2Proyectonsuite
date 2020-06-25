

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

    [Table("Cliente")]


    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idcliente { get; set; }


   

        [Required]
        [DisplayName("Razon Social")]
        [StringLength(60)]
        public string nmcliente { get; set; }


        [Required]
        [DisplayName("R.U.C")]
        [StringLength(11, MinimumLength = 8)]
        public string ruccliente { get; set; }


        [Required]
        [DisplayName("Direccion")]
        [StringLength(100)]
        public string dircliente { get; set; }


        [Required]
        [DisplayName("Correo")]
        [StringLength(30)]
        public string correocliente { get; set; }

        [Required]
        [DisplayName("Telefono")]
        [StringLength(15)]
        public string telefonocliente { get; set; }



        [DisplayName("Logo")]
        [StringLength(32)]
        public string logocliente { get; set; }



        [DisplayName("Observacion")]
        [StringLength(100)]
        public string obscliente { get; set; }



        [DisplayName("Estado")]

        public int estadocliente { get; set; }

        public int empresa_id { get; set; }
        public virtual Empresa Empresa { get; set; }


        //public List<Cliente> GetCliente(string nmcliente)
        //{
        //    var dato = new Cliente();

        //    try
        //    {
        //        using (var ctx = new ProyectoContext())
        //        {
        //            dato = ctx.Cliente.Where(x => x.nmcliente.Contains(nmcliente))
        //                                   .Select(x => x.nmcliente).Take(5).ToList();
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //    return dato;
        //}

        public Cliente ObtenerCliente(int relacion, string valor)
        {
            var dato = new Cliente();

            try
            {
                using (var ctx = new ProyectoContext())
                {
                    dato = ctx.Cliente.Where(x => x.idcliente == relacion)
                                        .Where(x => x.nmcliente == valor)
                                        .SingleOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return dato;
        }


        public List<Cliente> ListarCliente()
        {
            var listacliente = new List<Cliente>();

            try
            {
                using (var ctx = new ProyectoContext())
                {
                    listacliente = ctx.Cliente.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return listacliente;
        }

        public AnexGRIDResponde Listar(AnexGRID grid)
        {
            try
            {
                using (var ctx = new ProyectoContext())
                {
                    grid.Inicializar();

                    var query = ctx.Cliente.Where(x => x.idcliente > 0);

                    // Ordenamiento
                    if (grid.columna == "id")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.idcliente)
                                                             : query.OrderBy(x => x.idcliente);
                    }

                    if (grid.columna == "nmcliente")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.nmcliente)
                                                             : query.OrderBy(x => x.nmcliente);
                    }

                    if (grid.columna == "ruccliente")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.ruccliente)
                                                             : query.OrderBy(x => x.ruccliente);
                    }

                    if (grid.columna == "empresa_id")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.empresa_id)
                                                             : query.OrderBy(x => x.empresa_id);
                    }

                    if (grid.columna == "estadocliente")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.estadocliente)
                                                             : query.OrderBy(x => x.estadocliente);
                    }

                    var cliente = query.Skip(grid.pagina)
                                       .Take(grid.limite)
                                       .ToList();

                

                    var total = query.Count();

                    grid.SetData(
                        from a in cliente 
                        select new
                        {
                            a.idcliente,
                            a.nmcliente,
                            a.ruccliente,
                           a.empresa_id,
                            a.estadocliente
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



        public Cliente Obtener(int id)
        {
            var cliente = new Cliente();

            try
            {
                using (var ctx = new ProyectoContext())
                {
                    cliente = ctx.Cliente.Where(x => x.idcliente == id)
                                       .SingleOrDefault();
                }
            }
            catch (Exception E)
            {

                throw;
            }

            return cliente;
        }

        public ResponseModel Guardar()
        {
            var rm = new ResponseModel();

            try
            {
                using (var ctx = new ProyectoContext())
                {
                    if (this.idcliente > 0)
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
