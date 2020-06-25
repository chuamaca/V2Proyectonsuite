namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;



    [Table("DetalleOrden")]
    public class DetalleOrden
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int iddetalleorden { get; set; }

        public int Orden_Id { get; set; }

        public int Hardware_Id { get; set; }

        [DisplayName("ORDEN DETALLE")]
        public string seriedt { get; set; }


        [DisplayName("USUARIO")]
        public string usuariof { get; set; }


        [DisplayName("TELEFONO")]
        public string telefonof { get; set; }

        [DisplayName("UBICACION")]
        public string ubicacion { get; set; }


        [DisplayName("CABLE")]
        public string cableseg { get; set; }

        [DisplayName("MOUSE")]
        public string mouse { get; set; }

        [DisplayName("MALETIN")]
        public string maleta { get; set; }


        [DisplayName("OTROS ACC.")]
        public string accesorio { get; set; }



        [DisplayName("VALOR")]
        [DisplayFormat(DataFormatString = "{0:#.##}")]
        public decimal valor { get; set; }

        [DisplayName("IGV")]
        [DisplayFormat(DataFormatString = "{0:#.##}")]
        public decimal IGV { get; set; }
        

        [DisplayName("TOTAL")]
        [DisplayFormat(DataFormatString = "{0:#.##}")]
        public decimal total { get; set; }




        [DisplayName("OBSERVACION")]
        public string obscambio { get; set; }


        [DisplayName("ESTADO")]
        public int estadodetalleorden { get; set; }


        [DisplayName("Fecha Registro")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yy}")]
        public string fregistro { get; set; }

        [DisplayName("GUIA REMISION")]
        public string gremision { get; set; }

        [DisplayName("GUIA RECEPCION")]
        public string grecepcion { get; set; }


        [DisplayName("CODIGO")]
        public string codigontb { get; set; }

        [DisplayName("TIPO")]
        public string typedevice { get; set; }

        [DisplayName("SERIE")]
        public string seriehw { get; set; }

        [DisplayName("MARCA")]
        public string nmbrand { get; set; }

        [DisplayName("MODELO")]
        public string nmmodel { get; set; }

        [DisplayName("P/N")]
        public string partnumberhw { get; set; }

        [DisplayName("BATERIA")]
        public string snbatery { get; set; }

        [DisplayName("CARGADOR")]
        public string sncharger { get; set; }

        [DisplayName("PROCESADOR")]
        public string nmprocessor { get; set; }

        [DisplayName("GHZ")]
        public string ghzprocessor { get; set; }

        [DisplayName("RAM")]
        public string mcapacity { get; set; }

        [DisplayName("DISCO DURO")]
        public string capacitystorage { get; set; }

        [DisplayName("LICENCIAS")]
        public string lic { get; set; }

        [DisplayName("HOSTNAME")]
        public string nmequipo { get; set; }

        [DisplayName("OBSERVACIONES")]
        public string obshw { get; set; }

        [DisplayName("SE FACTURA")]
        public string sefacturo { get; set; }

        [DisplayName("TIPO HW/SW")]
        public string tipohardwareestado { get; set; }


        [DisplayName("DESC. HW-SW")]
        public string descripciontipohardwareestado { get; set; }

        [DisplayName("MONEDA")]
        public string moneda { get; set; }

        [DisplayName("IDENTIFICADOR")]
        public string identificador { get; set; }


        public virtual Hardware Hardware { get; set; }
        public virtual Orden Orden { get; set; }


        public ResponseModel Guardar()
        {
            var rm = new ResponseModel();
            try
            {
                using (var ctx = new ProyectoContext())
                {
                    ctx.Entry(this).State = EntityState.Added;

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

        public List<DetalleOrden> Listar(int orden_id)
        {
            var detalleorden = new List<DetalleOrden>();
            try
            {
                using (var ctx = new ProyectoContext())
                {
                    detalleorden = ctx.DetalleOrden.Include("Hardware")
                                                  .Where(x => x.Orden_Id == orden_id)
                                                  .ToList();
                }
            }
            catch (Exception E)
            {

                throw;
            }

            return detalleorden;
        }

    }
}
