<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Medicinas_admi.aspx.cs" Inherits="Proyecto1.enfermedades" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Medicinas</title>
    <link href="Style/Style.css" rel="stylesheet" />
    <script src="Scripts/General.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>   
            <table class="centrar-Prin text-center tablaLogin" >
                <tr>
                <td colspan="2" class="h1Prin"><h1>Administrador de Medicinas</h1></td>
                </tr> 
                 <tr>
                    <td> <asp:Label ID="Lnombre" runat="server" Text="Nombre: "></asp:Label></td>
                     <td><asp:TextBox ID="txtNombre" runat="server"></asp:TextBox></td>
                 </tr>
                 <tr>
                     <td><asp:Label ID="Lfarm" runat="server" Text="Casa Farmaceutica: "></asp:Label></td>
                     <td><asp:TextBox ID="txtFarmaceutica" runat="server"></asp:TextBox></td>
                 </tr>
                 <tr>
                     <td><asp:Label ID="Lcantidad" runat="server" Text="Cantidad: "></asp:Label></td>
                     <td><asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox></td>
                 </tr>
                 <tr>
                     <td>
                         <asp:Button ID="btnGuardar" runat="server" class="btnPrin" Text="Guardar" OnClick="btnGuardar_Click" Width="487px" />
                     </td>
                     
                     <tr>
                        <td><asp:Button ID="btnAtras" runat="server" class="btnPrin" Text="Atras" OnClick="btnAtras_Click" Width="487px"/></td> 
                     </tr>
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
