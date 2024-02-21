<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConstanciaRPT.aspx.cs" Inherits="WebAppHIDRONAMIC.Reports.ConstanciaRPT" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div>
            <br />
            <asp:Button ID="btnReporte" runat="server" OnClick="btnReporte_Click" Text="REPORTE" />
            <br />
            <br />
            <rsweb:ReportViewer ID="rvConstancia" runat="server" Height="768px" Width="961px" SizeToReportContent="true" AsyncRendering="false">
          <%--      <LocalReport ReportPath="Reports\ReportConstancia.rdlc">
                </LocalReport>--%>
            </rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
