

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

    [Table("mesServicio")]
    public class mesServicio
    {

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idServicioMes { get; set; }



        [Key]
        [Column(Order = 1)]
        public int idServicio { get; set; }

        [Key]
        [Column(Order = 2)]
        public int idorden { get; set; }


        [DisplayName("meses")]
        [StringLength(10)]
        public string meses { get; set; }

        [DisplayName("estado")]
        public int estado { get; set; }

        public virtual Orden Orden { get; set; }

        public virtual Servicio Servicio { get; set; }



        public mesServicio Obtener(int id)
        {
            var messervicio = new mesServicio();

            try
            {
                using (var ctx = new ProyectoContext())
                {
                    messervicio = ctx.mesServicio.Where(x => x.idServicioMes == id)
                                       .SingleOrDefault();
                }
            }
            catch (Exception E)
            {

                throw;
            }

            return messervicio;
        }

        public ResponseModel Guardar()
        {
            var rm = new ResponseModel();

           

            try
            {
                using (var ctx = new ProyectoContext())
                {
                    if (this.idServicioMes > 0)
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







        public  class MesSinOS
        {
         

            public int JS_orden_id { get; set; }
            public string JS_codigoorden { get; set; }
            public int JS_cantidad { get; set; }


        }


        public virtual List<MesSinOS> get_ListarOrdenesSinMes()
        {
            using (var ctx = new ProyectoContext())
            {
                return ctx.Database.SqlQuery<MesSinOS>("RRR_Select_Procesos_sin_mes_asignado").ToList();
            }

        }




    }
}
