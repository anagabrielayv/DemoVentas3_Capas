<%@ Page Title="" Language="C#" MasterPageFile="~/DemoMaster.master" AutoEventWireup="true" CodeBehind="RegistrarOrden.aspx.cs" Inherits="SitioVentasWEB_GUI.Transacciones.RegistrarOrden" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate >

       
    <table>
            <caption>
                <h2 class="tituloForm">
                    Registrar Orden de Compra </h2>
            </caption>
            <%--<tr>
                <td class="labelContenido">
                    Nro. de Orden:</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtNumOco" runat="server" Width="92px"></asp:TextBox>
                </td>
            </tr>--%>
            <tr>
                <td class="labelContenido">
                    Ingrese fecha OC:</td>
                <td style="width: 100px; height: 21px" colspan="2">
                    <asp:TextBox ID="txtFecOco" runat="server" Width="96px"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="txtFecOco_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtFecOco">
                    </ajaxToolkit:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td class="auto-style16">
                    Seleccione Proveedor:</td>
                <td class="auto-style15" colspan="2">
                    <asp:DropDownList ID="cboProveedor" runat="server"  Width="300px" AutoPostBack="True" OnSelectedIndexChanged="cboProveedor_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="labelContenido">
                    Ingrese fecha atencion:</td>
                <td style="width: 100px" colspan="2">
                    <asp:TextBox ID="txtFecAte" runat="server" Width="96px"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="txtFecAte_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtFecAte">
                    </ajaxToolkit:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td class="auto-style24">
                    </td>
                <td colspan="2" class="auto-style25">
                    </td>
            </tr>
            <tr>
                <td class="auto-style20">
                    <asp:Button ID="btnAgregar" runat="server" CssClass="boton2" onclick="btnAgregar_Click" Text="Agregar Detalle" Width="150px" />
                </td>
                <td class="auto-style21">
                    <asp:Button ID="btnGrabar" runat="server" CssClass="boton2" onclick="btnGrabar_Click" Text="Grabar" Width="150px" />
                </td>
                <td class="auto-style21">
                    <asp:Button ID="btnCancelar" runat="server" CssClass="boton-new" PostBackUrl="~/Transacciones/Transacciones.aspx" Text="Cancelar" Width="150px" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;<asp:GridView ID="grDetalles" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" onrowcommand="grDetalles_RowCommand" Width="1076px" ShowHeaderWhenEmpty="True">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:ButtonField ButtonType="Image" CommandName="Eliminar" ImageUrl="~/Images/Borrar.png" Text="Eliminar" />
                            <asp:BoundField DataField="cod_pro" HeaderText="Codigo Producto" />
                            <asp:BoundField DataField="Des_pro" HeaderText="Descripción" />
                            <asp:BoundField DataField="can_ped" HeaderText="Cantidad Pedida" />
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
                <td class="auto-style13">
                    &nbsp;</td>
                <td style="width: 700px" colspan="2">
                    &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td>
                    </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="Red" NavigateUrl="~/Transacciones/Transacciones.aspx">Retornar Menu </asp:HyperLink>
                </td>
            </tr>
        </table>
            <%-- Aqui va el popup de Detalle con su codigo--%>
            <%--el link button o cualquiero otro control para el manejo del modal--%>
           <asp:LinkButton Text="" ID = "btnPopupDetalle" runat="server" />
            <%--El modalpoput extender : vease el TargetControl que apunta al linkbutton y el popuconttol ID que apunhta al panel--%> 
      <ajaxToolkit:ModalPopupExtender ID="PopDetalle" runat="server" BackgroundCssClass="FondoAplicacion"  
        TargetControlID="btnPopupDetalle" PopupControlID="PanelDetalle"  >
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="PanelDetalle" runat="server" CssClass="auto-style19" align="center" Style="display:table" Width="403px">
          
            <table style="border: Solid 3px #D55500;"
                cellpadding="0" cellspacing="0" >
                <tr style="background-color: darkred">
                    <td colspan="2" style="height: 10%; color: White; font-weight: bold; font-size: larger"
                        align="center">
                        Registrar Detalle
                    </td>
                </tr>
                <tr>
                    <td align="right" class="auto-style5">
                        </td>
                      <td align="left" class="auto-style6">
                          </td>
                </tr>
                <tr>
                    <td align="right" class="auto-style17">Seleccione Producto:</td>
                    <td align="left" class="auto-style18">
                        <asp:DropDownList ID="cboProducto" runat="server"  Width="192px" CssClass="DropDownList">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="auto-style7">
                        Cantidad Pedida:
                    </td>
                    <td align="left" class="auto-style8">
                        <asp:TextBox ID="txtCanPed" runat="server" Width="70px"></asp:TextBox>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2" class="auto-style9">
                        <asp:Label ID="lblMensajeDetalle" runat="server" CssClass="labelErrores" Width="400px"></asp:Label>
                    </td>
                </tr>
               
                     <tr>
                         <td class="auto-style26">
                             </td>
                         <td class="auto-style26">
                             </td>
                </tr>
              
                <tr>
                    <td class="auto-style22">
                        <asp:Button ID="btnGrabarDetalle" runat="server" OnClick="btnGrabarDetalle_Click" Text="Grabar" Width="100px" CssClass="boton2" />
                    </td>
                    <td class="auto-style22">
                        <asp:Button ID="btnCancelarDetalle" runat="server" Text="Cancelar" Width="100px" CssClass="boton-new" />
                    </td>
                </tr>
              
                <tr>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                </tr>
              
            </table>
                        
        </asp:Panel>
    <%--Este es el panel  que contiene los mensajes de error--%>
              <asp:LinkButton ID="lnkMensaje" runat="server" ></asp:LinkButton>
               <ajaxToolkit:ModalPopupExtender ID="mpeMensaje" runat="server" TargetControlID="lnkMensaje" 
                    PopupControlID="pnlMensaje" BackgroundCssClass="FondoAplicacion" OkControlID="btnAceptar" 
                     />
