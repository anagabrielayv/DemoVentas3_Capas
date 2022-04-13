<%@ Page Title="" Language="C#" MasterPageFile="~/DemoMaster.master" AutoEventWireup="true" CodeBehind="Mantenimientos.aspx.cs" Inherits="SitioVentasWEB_GUI.Mantenimientos.Mantenimientos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="tituloForm">
        MANTENIMIENTOS DE TABLAS MAESTRAS 
        <tr>
            <td width ="180px">
                <asp:Image ID="Image1" runat="server" Height="285px" 
                    ImageUrl="~/Images/Mantenimientos.jpg" Width="248px" />
            </td>
            <td>
                 
                <asp:TreeView ID="TreeView1" runat="server" Width="260px" ImageSet="XPFileExplorer" NodeIndent="15">
                    <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                    <Nodes>
                        <asp:TreeNode Text="Mantenimientos" Value="Mantenimientos">
                            <asp:TreeNode NavigateUrl="~/Mantenimientos/WebMantProveedores.aspx" Text="Proveedores" Value="Proveedores"></asp:TreeNode>
                            <asp:TreeNode Text="Vendedores" Value="Vendedores"></asp:TreeNode>
                            <asp:TreeNode Text="Categorias" Value="Categorias"></asp:TreeNode>
                            <asp:TreeNode NavigateUrl="~/Mantenimientos/WebListadoRepositorio.aspx" Text="Repositorio de Documentos" Value="Repositorio de Documentos"></asp:TreeNode>
                        </asp:TreeNode>
                    </Nodes>
                    <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="2px" NodeSpacing="0px" VerticalPadding="2px" />
                    <ParentNodeStyle Font-Bold="False" />
                    <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px" VerticalPadding="0px" />
                </asp:TreeView>
                 
            </td>
        </tr>
    </table>


</asp:Content>

