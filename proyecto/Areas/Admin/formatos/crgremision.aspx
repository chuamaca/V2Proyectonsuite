<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="crgremision.aspx.cs" Inherits="proyecto.Areas.Admin.formatos.crgremision" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Assets/css/AdminLTE.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <h2>


            <asp:Button ID="Button1" runat="server" Text="Exportar Guia" CssClass="btn btn-success btn-sm fa fa-file-pdf-o" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="Enviar Guia" CssClass="btn btn-success btn-sm fa fa<a href="crgremision.aspx">crgremision.aspx</a>-file-pdf-o" OnClick="Button2_Click" />
            
        </h2>

        <div>

            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />

        </div>
    </form>
</body>
</html>
