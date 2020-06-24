

namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.SqlClient;
    using System.ComponentModel.DataAnnotations;

    public class Facturacion
    {

        public string referencia { get; set; }

        public string empresa { get; set; }
        public string grupoeconomico { get; set; }
        public string refacturable { get; set; }
        public string ordenservicio { get; set; }
        public string fechaordenservicio { get; set; }
        public string rqcliente { get; set; }
        public string procesos { get; set; }
        public string fechainicio { get; set; }
        public string fechafin { get; set; }
        public string sucursal { get; set; }
        public string contratointerno { get; set; }
        public string ruccliente { get; set; }
        public string cliente { get; set; }

        public string tipo { get; set; }

        [DisplayFormat(DataFormatString = "{0:#.##}")]
        public decimal valor { get; set; }
        public int cantidad { get; set; }

        [DisplayFormat(DataFormatString = "{0:#.##}")]
        public decimal neto { get; set; }

        [DisplayFormat(DataFormatString = "{0:#.##}")]
        public decimal igv { get; set; }

        [DisplayFormat(DataFormatString = "{0:#.##}")]
        public decimal total { get; set; }
        public string idplus { get; set; }
        public string numerodocumento { get; set; }

        public virtual List<Facturacion> Get_factuacion(string mes, string empresa)
        {


            var ctx = new ProyectoContext();
            //SqlParameter param1 = new SqlParameter("@MES", mes);
            //SqlParameter param2 = new SqlParameter("@EMPRESA", empresa);
            return ctx.Database.SqlQuery<Facturacion>("Rpt_detalle_facturacion @MES, @EMPRESA", new Object[]
                {new SqlParameter ("@MES",mes ), new SqlParameter("@EMPRESA",empresa)}).ToList();


            
        }

        
    }
}
