<%@ Page Title="" Language="C#" MasterPageFile="~/DemoMaster.master" AutoEventWireup="true" CodeBehind="WebRegistroRepositorio.aspx.cs" Inherits="SitioVentasWEB_GUI.Mantenimientos.WebRegistroRepositorio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 78%;
        }
        .auto-style2 {
            width: 356px;
        }
        .auto-style4 {
            height: 40px;
        }
      
        .auto-style5 {
            height: 40px;
            width: 313px;
        }
        .auto-style6 {
            width: 569px;
            height: 17px;
        }
        .auto-style7 {
            width: 313px;
        }
      
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p class="tituloForm">
        <br />
        Registro de documentos al Repositorio</p>
    <table class="auto-style1">
        <tr>
            <td class="labelContenido">Seleccione documento (solo PDF):</td>
            <td class="auto-style5">
                <asp:FileUpload ID="fulDocumento" runat="server" />
            </td>
            <td class="auto-style4">
                <asp:Button ID="btnEnviar" runat="server" CssClass="boton2" OnClick="btnEnviar_Click" Text="Enviar" />
            </td>
        </tr>
        <tr>
            <td colspan="3" class="auto-style6">
                <asp:Label ID="lblMensaje" runat="server" CssClass="labelErrores"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Mantenimientos/WebListadoRepositorio.aspx">Retornar al Listado de Repositorio</asp:HyperLink>
            </td>
            <td class="auto-style7">
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
