

namespace Model
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Hardware")]
    public partial class Hardware
    {
        public Hardware()
        {
            DetalleOrden = new HashSet<DetalleOrden>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idhw { get; set; }

        [StringLength(10)]
        public string codigontb { get; set; }

        [StringLength(60)]
        [DisplayName("SERIE")]
        public string seriehw { get; set; }

        [StringLength(30)]
        public string partnumberhw { get; set; }

        public DateTime fgarantiahw { get; set; }

        public DateTime fregistrohw { get; set; }

        [StringLength(10)]
        public string typedevice { get; set; }

        [StringLength(30)]
        public string nmequipo { get; set; }

        public int iddevice { get; set; }

        public int idbrand { get; set; }

        public int idmodel { get; set; }

        public int iddetailhw { get; set; }

        public int idstatusdevice { get; set; }

        [StringLength(100)]
        public string obshw { get; set; }

        public int sthw { get; set; }

       
        public string docref { get; set; }

        public virtual ICollection<DetalleOrden> DetalleOrden { get; set; }

        public List<Hardware> Todos(int orden_id = 0)
        {
            var inventario = new List<Hardware>();

            try
            {
                using (var ctx = new ProyectoContext())
                {
                    if (orden_id > 0)
                    {
                        var equipo_tomados = ctx.DetalleOrden.Where(x => x.Orden_Id == orden_id)
                                                            
                                                            .Select(x => x.Hardware_Id)
                                                            .ToList();

                        //inventario = ctx.Hardware.Where(x=>x.idstatusdevice==1)
                        //                         .Where(x => !equipo_tomados.Contains(x.idhw))
                        //                         .ToList();

                        inventario = ctx.Hardware.Where(x => x.idstatusdevice == 1)
                                                 .ToList();
                    }
                    else
                    {
                        inventario = ctx.Hardware.Where(x => x.idstatusdevice == 1)
                                                 .ToList();
                    }

                    // Forma más sencilla
                    /*cursos = ctx.Database.SqlQuery<Curso>("SELECT c.* FROM Curso c WHERE id NOT IN (SELECT Curso_id FROM AlumnoCurso ac WHERE ac.Curso_id = c.id AND ac.Alumno_id = @Alumno_id)", new SqlParameter("Alumno_id", Alumno_id))
                                .ToList();*/
                }
            }
            catch (Exception)
            {

                throw;
            }

            return inventario;
        }


    }
}
