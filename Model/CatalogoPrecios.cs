

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

    [Table("CatalogoPrecios")]
    public class CatalogoPrecios
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idCatalogoPrecio { get; set; }

        [DisplayName("Nombre")]
        [StringLength(30)]
        public string nombre { get; set; }

        [DisplayName("caracteristicas")]
        [StringLength(30)]
        public string caracteristicas { get; set; }

        [DisplayName("precio")]
        [StringLength(30)]
        public string precio { get; set; }

        [DisplayName("otros")]
        [StringLength(30)]
        public string otros { get; set; }

        [DisplayName("empresa")]
        [StringLength(30)]
        public string empresa { get; set; }

        [DisplayName("estado")]
        [StringLength(30)]
        public string estado { get; set; }

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


        public List<CatalogoPrecios> ListarCatalogoPorEmpresa(string nombreempresa)
        {
            var catalogo = new List<CatalogoPrecios>();
            try
            {
                using (var ctx = new ProyectoContext())
                {
                    catalogo = ctx.CatalogoPrecios.Where(p => p.empresa == nombreempresa).Distinct().ToList();
                }
            }
            catch (Exception E)
            {

                throw;
            }

            return catalogo;
        }



        //para lado CLIENTE




        public List<CatalogoPrecios> ListarCatalogoPorEmpresaTipo(string nombreempresa, string tipo)
        {
            var catalogo = new List<CatalogoPrecios>();
            try
            {
                using (var ctx = new ProyectoContext())
                {
                    catalogo = ctx.CatalogoPrecios.Where(p => p.empresa == nombreempresa && p.nombre==tipo).ToList();
                }
            }
            catch (Exception E)
            {

                throw;
            }

            return catalogo;
        }


        public List<CatalogoPrecios> ListarCatalogoPorEmpresayTipo(string nombreempresa, string tipo, string caracteristicas)
        {
            var catalogo = new List<CatalogoPrecios>();
            try
            {
                using (var ctx = new ProyectoContext())
                {
                    catalogo = ctx.CatalogoPrecios.Where(p => p.empresa == nombreempresa && p.nombre ==tipo && p.caracteristicas==caracteristicas).ToList();
                }
            }
            catch (Exception E)
            {

                throw;
            }

            return catalogo;
        }




        //CRUD


        public AnexGRIDResponde Listar(AnexGRID grid)
        {
            try
            {
                using (var ctx = new ProyectoContext())
                {
                    grid.Inicializar();

                    var query = ctx.CatalogoPrecios.Where(x => x.idCatalogoPrecio > 0);

                    // Ordenamiento
                    if (grid.columna == "id")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.idCatalogoPrecio)
                                                             : query.OrderBy(x => x.idCatalogoPrecio);
                    }

                    if (grid.columna == "nombre")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.nombre)
                                                             : query.OrderBy(x => x.nombre);
                    }

                    if (grid.columna == "caracteristicas")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.caracteristicas)
                                                             : query.OrderBy(x => x.caracteristicas);
                    }

                    if (grid.columna == "precio")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.precio)
                                                             : query.OrderBy(x => x.precio);
                    }

                    if (grid.columna == "otros")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.otros)
                                                             : query.OrderBy(x => x.otros);
                    }

                    if (grid.columna == "empresa")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.empresa)
                                                             : query.OrderBy(x => x.empresa);
                    }

                    if (grid.columna == "estado")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.estado)
                                                             : query.OrderBy(x => x.estado);
                    }

                    var catalogoprecios = query.Skip(grid.pagina)
                                       .Take(grid.limite)
                                       .ToList();

                    var total = query.Count();

                    grid.SetData(
                        from a in catalogoprecios
                        select new
                        {
                            a.idCatalogoPrecio,
                            a.nombre,
                            a.caracteristicas,
                            a.precio,
                            a.otros,
                            a.empresa,
                            a.estado,
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

        public CatalogoPrecios Obtener(int id)
        {
            var catalogoprecios = new CatalogoPrecios();

            try
            {
                using (var ctx = new ProyectoContext())
                {
                    catalogoprecios = ctx.CatalogoPrecios.Where(x => x.idCatalogoPrecio == id)
                                       .SingleOrDefault();
                }
            }
            catch (Exception E)
            {

                throw;
            }

            return catalogoprecios;
        }

        public ResponseModel Guardar()
        {
            var rm = new ResponseModel();

            try
            {
                using (var ctx = new ProyectoContext())
                {
                    if (this.idCatalogoPrecio > 0)
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
