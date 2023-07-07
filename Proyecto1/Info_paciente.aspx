<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Info_paciente.aspx.cs" Inherits="Proyecto1.Info_paciente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Información Clientes</title>
    <link href="Style/Style.css" rel="stylesheet" />
    <script src="Scripts/General.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <table class="centrar-Arriba text-center tablaLogin" >
        <tr>
        <td colspan="2" class="h1Prin"><h1>Información Clientes</h1></td>
        </tr>
        <tr><td><h1>Listado Pacientes</h1></td></tr>
        <tr>
        <td><asp:GridView ID="GVPct" CssClass="gridview" runat="server"></asp:GridView> </td>
        </tr>
                <tr>
               <td><asp:Button ID="btnSalir" runat="server" class="btnPrin" Text="Atras" OnClick="btnSalir_Click" Width="400px"/></td>
                </tr>
            
            </table>   
        </div>
    </form>
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
