<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sucursales_Admi.aspx.cs" Inherits="Proyecto1.Surcusales" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Adminitrar Sucursales</title>
    <link href="Style/Style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="centrar-Prin text-center tablaLogin" >
                <tr>
                <td colspan="2" class="h1Prin"><h1>Sucursales</h1></td>
                </tr>
              
                <tr>
                <td><asp:Button ID="btnMenu" runat="server" class="btnPrin" Text="Volver a Menú" OnClick="btnSalir_Click"  /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
