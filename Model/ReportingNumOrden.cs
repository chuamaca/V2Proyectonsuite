

namespace Model
{


    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.SqlClient;
    public class ReportingNumOrden
    {  
       
        public string numeroorden { get; set; }
        public virtual List<ReportingNumOrden> GetRPT_numeroorden_por_id(int idorden)
        {
            var ctx = new ProyectoContext();
                SqlParameter param1 = new SqlParameter("@idorden", idorden);
            return ctx.Database.SqlQuery<ReportingNumOrden>("RPT_orden_por_id @idorden", param1).ToList();
        }
    }
}
