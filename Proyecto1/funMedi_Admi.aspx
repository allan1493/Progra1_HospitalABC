<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="funMedi_Admi.aspx.cs" Inherits="Proyecto1.funMedi_Admi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Funciones del Medico</title>
    <link href="Style/Style.css" rel="stylesheet" />
     <script src="Scripts/General.js"></script>
</head>
<body>
     <div class="containerTable">
          <asp:TextBox ID="txtGlobalPaciente" runat="server" Visible="false"></asp:TextBox>
         <asp:TextBox ID="txtGlobalCita" runat="server" Visible="false"></asp:TextBox>
        <form id="frmConsulta" runat="server">
    <table class="centrar-Arriba text-center tablaLogin" >
    <tr><td colspan="2" class="h1Prin"><h1>Expediente Paciente</h1></td></tr>
    
    <tr>
        <td>
            <asp:Label ID="LPaciente" runat="server" Text="ID Paciente"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtPaciente" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:Button ID="btnBuscar" class="btnPrin" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
        </td>
    </tr>
        
       </table>
            <table class="centrar-Prin text-center tablaLogin">
                <tr>
          <td>  <asp:GridView ID="GVExpediente" CssClass="gridview" runat="server" OnRowCommand ="gridViewExpediente_RowCommand"></asp:GridView> </td>
        <td><asp:Button ID="btnAtras" runat="server" class="btnPrin" Text="Atras" OnClick="btnAtras_Click" Width="487px"/></td> 

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
