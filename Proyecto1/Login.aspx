<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Proyecto1.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="Style/Style.css" rel="stylesheet" />
    <script src="JS/JS.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <div>
            <table class="centrar-elemento text-center tablaLogin" >
                <tr>
                <td colspan="2"><h1>Bienvenido al Hospital ABC</h1></td>
                </tr>
                <tr>
                <td colspan="2"></td>
                </tr>
                <tr>
                    <td ><img src="Picture/usu.png" class="imgInicio" /></td>
                    <td> <asp:TextBox ID="txtLogin" runat="server" CssClass="estandarTexbox" placeholder="Login"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><img src="Picture/bloqueado.png" class="imgInicio" /></td>
                    <td> <asp:TextBox ID="txtpassword" runat="server" placeholder="Password" TextMode="Password" CssClass="estandarTexbox"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btnButton" OnClick="btnLogin_Click" /></td>
                </tr>
                <tr>
                    <td colspan="2">
                         <asp:Label ID="lblMensaje" runat="server" Visible="False"></asp:Label> </td>
                </tr>
            </table>
        </div>
        </div>
    </form>
        <div class="dialog-container" id="divMensaje" style="display: none;" runat="server">
        <div class="message-box">
            <div id="mensajeContenido">
                <span id="mensajeTexto" runat="server"></span>
                <button id="cerrarMensaje" class="btnButton btnMensaje" onclick="cerrarMensaje()">Cerrar</button>
            </div>
        </div>
    </div>
</body>
</html>
