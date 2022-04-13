<%@ Page Title="" Language="C#" MasterPageFile="~/DemoMaster.master" AutoEventWireup="true" CodeBehind="MantPlantilla.aspx.cs" Inherits="SitioVentasWEB_GUI.Mantenimientos.MantPlantilla" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%--INDISPENSABLE PARA EL AJAX--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate >
       
            <%--Aqui va el titulo del formulario--%>
            <div>
                MANTENIMIENTO DE....
            </div>

               <%--Boton ( o link button ) para mostrar el modal de insercion PopMant del nuevo registro--%>
            <br />
            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo..." />
            <br />

             <%--El grid view para el listado de registros, recuerde implementar la primera columna de tipo Button, con el CommanName (recomendado) Editar
                   y con un icono asociado a la accion de editar y formatear las columnas que desea mostrar--%>
            <br />
            <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="976px">
                <AlternatingRowStyle BackColor="White" />
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
            <br />
            <br />
            <br />
           
             <%-- PLANTILLA PARA LA INSERCION DEL REGISTRO --%>
             <%--El modalpoput extender : vease el TargetControl que apunta al linkbutton btnPopup  
                  y el PopuControl ID que apunta al pane Panel1--%> 
               <ajaxToolkit:ModalPopupExtender ID="PopMant" runat="server" BackgroundCssClass="FondoAplicacion"  
             TargetControlID  ="btnPopup" PopupControlID="Panel1"  >
            </ajaxToolkit:ModalPopupExtender>    
             <%--TargetControlID es el linkButton btnPopup--%>
             <asp:LinkButton Text="" ID = "btnPopup" runat="server" />
               <%--PopupControlID es el panel Panel1--%>
             <asp:Panel ID="Panel1" runat="server" CssClass="CajaDialogo" align="center" Style="display:table" Width="700">
              <table style="border: Solid 3px #D55500; height: 308px;"
                cellpadding="0" cellspacing="0" >
                <tr style="background-color: darkred">
                    <td colspan="2" style="height: 10%; color: White; font-weight: bold; font-size: larger"
                        align="center">
                        Nuevo ...
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 45%" class="labelContenido">
                        &nbsp;</td>
                      <td align="left">
                          &nbsp;</td>
                </tr>
                <tr>
                    <td align="right" class="labelContenido" style="width: 45%">
                        <asp:Label ID="lblId2" runat="server" Text="Id. Estado:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:Label ID="lblID" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="labelContenido">
                        Campo1:
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtDescrip" runat="server" Width="487px" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="labelContenido">
                        Campo2:
                    </td>
                    <td align="left">
                        <asp:TextBox ID="TextBox1" runat="server" Width="487px" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="labelContenido">
                        Campo3:
                    </td>
                    <td align="left">
                        <asp:TextBox ID="TextBox2" runat="server" Width="487px" />
                    </td>
                </tr>
               
                     <tr>
                         <td align="right" class="labelContenido">Campo N: </td>
                         <td align="left">
                             <asp:CheckBox ID="chkActivo" runat="server" />
                         </td>
                     </tr>
                     <tr>
                         <td colspan="2">
                             <asp:Label ID="lblMensaje2" runat="server" CssClass="labelErrores" Width="400px"></asp:Label>
                         </td>
                     </tr>
                     <tr>
                         <td class="auto-style1">
                             &nbsp;</td>
                         <td class="auto-style1">
                             <asp:Button ID="btnGrabar" runat="server" Text="Grabar" Width="100px" />
                             <asp:Button ID="btnCerrar" runat="server"  Text="Cancelar" Width="100px" />
                         </td>
                     </tr>
              
            </table>
                        
        </asp:Panel>

          <%-- PLANTILLA PARA LA EDICION DEL REGISTRO (incluye un label para el codigo o PK del registro)--%>
            <%--Modalpopup extender PopMant2 : vease el TargetControl que apunta al linkbutton  btnPopup2 y el popupcontrolID que apunta al panel Panel2--%> 
        <ajaxToolkit:ModalPopupExtender ID="PopMant2" runat="server" BackgroundCssClass="FondoAplicacion"  
        TargetControlID="btnPopup2" PopupControlID="Panel2"  >
    </ajaxToolkit:ModalPopupExtender>
            <%--TargetControlID es el linkButton btnPopup2--%>
               <asp:LinkButton Text="" ID = "btnPopup2" runat="server" />
             <%--PopupControlID es el panel Panel2--%>
       <asp:Panel ID="Panel2" runat="server" CssClass="CajaDialogo" align="center" Style="display:table" Width="700">
            <table style="border: Solid 3px #D55500; height: 308px;"
                cellpadding="0" cellspacing="0" >
                <tr style="background-color: darkred">
                    <td colspan="2" style="height: 10%; color: White; font-weight: bold; font-size: larger"
                        align="center">
                        Actualizar ...
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 45%" class="labelContenido">
                        &nbsp;</td>
                      <td align="left">
                          &nbsp;</td>
                </tr>
                <tr>
                    <td align="right" class="labelContenido" style="width: 45%">
                        <asp:Label ID="Label1" runat="server" Text="Id. Estado:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:Label ID="Label2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="labelContenido">
                        Campo1:
                    </td>
                    <td align="left">
                        <asp:TextBox ID="TextBox3" runat="server" Width="487px" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="labelContenido">
                        Campo2:
                    </td>
                    <td align="left">
                        <asp:TextBox ID="TextBox4" runat="server" Width="487px" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="labelContenido">
                        Campo3:
                    </td>
                    <td align="left">
                        <asp:TextBox ID="TextBox5" runat="server" Width="487px" />
                    </td>
                </tr>
               
                     <tr>
                         <td align="right" class="labelContenido">Campo N: </td>
                         <td align="left">
                             <asp:CheckBox ID="CheckBox1" runat="server" />
                         </td>
                     </tr>
                     <tr>
                         <td colspan="2">
                             <asp:Label ID="lblMensaje3" runat="server" CssClass="labelErrores" Width="400px"></asp:Label>
                         </td>
                     </tr>
                     <tr>
                         <td class="auto-style1">
                             &nbsp;</td>
                         <td class="auto-style1">
                             <asp:Button ID="Button1" runat="server" Text="Grabar" Width="100px" />
                             <asp:Button ID="Button2" runat="server"  Text="Cancelar" Width="100px" />
                         </td>
                     </tr>
              
            </table>
                        
        </asp:Panel>
       <%-- PLANTILLA PARA MENSAJES --%>
       <%-- Modal Popup Extender  mpeMensaje : vease el TargetControlID al linkButton btnMensaje  
            y PopupControlID al panel pnlMensaje--%> 
              <ajaxToolkit:ModalPopupExtender ID="mpeMensaje" runat="server" TargetControlID="btnMensaje" 
                    PopupControlID="pnlMensaje" BackgroundCssClass="FondoAplicacion" OkControlID="btnAceptar" 
                     />
            <%--TargetContolID es el  linkButton btnMensaje--%>
              <asp:LinkButton ID="btnMensaje" runat="server" ></asp:LinkButton>
               <%--PopupControlID es el panel pnlMensaje--%>
            <asp:Panel ID="pnlMensaje" runat="server" CssClass="CajaDialogo" Style="display: normal;" Width="300"> 
                    <table border="0" width="300px" style="margin: 0px; padding: 0px; background-color:darkred ; 
                        color: #FFFFFF;"> 
                        <tr> 
                            <td align="center" class="auto-style2"> 
                                <asp:Label ID="lblTitulo" runat="server" Text="Mensaje" /> 
                            </td> 
                            <td width="12%" class="auto-style2"> 
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Cancelar.png" Style="vertical-align: top;" 
                                    ImageAlign="Right" /> 
                            </td> 
                        </tr> 
                         
                    </table> 
                    <div> 
                        <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor ="Black" /> 
                    </div> 
                    <div> 
                        <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" /> 
                    </div> 
                </asp:Panel> 



        </ContentTemplate>

    </asp:UpdatePanel>
   <%--El UpdateProgress para el manejo del tiempo de refresco del UpdatePanel1 por la insercion , actualizacion o eliminacion--%>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0" AssociatedUpdatePanelID="UpdatePanel1">
        <%--<ProgressTemplate >
            <div class="overlay"  />
            <div class ="overlayContent" >
            <h2>  Procesando....</h2> 
                <p>
                    &nbsp;</p>
                <img src ="../Images/indicator.gif" alt ="Loading" border="0"/>
                </div> 
        </ProgressTemplate>--%>
    </asp:UpdateProgress>
</asp:Content>
