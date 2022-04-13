<%@ Page Title="" Language="C#" MasterPageFile="~/DemoMaster.master" AutoEventWireup="true" CodeBehind="Transacciones.aspx.cs" Inherits="SitioVentasWEB_GUI.Transacciones.Transacciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="tituloForm">
        TRANSACCIONES DEL SISTEMA 
        <tr>
            <td width ="180px">
                <asp:Image ID="Image1" runat="server" Height="285px" 
                    ImageUrl="~/Images/Transacciones.jpg" Width="248px" />
            </td>
            <td>
                
                <asp:TreeView ID="TreeView1" runat="server" ImageSet="XPFileExplorer" NodeIndent="15">
                    <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                    <Nodes>
                        <asp:TreeNode Text="Transacciones" Value="Transacciones">
                            <asp:TreeNode NavigateUrl="~/Transacciones/RegistrarOrden.aspx" Text="Registrar Orden" Value="Registrar Orden"></asp:TreeNode>
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
