namespace Model
{
      using Helper;
    using System;

    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;

    using System.Data.Entity.Validation;
    using System.IO;
    using System.Linq;
    using System.Web;

   
    using System.Collections.Generic;


  


    [Table("Usuario")]
    public partial class Usuario
    {




        public Usuario()
        {

            //Empresa = new HashSet<Empresa>();
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idusuario { get; set; }
   
        [Required]
        [DisplayName("Nombre")]
        [StringLength(50)]
        public string nombre { get; set; }


        [Required]
        [DisplayName("Correo")]
        [StringLength(50)]
        public string correo { get; set; }


     
        [DisplayName("Contraseña")]
        [StringLength(50)]
        public string clave { get; set; }


        [Required]
        [DisplayName("Telefono")]
        [StringLength(15)]
        public string telefono { get; set; }


        //public int Empresa_Id { get; set; }

        [Required]
        [DisplayName("Empresa")]
        [StringLength(200)]
        public string razonsocial { get; set; }

        [Required]
        [DisplayName("Cuenta")]
        [StringLength(200)]
        public string cuenta { get; set; }



        [DisplayName("Foto")]
        [StringLength(100)]
        public string foto { get; set; }



        [Required]
        [DisplayName("Estado")]
        public bool activo { get; set; }

    


        //PARA HACER MODIFICACION DEL PERFIL
        //public int Conteo()
        //{
        //    using (var ctx = new ProyectoContext())
        //    {
        //        return ctx.Usuario.Count();
        //    }
        //}

        public ResponseModel Acceder(string cuenta, string clave)
        {
            var rm = new ResponseModel();

            try
            {
                using (var ctx = new ProyectoContext())
                {
                    clave = HashHelper.MD5(clave);

                    var usuario = ctx.Usuario.Where(x => x.cuenta == cuenta)
                                             .Where(x => x.clave == clave)
                                             .SingleOrDefault();

                    if (usuario != null)
                    {
                        SessionHelper.AddUserToSession(usuario.idusuario.ToString());
                        rm.SetResponse(true);
                    }
                    else
                    {
                        rm.SetResponse(false, "cuenta o contraseña incorrecta");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return rm;
        }

        public Usuario ObtenerPerfil(int id, bool includes = false)
        {
            var usuario = new Usuario();

            try
            {
                using (var ctx = new ProyectoContext())
                {
                    if (!includes)
                    {
                        usuario = ctx.Usuario.Where(x => x.idusuario == id)
                                             .SingleOrDefault();
                    }
                    else
                    {
                        usuario = ctx.Usuario.Where(x => x.idusuario == id)
                                             .SingleOrDefault();
                    }

                 //   Extraendo y Agregando El Cmapo Empresa
                    //usuario.miempresa = new Empresa().ObtenerEmpresa(id, usuario.Empresa_Id.ToString());


                }
            }
            catch (Exception ex)
            {
               string errorusuario = ex.Message;
                  throw;
            }

            return usuario;
        }

        public ResponseModel GuardarPerfil(HttpPostedFileBase foto)
        {
            var rm = new ResponseModel();

            try
            {
                using (var ctx = new ProyectoContext())
                {
                    ctx.Configuration.ValidateOnSaveEnabled = false;

                    var eUsuario = ctx.Entry(this);
                    eUsuario.State = EntityState.Modified;

                    // Campos que queremos ignorar
                    if (foto != null)
                    {
                        // Nombre del archivo, es decir, lo renombramos para que no se repita nunca
                        string archivo = DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(foto.FileName);

                        // La ruta donde lo vamos guardar
                        foto.SaveAs(HttpContext.Current.Server.MapPath("~/Areas/admin/img/" + archivo));

                        // Establecemos en nuestro modelo el nombre del archivo
                        this.foto = archivo;
                    }
                    else eUsuario.Property(x => x.foto).IsModified = false;

                    if (this.clave == null) eUsuario.Property(x => x.clave).IsModified = false;

                    ctx.SaveChanges();

                    rm.SetResponse(true);
                }
            }


            catch (DbEntityValidationException e)
            {
                throw;
            }
            catch (Exception)
            {

                throw;
            }

            return rm;
        }


        public AnexGRIDResponde Listar(AnexGRID grid)
        {
            try
            {
                using (var ctx = new ProyectoContext())
                {
                    grid.Inicializar();

                    var query = ctx.Usuario.Where(x => x.idusuario > 0);

                    // Ordenamiento
                    if (grid.columna == "id")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.idusuario)
                                                             : query.OrderBy(x => x.idusuario);
                    }

                    if (grid.columna == "nombre")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.nombre)
                                                             : query.OrderBy(x => x.nombre);
                    }

                    if (grid.columna == "correo")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.correo)
                                                             : query.OrderBy(x => x.correo);
                    }
                    if (grid.columna == "cuenta")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.cuenta)
                                                             : query.OrderBy(x => x.cuenta);
                    }

                    if (grid.columna == "razonsocial")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.razonsocial)
                                                             : query.OrderBy(x => x.razonsocial);
                    }


                    if (grid.columna == "activo")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.activo)
                                                             : query.OrderBy(x => x.activo);
                    }

                    var usuario = query.Skip(grid.pagina)
                                       .Take(grid.limite)
                                       .ToList();

                    var total = query.Count();

                    grid.SetData(
                        from a in usuario
                        select new
                        {
                            a.idusuario,
                            a.nombre,
                            a.correo,
                            a.cuenta,
                            a.razonsocial,
                            a.activo
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



        public Usuario Obtener(int id)
        {
            var usuario = new Usuario();

            try
            {
                using (var ctx = new ProyectoContext())
                {
                    usuario = ctx.Usuario.Where(x => x.idusuario == id)
                                       .SingleOrDefault();
                }
            }
            catch (Exception E)
            {

                throw;
            }

            return usuario;
        }

        public ResponseModel Guardar()
        {
            var rm = new ResponseModel();

            try
            {
                using (var ctx = new ProyectoContext())
                {
                    if (this.idusuario > 0)
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
