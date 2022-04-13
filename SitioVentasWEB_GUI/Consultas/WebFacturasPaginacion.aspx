<%@ Page Title="" Language="C#" MasterPageFile="~/DemoMaster.master" AutoEventWireup="true" CodeBehind="WebFacturasPaginacion.aspx.cs" Inherits="SitioVentasWEB_GUI.Consultas.WebFacturasPaginacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 206px;
        }
        .auto-style3 {
            width: 388px;
        }
        .auto-style6 {
            height: 22px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate >
    <p class="tituloForm">
        Listado paginado de Facturas</p>
   
        <table class="auto-style1">
            <tr>
                <td class="labelContenido">Seleccione cliente:</td>
                <td class="auto-style3">
                    <asp:DropDownList ID="cboCliente" runat="server" Width="300px">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="labelContenido">Seleccione vendedor:</td>
                <td class="auto-style3">
                    <asp:DropDownList ID="cboVendedor" runat="server" Width="300px">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="labelContenido">Seleccione estado:</td>
                <td class="auto-style3">
                    <asp:DropDownList ID="cboEstado" runat="server" Width="300px">
                        <asp:ListItem Selected="True" Value="X">--Todos--</asp:ListItem>
                        <asp:ListItem>Pendiente</asp:ListItem>
                        <asp:ListItem>Cancelada</asp:ListItem>
                        <asp:ListItem>Anulada</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="btnFiltrar" runat="server" CssClass="boton2" Text="Filtrar" Width="100px" OnClick="btnFiltrar_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style6" colspan="3">
                    <asp:Label ID="lblMensaje" runat="server" CssClass="labelErrores"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style6" colspan="3">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Consultas/Consultas.aspx">Retornar</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td class="auto-style6" colspan="3">
                    <asp:GridView ID="grvFacturas" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="1148px">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="Num_fac" HeaderText="Nro. Factura" />
                            <asp:BoundField DataField="Fec_fac" DataFormatString="{0:d}" HeaderText="Fec. Facturacion" >
                            <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Fec_can" DataFormatString="{0:d}" HeaderText="Fec. Cancelacion" >
                            <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Total" DataFormatString="{0:n}" HeaderText="Total(S/.)" >
                            <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Raz_soc_cli" HeaderText="R.S. Cliente" />
                            <asp:BoundField DataField="Ruc_cli" HeaderText="RUC Cliente" />
                            <asp:BoundField DataField="Ape_ven" HeaderText="Apellidos Vend." />
                            <asp:BoundField DataField="Nom_ven" HeaderText="Nombres Vend." />
                            <asp:BoundField DataField="Estado" HeaderText="Estado" />
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" />
                        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                        <RowStyle BackColor="#F7F7DE" />
                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FBFBF2" />
                        <SortedAscendingHeaderStyle BackColor="#848384" />
                        <SortedDescendingCellStyle BackColor="#EAEAD3" />
                        <SortedDescendingHeaderStyle BackColor="#575357" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:DropDownList ID="cboPaginas" runat="server" Width="60px" AutoPostBack="True" OnSelectedIndexChanged="cboPaginas_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
            </ContentTemplate>
   </asp:UpdatePanel>
       <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0"  AssociatedUpdatePanelID ="UpdatePanel1">
         <%-- <ProgressTemplate>
              <div class="overlay">
                  <div class="overlayContent ">
                  <h2>Cargando</h2>  
                  <img src="../Images/loading.gif" alt ="Loading" border="0" />              
              </div>
              </div>
          </ProgressTemplate>--%>
    </asp:UpdateProgress>
</asp:Content>
