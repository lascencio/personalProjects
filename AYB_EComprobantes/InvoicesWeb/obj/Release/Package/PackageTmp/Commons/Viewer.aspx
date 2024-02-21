<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Public/Include/Main.Master" CodeBehind="Viewer.aspx.vb" Inherits="InvoicesWebAYB.Viewer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentContextualMenu" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true" />
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            <div class="MyProgressBackground"></div><div class="MyProgress"><asp:Image ID="Image1" runat="server" ImageUrl="~/Images/loadingIcon_3.gif" /></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <ul id="menuPrincipal">
        <li><a href="../Cotizaciones/CotizacionCostosTerceros.aspx">Regresar</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentMain" runat="server">
    <iframe id="urIframe" runat="server" style=" height:795px; width:895px;" />
</asp:Content>
