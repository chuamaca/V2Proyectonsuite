<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="crfose.aspx.cs" Inherits="proyecto.Areas.Admin.formatos.crfose" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>


<link href="../Assets/css/AdminLTE.css" rel="stylesheet" />
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>


    </title>
</head>
<body>



    <form id="form1" runat="server">
    <div>
    
    <h2>

       
            <asp:Button ID="Button1" runat="server" Text="Exportar FOSE"  CssClass="btn btn-success btn-sm fa fa-file-pdf-o" OnClick="Button1_Click" />


    </h2>
        
        
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" ToolPanelView="None"  />
    
    </div>
    </form>
</body>
</html>