<asp:Panel ID="pnlMensaje" runat="server" CssClass="CajaDialogo" Style="display: normal;" Width="500"> 
                    <table border="0" width="500px" style="margin: 0px; padding: 0px; background-color:darkred ; 
                        color: #FFFFFF;"> 
                        <tr> 
                            <td align="center" class="auto-style11" > 
                                <asp:Label ID="lblTitulo" runat="server" Text="Mensaje" /> 
                            </td> 
                            <td width="12%" class="auto-style11"> 
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Cancelar.png" Style="vertical-align: top;" 
                                    ImageAlign="Right" /> 
                            </td> 
                        </tr> 
                         
                    </table> 
                    <div> 
                        <asp:Label ID="lblMensaje" runat="server" ForeColor ="Black" /> 
                    </div> 
                    <div> 
                        <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="boton-new" /> 
                    </div> 
                </asp:Panel> 

     </ContentTemplate>

    </asp:UpdatePanel>
</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style5 {
            font-family: Verdana;
            font-size: 10pt;
            color: #993366;
            width: 45%;
            height: 23px;
        }
        .auto-style6 {
            height: 23px;
        }
        .auto-style7 {
            font-family: Verdana;
            font-size: 10pt;
            color: #993366;
            height: 25px;
        }
        .auto-style8 {
            height: 25px;
        }
        .auto-style9 {
            height: 12px;
        }
        .auto-style11 {
            height: 27px;
        }
        .auto-style13 {
            width: 123px;
        }
        .auto-style15 {
            width: 100px;
            height: 29px;
        }
        .auto-style16 {
            font-family: Verdana;
            font-size: 10pt;
            color: #993366;
            height: 29px;
        }
        .auto-style17 {
            font-family: Verdana;
            font-size: 10pt;
            color: #993366;
            width: 45%;
            height: 22px;
        }
        .auto-style18 {
            height: 22px;
        }
        .auto-style19 {
            border: 0px outset white;
            background-color: white;
            padding: 0px;
        }
        .auto-style20 {
            width: 123px;
            height: 30px;
            text-align: center;
        }
        .auto-style21 {
            width: 100px;
            height: 30px;
            text-align: center;
        }
        .auto-style22 {
            height: 25px;
            text-align: center;
        }
        .auto-style24 {
            width: 123px;
            height: 22px;
        }
        .auto-style25 {
            width: 100px;
            height: 22px;
        }
        .auto-style26 {
            height: 8px;
        }
        .auto-style27 {
            height: 10px;
            text-align: center;
        }
        </style>
</asp:Content>

