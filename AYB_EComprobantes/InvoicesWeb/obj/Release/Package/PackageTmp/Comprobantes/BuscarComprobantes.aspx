<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Comprobantes//MP_Comprobantes.master" CodeBehind="BuscarComprobantes.aspx.vb" Inherits="InvoicesWebAYB.BuscarComprobantes" Culture="es-PE" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true" />
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="upInputs">
        <ProgressTemplate>
            <div class="MyProgressBackground"></div>
            <div class="MyProgress"><asp:Image ID="Image1" runat="server" ImageUrl="~/Images/loadingIcon_3.gif" /></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <div class="MyTable">
        <div class="MyTitle"><h2>Consultar Comprobantes Emitidos</h2></div>
        <div class="MyRowDataEntry" style="margin-top:1%;">
            <asp:UpdatePanel runat="server" id="upInputs" updatemode="Conditional">
                <ContentTemplate>
                    <div class="MyCell" style="width:470px;">Cliente<br />
                        <asp:DropDownList ID="ddlClientes" runat="server" DataTextField="adesane" DataValueField="acodane" AutoPostBack="True" TabIndex="1" CssClass="MyDataEntry" Width="450px" />
                    </div>
                    <div class="MyCell" style="width:130px;">Fecha Inicial<br />
                        <asp:TextBox ID="txtFechaDesde" runat="server" AutoPostBack="True" MaxLength="10" TabIndex="6" CssClass="MyDateEntry" TextMode="Date" Font-Names="Arial Narrow" Font-Size="Small" Width="110px" />
                    </div>
                    <div class="MyCell" style="width:130px;">Fecha Final<br />
                        <asp:TextBox ID="txtFechaHasta" runat="server" AutoPostBack="True" MaxLength="10" TabIndex="7" CssClass="MyDateEntry" TextMode="Date" Font-Names="Arial Narrow" Font-Size="Small" Width="110px" />
                    </div>
                    <div class="MyCell" style="width:130px;"><br />
                        <asp:LinkButton ID="lbtBuscar" runat="server" Width="100%" CssClass="MyLinkButtonOther" Text="Buscar" Style="text-align:center;"></asp:LinkButton>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="MyRowDataEntry">
            <asp:Panel ID="pnlComprobantes" runat="server" Height="380px" CssClass="MyPanel" ScrollBars="Auto">
                <asp:UpdatePanel runat="server" id="upnComprobantes" updatemode="Conditional">
                    <Triggers>
                        <asp:AsyncPostBackTrigger controlid="lbtBuscar" eventname="Click" />
                    </Triggers>
                    <ContentTemplate>
                        <asp:GridView ID="gvComprobantes" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="4" DataKeyNames="Nombre_archivo,Mensaje" Font-Names="Arial Narrow" Font-Size="Small" GridLines="Horizontal" ShowHeaderWhenEmpty="True" BorderColor="Transparent" BackColor="LightYellow" AlternatingRowStyle-BorderColor="Silver" RowStyle-BorderColor="Silver" AlternatingRowStyle-BackColor="LightYellow" RowStyle-BackColor="#FFFFCC" EmptyDataText="No existen comprobantes para el rango de fechas indicado">
                            <AlternatingRowStyle BackColor="LightYellow" Height="5px" />
                            <Columns>
                                <asp:TemplateField HeaderText="Razón Social">
                                    <EditItemTemplate><asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("RAZON_SOCIAL")%>'></asp:TextBox></EditItemTemplate>
                                    <ItemTemplate><asp:Label ID="Label1" runat="server" Text='<%# Bind("RAZON_SOCIAL")%>' Width="300px"></asp:Label></ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tipo">
                                    <EditItemTemplate><asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("COMPROBANTE_TIPO")%>'></asp:TextBox></EditItemTemplate>
                                    <ItemTemplate><asp:Label ID="Label2" runat="server" Text='<%# Bind("COMPROBANTE_TIPO")%>' Width="30px"></asp:Label></ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="30px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Serie">
                                    <EditItemTemplate><asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("COMPROBANTE_SERIE")%>'></asp:TextBox></EditItemTemplate>
                                    <ItemTemplate><asp:Label ID="Label3" runat="server" Text='<%# Bind("COMPROBANTE_SERIE")%>' Width="50px"></asp:Label></ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Número">
                                    <EditItemTemplate><asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("COMPROBANTE_NUMERO")%>'></asp:TextBox></EditItemTemplate>
                                    <ItemTemplate><asp:Label ID="Label4" runat="server" Text='<%# Bind("COMPROBANTE_NUMERO")%>' Width="80px"></asp:Label></ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="80px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fecha">
                                    <EditItemTemplate><asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("COMPROBANTE_FECHA")%>'></asp:TextBox></EditItemTemplate>
                                    <ItemTemplate><asp:Label ID="Label5" runat="server" Text='<%# Bind("COMPROBANTE_FECHA", "{0:dd/MM/yyyy}")%>' Width="60px"></asp:Label></ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="60px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vncmto.">
                                    <EditItemTemplate><asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("COMPROBANTE_VENCIMIENTO")%>'></asp:TextBox></EditItemTemplate>
                                    <ItemTemplate><asp:Label ID="Label6" runat="server" Text='<%# Bind("COMPROBANTE_VENCIMIENTO", "{0:dd/MM/yyyy}")%>' Width="60px"></asp:Label></ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="60px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Mon.">
                                    <EditItemTemplate><asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("MONEDA") %>'></asp:TextBox></EditItemTemplate>
                                    <ItemTemplate><asp:Label ID="Label7" runat="server" Text='<%# Bind("MONEDA") %>' Width="30px"></asp:Label></ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="30px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Valor Venta">
                                    <EditItemTemplate><asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("VALOR_VENTA")%>'></asp:TextBox></EditItemTemplate>
                                    <ItemTemplate><asp:Label ID="Label8" runat="server" Text='<%# Bind("VALOR_VENTA", "{0:N2}")%>' Width="70px"></asp:Label></ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" Width="70px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="IGV">
                                    <EditItemTemplate><asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("IGV")%>'></asp:TextBox></EditItemTemplate>
                                    <ItemTemplate><asp:Label ID="Label9" runat="server" Text='<%# Bind("IGV", "{0:N2}")%>' Width="60px"></asp:Label></ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" Width="60px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Precio Venta">
                                    <EditItemTemplate><asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("IMPORTE_TOTAL")%>'></asp:TextBox></EditItemTemplate>
                                    <ItemTemplate><asp:Label ID="Label10" runat="server" Text='<%# Bind("IMPORTE_TOTAL", "{0:N2}")%>' Width="80px"></asp:Label></ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" Width="80px" />
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibtDescargarPDF" runat="server" CausesValidation="False" CommandName="DescargarPDF" CommandArgument="<%# CType(Container, GridViewRow).RowIndex%>" ImageUrl="~/Images/pdf.png" Text="Seleccionar" Width="24px" />
                                    </ItemTemplate>
                                    <ControlStyle Width="24px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibtDescargarXML" runat="server" CausesValidation="False" CommandName="DescargarXML" CommandArgument="<%# CType(Container, GridViewRow).RowIndex%>" ImageUrl="~/Images/xml.png" Text="Seleccionar" Width="24px" />
                                    </ItemTemplate>
                                    <ControlStyle Width="24px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle Font-Size="12px" ForeColor="DarkRed" />
                            <EmptyDataRowStyle Font-Bold="True" Font-Size="Medium" ForeColor="DarkRed" />
                            <HeaderStyle BackColor="#666666" ForeColor="White" Height="5px" HorizontalAlign="Left" />
                            <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                            <RowStyle BackColor="#FFFFCC" Height="5px" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
        </div>
    </div>
</asp:Content>