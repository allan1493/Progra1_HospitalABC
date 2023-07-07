<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="enfermedades_Admin.aspx.cs" Inherits="Proyecto1.enfermedades_Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Administrar Enfermedades</title>
    <link href="Style/Style.css" rel="stylesheet" />
    <script src="Scripts/General.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
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
               <td><asp:Button ID="btnAtras" runat="server" class="btnPrin" Text="Atras" OnClick="btnAtras_Click" Width="800px"/></td> 
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
