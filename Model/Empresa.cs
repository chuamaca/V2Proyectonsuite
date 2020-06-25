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


    [Table("Empresa")]
    public class Empresa
    {

        public Empresa()
        {
            Sucursal = new HashSet<Sucursal>();
            Cliente = new HashSet<Cliente>();
        }



        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idempresa { get; set; }

        [Required]
        [DisplayName("Razon Social")]
        [StringLength(60)]
        public string nmempresa { get; set; }


        [Required]
        [DisplayName("R.U.C")]
        [StringLength(11, MinimumLength = 8)]
        public string rucempresa { get; set; }


        [Required]
        [DisplayName("Direccion")]
        [StringLength(100)]
        public string dirempresa { get; set; }


        [Required]
        [DisplayName("Correo")]
        [StringLength(30)]
        public string correoempresa { get; set; }

        [Required]
        [DisplayName("Telefono")]
        [StringLength(15)]
        public string telefonoempresa { get; set; }



        [DisplayName("Logo")]
        [StringLength(32)]
        public string logoempresa { get; set; }



        [DisplayName("Observacion")]
        [StringLength(100)]
        public string obsempresa { get; set; }



        [DisplayName("Estado")]

        public int estadoempresa { get; set; }


        public virtual ICollection<Sucursal> Sucursal { get; set; }

        public virtual ICollection<Cliente> Cliente { get; set; }

        public Empresa ObtenerEmpresa(int relacion, string valor)
        {
            var dato = new Empresa();

            try
            {
                using (var ctx = new ProyectoContext())
                {
                    dato = ctx.Empresa.Where(x => x.idempresa == relacion)
                                        .Where(x => x.nmempresa == valor)
                                        .SingleOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return dato;
        }


        public List<Empresa> ListarEmpresa()
        {
            var listaempresa = new List<Empresa>();

            try
            {
                using (var ctx = new ProyectoContext())
                {
                    listaempresa = ctx.Empresa.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return listaempresa;
        }


        public AnexGRIDResponde Listar(AnexGRID grid)
        {
            try
            {
                using (var ctx = new ProyectoContext())
                {
                    grid.Inicializar();

                    var query = ctx.Empresa.Where(x => x.idempresa > 0);

                    // Ordenamiento
                    if (grid.columna == "id")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.idempresa)
                                                             : query.OrderBy(x => x.idempresa);
                    }

                    if (grid.columna == "nmempresa")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.nmempresa)
                                                             : query.OrderBy(x => x.nmempresa);
                    }

                    if (grid.columna == "rucempresa")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.rucempresa)
                                                             : query.OrderBy(x => x.rucempresa);
                    }

                    if (grid.columna == "estadoempresa")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.estadoempresa)
                                                             : query.OrderBy(x => x.estadoempresa);
                    }

                    var empresa = query.Skip(grid.pagina)
                                       .Take(grid.limite)
                                       .ToList();

                    var total = query.Count();

                    grid.SetData(
                        from a in empresa
                        select new
                        {
                            a.idempresa,
                            a.nmempresa,
                            a.rucempresa,
                            a.estadoempresa
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

        public Empresa Obtener(int id)
        {
            var empresa = new Empresa();

            try
            {
                using (var ctx = new ProyectoContext())
                {
                    empresa = ctx.Empresa.Where(x => x.idempresa == id)
                                       .SingleOrDefault();
                }
            }
            catch (Exception E)
            {

                throw;
            }

            return empresa;
        }

        public ResponseModel Guardar()
        {
            var rm = new ResponseModel();

            try
            {
                using (var ctx = new ProyectoContext())
                {
                    if (this.idempresa > 0)
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
