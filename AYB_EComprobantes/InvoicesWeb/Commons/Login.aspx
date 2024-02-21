<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Public/Include/Main.Master" CodeBehind="Login.aspx.vb" Inherits="InvoicesWebAYB.Login" %>
<%@ MasterType virtualpath="~/Public/Include/Main.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentContextualMenu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentMain" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true" />
   <%-- <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel3">
        <ProgressTemplate>
            <div class="MyProgressBackground"></div>
            <div class="MyProgress"><asp:Image ID="Image1" runat="server" ImageUrl="~/Images/loadingIcon_3.gif" /></div>
        </ProgressTemplate>
    </asp:UpdateProgress>--%>
    <div class="MyTable">
    <div class="MyTitleLogin"><h2>Acceso al Sistema</h2></div>
        <div class="MyRow">
            <asp:UpdatePanel runat="server" id="UpdatePanel1" updatemode="Conditional">
                <ContentTemplate>
                    <div class="MyCell_Center"><asp:TextBox ID="txtRUC" runat="server" PlaceHolder="Número de RUC" AutoPostBack="True" CssClass="MyTextBox" Width="120px"></asp:TextBox></div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="MyRow">
            <asp:UpdatePanel runat="server" id="UpdatePanel2" updatemode="Conditional">
                <ContentTemplate>
                    <div class="MyCell_Center"><asp:TextBox ID="txtUsuario" runat="server" PlaceHolder="ID del Usuario" AutoPostBack="True" CssClass="MyTextBox" Width="120px"></asp:TextBox></div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="MyRow">
            <div class="MyCell_Center"><asp:TextBox ID="txtClave" runat="server" PlaceHolder="Contraseña" TextMode="Password" CssClass="MyTextBox" Width="120px"></asp:TextBox></div>
        </div>
        <asp:UpdatePanel runat="server" id="UpdatePanel3" updatemode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger controlid="txtRUC" eventname="TextChanged" />
                <asp:AsyncPostBackTrigger controlid="txtUsuario" eventname="TextChanged" />
                <asp:AsyncPostBackTrigger controlid="txtClave" eventname="TextChanged" />
            </Triggers>
            <ContentTemplate>
                <div class="MyRow">
                    <div class="MyCell_Center"><br/><asp:LinkButton ID="lnkIniciarSesion" runat="server" Text="Iniciar Sesión" CssClass="MyLinkButton"></asp:LinkButton></div>
                </div>
                <div class="MyRow"></div>
                <div class="MyRow">
                    <div class="MyCell_Center"><asp:Label ID="lblMensaje" runat="server" ForeColor="#CC0000" Visible="False"></asp:Label></div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
