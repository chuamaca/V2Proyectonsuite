
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
    [Table("Sucursal")]
    public class Sucursal
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idsucursal { get; set; }

        [StringLength(100)]
        public string nmsucursal { get; set; }

        [StringLength(20)]
        public string codigosuc { get; set; }

        [StringLength(100)]
        public string direccionsuc { get; set; }

        [StringLength(20)]
        public string telefonosuc { get; set; }

        [StringLength(100)]
        public string otroscu { get; set; }

        [StringLength(100)]
        public string observacionsuc { get; set; }

        public int estadosuc { get; set; }

        public int empresa_id { get; set; }

        public virtual Empresa Empresa { get; set; }





        public List<Sucursal> ListarSucursal(int id_empre)
        {
            var listasucursal = new List<Sucursal>();
            try
            {
                using (var ctx = new ProyectoContext())
                {
                    listasucursal = ctx.Sucursal.Include("Empresa")
                                                .Where(x => x.empresa_id == id_empre).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return listasucursal;
        }




        public AnexGRIDResponde Listar(AnexGRID grid)
        {
            try
            {
                using (var ctx = new ProyectoContext())
                {
                    grid.Inicializar();

                    var query = ctx.Sucursal.Where(x => x.idsucursal > 0);

                    if (grid.columna == "id")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.idsucursal)
                                                             : query.OrderBy(x => x.idsucursal);
                    }

                    if (grid.columna == "codigosuc")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.codigosuc)
                                                             : query.OrderBy(x => x.codigosuc);
                    }

                    if (grid.columna == "nmsucursal")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.nmsucursal)
                                                             : query.OrderBy(x => x.nmsucursal);
                    }

                    if (grid.columna == "otroscu")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.otroscu)
                                                             : query.OrderBy(x => x.otroscu);
                    }

                    if (grid.columna == "estadosuc")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.estadosuc)
                                                             : query.OrderBy(x => x.estadosuc);
                    }

                    var sucursal = query.Skip(grid.pagina)
                                       .Take(grid.limite)
                                       .ToList();

                    var total = query.Count();

                    grid.SetData(
                        from a in sucursal
                        select new
                        {
                            a.idsucursal,
                            a.codigosuc,
                            a.nmsucursal,
                            a.otroscu,
                            a.estadosuc
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

        public Sucursal Obtener(int id)
        {
            var sucursal = new Sucursal();

            try
            {
                using (var ctx = new ProyectoContext())
                {
                    sucursal = ctx.Sucursal.Where(x => x.idsucursal == id)
                                       .SingleOrDefault();
                }
            }
            catch (Exception E)
            {

                throw;
            }

            return sucursal;
        }

        public ResponseModel Guardar()
        {
            var rm = new ResponseModel();

            try
            {
                using (var ctx = new ProyectoContext())
                {
                    if (this.idsucursal > 0)
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


