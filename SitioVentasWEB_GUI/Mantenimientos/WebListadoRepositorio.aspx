<%@ Page Title="" Language="C#" MasterPageFile="~/DemoMaster.master" AutoEventWireup="true" CodeBehind="WebListadoRepositorio.aspx.cs" Inherits="SitioVentasWEB_GUI.Mantenimientos.WebListadoRepositorio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p class="tituloForm">
        <br />
        Listado de Repositorio de Documentos</p>
    <p>
        <asp:Button ID="Button1" runat="server" CssClass="boton-new" Height="25px" Text="Nuevo registro de documento" Width="260px" PostBackUrl="~/Mantenimientos/WebRegistroRepositorio.aspx" />
    </p>
    <p>
        <asp:Label ID="lblMensaje" runat="server" CssClass="labelErrores"></asp:Label>
    </p>
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Mantenimientos/Mantenimientos.aspx">Retornar</asp:HyperLink>
    </p>
    <p>
        <asp:GridView ID="grvRepositorio" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" ShowHeaderWhenEmpty="True" Width="978px" OnRowCommand="grvRepositorio_RowCommand">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id. Documento" />
                <asp:BoundField DataField="FecRegistro" DataFormatString="{0:d}" HeaderText="Fecha Registro" />
                <asp:BoundField DataField="ruta" HeaderText="Nombre Archivo" />
                <asp:BoundField DataField="UsuRegistro" HeaderText="Usuario Reg." />
                <asp:ButtonField CommandName="Descargar" Text="Descargar" />
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
    </p>
</asp:Content>
