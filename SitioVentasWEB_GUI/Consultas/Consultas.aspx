<%@ Page Title="" Language="C#" MasterPageFile="~/DemoMaster.master" AutoEventWireup="true" CodeBehind="Consultas.aspx.cs" Inherits="SitioVentasWEB_GUI.Consultas.Consultas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp;<table class="tituloForm">
        CONSULTAS DEL SISTEMA
        <tr>
            <td class="style2">
                <asp:Image ID="Image1" runat="server" Height="267px" 
                    ImageUrl="~/Images/Consultas.jpg" Width="274px" />
            </td>
            <td>
                
                <asp:TreeView ID="TreeView1" runat="server" ImageSet="Arrows">
                    <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                    <Nodes>
                        <asp:TreeNode Text="Consultas" Value="Consultas">
                            <asp:TreeNode NavigateUrl="~/Consultas/WebFacturacionVendedor.aspx" Text="Facturacion vendedor" Value="Facturacion vendedor"></asp:TreeNode>
                            <asp:TreeNode Text="Facturacion Paginada" Value="Facturacion Paginada" NavigateUrl="~/Consultas/WebFacturasPaginacion.aspx"></asp:TreeNode>
                        </asp:TreeNode>
                    </Nodes>
                    <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
                    <ParentNodeStyle Font-Bold="False" />
                    <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px" VerticalPadding="0px" />
                </asp:TreeView>
                
            </td>
        </tr>
    </table>
&nbsp;
</asp:Content>


