<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Enfer_Admi.aspx.cs" Inherits="Proyecto1.Enfer_Admi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Administrar Enfermedades</title>
    <link href="Style/Style.css" rel="stylesheet" />
    <script src="Scripts/General.js"></script>
</head>
<body>
    <div class="containerTable">
        <asp:TextBox ID="txtGlobal" runat="server"  Visible="false"></asp:TextBox>
        <form id="frmPaciente" runat="server">
    <table class="centrar-Arriba text-center tablaLogin" >
    <tr><td><h1>Listado Enfermedades</h1></td></tr>
    
    
        <tr>
          <td>  <asp:GridView ID="GVEfm" CssClass="gridview" runat="server" OnRowCommand ="gridViewEnfermedad_RowCommand"></asp:GridView> </td>
        
   </tr>
        </table>
             <table class="centrar-Prin text-center tablaLogin" >
                <tr>
                <td colspan="2" class="h1Prin"><h1>Administrar Enfermedades</h1></td>
                </tr>
                 <tr>
                <td><asp:Label ID="lblEnfermedad" runat="server" Text="Enfermedad:"></asp:Label></td>
                <td><asp:TextBox ID="txt_Enfermedad" runat="server" Width="235px"></asp:TextBox></td>
                </tr>
                <tr>
                <td><asp:Label ID="lblDescrip" runat="server" Text="Descripción:"></asp:Label></td>
                <td><asp:TextBox ID="txt_Descrip" runat="server" Width="235px"></asp:TextBox></td>
                </tr>
                <tr>
                <td><asp:Button ID="btnGuardar" runat="server" class="btnPrin" Text="Guardar" OnClick="btnGuardar_Click"  /></td>
                    <td><asp:Button ID="btnUpdate" runat="server" class="btnPrin" Text="Actualizar" OnClick="btnActualizar_Click"  /></td>
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
