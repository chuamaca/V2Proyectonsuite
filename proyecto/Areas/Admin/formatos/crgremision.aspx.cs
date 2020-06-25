using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

using proyecto.Areas.Admin.Filters;

namespace proyecto.Areas.Admin.formatos
{
    [Autenticado]
    public partial class crgremision : System.Web.UI.Page
    {

        rpt_gremision formatogremision = new rpt_gremision();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                string viewgremision = Request.QueryString["idorden"].ToString();

                formatogremision.SetDatabaseLogon(user: "sa", password: "**N3t.2019");
                formatogremision.VerifyDatabase();
                formatogremision.Refresh();
                formatogremision.SetParameterValue("@idorden", viewgremision);
                CrystalReportViewer1.ReportSource = formatogremision;

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string idorden = Request.QueryString["idorden"].ToString();
            formatogremision.SetDatabaseLogon(user: "sa", password: "**N3t.2019");
            formatogremision.VerifyDatabase();
            formatogremision.Refresh();
            formatogremision.SetParameterValue("@idorden", idorden);
            CrystalReportViewer1.ReportSource = formatogremision;

            ExportFormatType formatType = ExportFormatType.NoFormat;
            formatType = ExportFormatType.PortableDocFormat;
            formatogremision.ExportToHttpResponse(formatType, Response, true, idorden);
          //  formatogremision.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, "C:/reports/generado.pdf");
            Response.End();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string idorden = Request.QueryString["idorden"].ToString();
           //-- formatogremision.SetDatabaseLogon(user: "sa", password: "**N3t.2019");
           //-- formatogremision.VerifyDatabase();
           // formatogremision.Refresh();
          //--  formatogremision.SetParameterValue("@idorden", idorden);
          //  CrystalReportViewer1.ReportSource = formatogremision;

            // ExportFormatType formatType = ExportFormatType.NoFormat;
            //   formatType = ExportFormatType.PortableDocFormat;
            //     formatogremision.ExportToHttpResponse(formatType, Response, true, idorden);
            formatogremision.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, "C:/reports/"+ idorden + ".pdf");
      //      Response.End();


        }


    }
}