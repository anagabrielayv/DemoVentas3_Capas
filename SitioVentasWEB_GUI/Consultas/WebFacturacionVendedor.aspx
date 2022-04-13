<%@ Page Title="" Language="C#" MasterPageFile="~/DemoMaster.master" AutoEventWireup="true" CodeBehind="WebFacturacionVendedor.aspx.cs" Inherits="SitioVentasWEB_GUI.Consultas.WebFacturacionVendedor" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 70%;
        }
        .auto-style2 {
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p class="tituloForm">
        CONSULTA DE FACTURACION POR VENDEDOR ENTRE FECHAS
    </p>
    <table class="auto-style1">
        <tr>
            <td>Seleccione vendedor:</td>
            <td>
                <asp:DropDownList ID="cboVendedor" runat="server" Width="250px">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Ingrese F. Inicio:</td>
            <td>
                <asp:TextBox ID="txtFI" runat="server" CssClass="TextBoxDerecha" Width="100px"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="txtFI_CalendarExtender" runat="server" BehaviorID="TextBox1_CalendarExtender" TargetControlID="txtFI">
                </ajaxToolkit:CalendarExtender>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Ingrese F. Fin:</td>
            <td>
                <asp:TextBox ID="txtFF" runat="server" CssClass="TextBoxDerecha" Width="100px"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="txtFF_CalendarExtender" runat="server" BehaviorID="txtFF_CalendarExtender" TargetControlID="txtFF">
                </ajaxToolkit:CalendarExtender>
            </td>
            <td>
                <asp:Button ID="btnConsultar" runat="server" CssClass="boton2" Text="Consultar" OnClick="btnConsultar_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Consultas/Consultas.aspx">Retornar</asp:HyperLink>
            </td>
            <td class="auto-style2">Registros:</td>
            <td>
                <asp:Label ID="lblRegistros" runat="server" CssClass="labelContenido"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblMensaje" runat="server" CssClass="labelErrores"></asp:Label>
            </td>
            <td class="auto-style2">&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <asp:GridView ID="grvFacturas" runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="706px">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="Num_fac" HeaderText="Nro. Factura" />
            <asp:BoundField DataField="fec_fac" DataFormatString="{0:d}" HeaderText="F. Facturacion">
            <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="fec_can" DataFormatString="{0:d}" HeaderText="F. Cancelacion">
            <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="Total" DataFormatString="{0:n}" HeaderText="Total (S/.)">
            <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
        </Columns>
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>
</asp:Content>
