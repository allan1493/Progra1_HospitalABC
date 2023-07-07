<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Medic.aspx.cs" Inherits="Proyecto1.Medic" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Medico</title>
    <link href="Style/Style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
            <table class="centrar-Prin text-center tablaLogin" >
                <tr>
                <td colspan="2" class="h1Prin"><h1>Bienvenido Medico</h1></td>
                </tr>
                <tr>
                    <td><asp:Button ID="btnInfoPaci"  runat="server" class="btnPrin" Text="Informacion del paciente" Width="285px" OnClick="btnInfoPaci_Click"/></td>
                    <td><asp:Button ID="btnAdmiEnfer" runat="server" class="btnPrin" Text="Administrar Enfermedades" Width="285px" OnClick="btnAdmiEnfer_Click" /></td>
                </tr>
                <tr>
                    <td><asp:Button ID="btnCoC" runat="server" Text="Consultar o Crear Paciente" class="btnPrin" Width="285px" OnClick="btnCoC_Click"/></td>
                    <td><asp:Button ID="btnEnfeMede" runat="server" class="btnPrin"  Text="Administrar Medicinas" Width="285px" OnClick="btnEnfeMede_Click" /></td>
                </tr>
                <tr>
                    <td><asp:Button ID="btnAgreCon" runat="server" class="btnPrin" Text="Consultar o Crear Citas" Width="285px" OnClick="btnAgreCon_Click" /></td>
                    <td><asp:Button ID="bConsulExpe" runat="server" class="btnPrin" Text="Consultar Expendientes" Width="285px" OnClick="btnConsulExpe_Click" /></td>
                </tr>
                <tr>
                    <td><asp:Button ID="btnEnfer" runat="server" Text="Diagnosticar Paciente" class="btnPrin" OnClick="btnEnfer_Click" Width="286px" /></td>
                </tr>
                <tr>
                   <td>
                       <asp:Button ID="btnSalir" runat="server" class="btnPrin" Text="Salir" OnClick="btnSalir_Click" Width="280px"/></td> 
                </tr>
            </table>
        </div>
        </div>
    </form>
</body>
</html>
