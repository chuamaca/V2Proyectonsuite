namespace Model
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.SqlClient;


    public class HardwareInfo
    {

        public int idhware { get; set; }
        public string codigontb { get; set; }
        public string typedevice { get; set; }
        public string seriehw { get; set; }
        public string nmbrand { get; set; }
        public string nmmodel { get; set; }
        public string partnumberhw { get; set; }
        public string snbatery { get; set; }
        public string sncharger { get; set; }
        public string nmprocessor { get; set; }
        public string ghzprocessor { get; set; }
        public string mcapacity { get; set; }
        public string capacitystorage { get; set; }
        public string lic { get; set; }
        public string nmequipo { get; set; }
        public string obshw { get; set; }
        public string sthw { get; set; }

        //PROCEDIMEINTO ALMACENADO PARA HACER CONSULTA DE HARWARE DETALLE CON PARAMETROS
        public virtual List<HardwareInfo> GetHardwareDetail(int idhardware = 0)
        {
            var ctx = new ProyectoContext();
            SqlParameter param1 = new SqlParameter("@idhardware", idhardware);
            return ctx.Database.SqlQuery<HardwareInfo>("SP_NSUITE_hardware_Select @idhardware", param1).ToList();
        }

    }
}
