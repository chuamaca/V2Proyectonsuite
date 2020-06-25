using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using proyecto.Areas.Admin.Filters;


namespace proyecto.Areas.Admin.formatos
{
    [Autenticado]
    public partial class crfose : System.Web.UI.Page
    {
        rpt_fose formatofose = new rpt_fose();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string viewfose = Request.QueryString["idorden"].ToString();

                formatofose.SetDatabaseLogon(user: "sa", password: "**N3t.2019");
                formatofose.VerifyDatabase();
                formatofose.Refresh();
                formatofose.SetParameterValue("@idorden", viewfose);
                CrystalReportViewer1.ReportSource = formatofose;

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            string idorden = Request.QueryString["idorden"].ToString();
            formatofose.SetDatabaseLogon(user: "sa", password: "**N3t.2019");
            formatofose.VerifyDatabase();
            formatofose.Refresh();
            formatofose.SetParameterValue("@idorden", idorden);
            CrystalReportViewer1.ReportSource = formatofose;

            ExportFormatType formatType = ExportFormatType.NoFormat;
            formatType = ExportFormatType.PortableDocFormat;
            formatofose.ExportToHttpResponse(formatType, Response, true, idorden);
            Response.End();


        }
    }
}