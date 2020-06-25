

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

    [Table("Servicio")]
    public class Servicio
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idservicio { get; set; }


       
        [DisplayName("os")]
        [StringLength(60)]
        public string os { get; set; }

        [DisplayName("Fecha Os")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yy}")]
        public string fechaos { get; set; }

        [DisplayName("rq")]
        [StringLength(60)]
        public string rq { get; set; }


        [DisplayName("aprobador")]
        [StringLength(60)]
        public string aprobador { get; set; }

        [DisplayName("Correo Aprobador")]
        [StringLength(60)]
        public string correoaprobador { get; set; }

        [DisplayName("Estado")]
        public int estadoos { get; set; }

        

        

        public virtual ICollection  < mesServicio> mesServicio { get; set; }

        public Servicio()
        {
            mesServicio = new HashSet<mesServicio>();
        }


        public Servicio Obtener(int id)
        {
            var servicio = new Servicio();

            try
            {
                using (var ctx = new ProyectoContext())
                {
                    servicio = ctx.Servicio.Where(x => x.idservicio == id)
                                       .SingleOrDefault();
                }
            }
            catch (Exception E)
            {

                throw;
            }

            return servicio;
        }

        public ResponseModel Guardar()
        {
            var rm = new ResponseModel();

            Servicio serv = new Servicio();

            try
            {
                using (var ctx = new ProyectoContext())
                {
                    if (this.idservicio > 0)
                    {
                        ctx.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        ctx.Entry(this).State = EntityState.Added;
                        //var idultimo = 
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

    }
}
