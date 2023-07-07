<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Medico_Admi.aspx.cs" Inherits="Proyecto1.Medico_Admi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Administrar Medicos</title>
    <link href="Style/Style.css" rel="stylesheet" />
    <script src="Scripts/General.js"></script>
</head>
<body>
    <div class="containerTable">
        <asp:TextBox ID="txtGlobal" runat="server" Visible="false"></asp:TextBox>
        <form id="frmListadoMedico" runat="server">
    <table class="centrar-Arriba text-center tablaLogin" >
    <tr><td><h1>Listado Medicos</h1></td></tr>
    
    
        <tr>
          <td>  <asp:GridView ID="GVMedico" CssClass="gridview" runat="server" OnRowCommand ="gridViewMedico_RowCommand"></asp:GridView> </td>
        
   </tr>
    </table>
    
        <table class="centrar-Prin text-center tablaLogin" >
            
                
                <tr>
                <td colspan="2" class="h1Prin"><h1>Administrar Medicos</h1></td>
                </tr>
                <tr>
                <td colspan="2" class="h1Prin"><h3>Información Personal</h3></td>
                </tr>
                <tr>
                <td><asp:Label ID="IdMedico" runat="server" Text="IDMédico:"></asp:Label></td>
                <td><asp:TextBox ID="txt_Medico" runat="server" Width="235px"></asp:TextBox></td>
                </tr>
                 <tr>
                <td><asp:Label ID="Nombre" runat="server" Text="Nombre:"></asp:Label></td>
                <td><asp:TextBox ID="txt_Nombre" runat="server" Width="235px"></asp:TextBox></td>
                 </tr>
                 <tr>
                <td><asp:Label ID="Apellido1" runat="server" Text="Primer Apellido:"></asp:Label></td>
                <td><asp:TextBox ID="txt_apellido1" runat="server" Width="235px"></asp:TextBox></td>
                 </tr>
                <tr>
                <td><asp:Label ID="Apellido2" runat="server" Text="Segundo Apellido:"></asp:Label></td>
                <td><asp:TextBox ID="txt_apellido2" runat="server" Width="235px"></asp:TextBox></td>
                 </tr>
                <tr>
                <td><asp:Label ID="identificacion" runat="server" Text="Identificación"></asp:Label></td>
                <td><asp:TextBox ID="txt_identi" runat="server" Width="235px"></asp:TextBox></td>
                 </tr>
               
                <tr>
                    <td><asp:Label ID="lblTI" runat="server" Text="Tipo de identificación"></asp:Label></td>
                    <td> <asp:DropDownList ID="DDLId" runat="server"></asp:DropDownList></td>
                 </tr>
                
                <tr>
                <td><asp:Label ID="lblGenero" runat="server" Text="Género"></asp:Label></td>
                <td><asp:DropDownList ID="DDLGenero" runat="server"></asp:DropDownList></td>
                 </tr>
                <tr>
                    <td><asp:Label ID="lblEC" runat="server" Text="Estado Civil"></asp:Label></td>
                    <td><asp:DropDownList ID="DDLCivil" runat="server"></asp:DropDownList></td>
                 </tr>
                <tr>
                <td><asp:Label ID="Label1" runat="server" Text="Calendario"></asp:Label></td>
                    <td><asp:Calendar ID="Calendar1" runat="server"></asp:Calendar></td>
                 </tr>
                <tr>
                <td colspan="2" class="h1Prin"><h3>Especialidad Médica</h3></td>
                </tr>
                 <tr>
                <td><asp:Label ID="lblEspeMed" runat="server" Text="Especilidad médica"></asp:Label></td>
                <td><asp:TextBox ID="txt_EspeMed" runat="server" Width="235px"></asp:TextBox></td>
                 </tr>
                <td colspan="2" class="h1Prin"><h3>Información de contacto</h3></td>
                 <tr>
                <tr>
                <td><asp:Label ID="lblNT" runat="server" Text="Números de teléfono"></asp:Label></td>
                <td><asp:TextBox ID="txt_TN" runat="server" Width="235px"></asp:TextBox></td>
                </tr>
                <tr>
                <td><asp:Label ID="lblCE" runat="server" Text="Correo electrónico"></asp:Label></td>
                <td><asp:TextBox ID="txt_CE" runat="server" Width="235px"></asp:TextBox></td>
                </tr>
                 <td><asp:Button ID="btnGuardar" runat="server" class="btnPrin" Text="Guardar" OnClick="btnGuardar_Click"  /></td>
                <td>
                    <asp:Button ID="btnUpdate" runat="server" class="btnPrin" Text="Actualizar" OnClick="btnActualizar_Click" /></td>
                 <td><asp:Button ID="btnEliminar" runat="server" class="btnPrin" Text="Borrar" OnClick="btnEliminar_Click"  /></td> 
                     <td><asp:Button ID="btnMenu" runat="server" class="btnPrin" Text="Volver a Menú" OnClick="btnSalir_Click"  /></td> 
                </tr>
            
        
    
     </table>   
      </form> 
        </div>
    <div class="dialog-container" id="divMensaje" style="display: none;" runat="server">
        <div class="message-box">
            <div id="mensajeContenido">
                <span id="mensajeTexto" runat="server"></span>
                <button id="cerrarMensaje" class="btnClass btnMensaje" onclick="cerrarMensaje()">Cerrar</button>
            </div>
        </div>
    </div>
</body>
</html>
