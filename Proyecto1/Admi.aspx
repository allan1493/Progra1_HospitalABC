<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admi.aspx.cs" Inherits="Proyecto1.Admi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Administrador</title>
    <link href="Style/Style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <div>
            <table class="centrar-Prin text-center tablaLogin" >
                <tr>
                <td colspan="2" class="h1Prin"><h1>Bienvenido Administrador</h1></td>
                </tr>
                <tr>
                    <td><asp:Button ID="btnSucusales"  runat="server" class="btnPrin" Text="Adminitrar Sucursales" OnClick="btnSucusales_Click" /></td>
                    <td><asp:Button ID="btnMedicamentos" runat="server" class="btnPrin" Text="Administrar Medicamentos" OnClick="btnMedicamentos_Click" /></td>
                </tr>
                <tr>
                    <td><asp:Button ID="btnMedicos" runat="server" Text="Administrar Medicos" class="btnPrin" OnClick="btnMedicos_Click" /></td>
                    <td><asp:Button ID="btnMedicoF" runat="server" Text="Citas" class="btnPrin" OnClick="btnMedicoF_Click" /></td>
                </tr>
                <tr>
                    <td><asp:Button ID="btnEnfermedades" runat="server" class="btnPrin"  Text="Administrar Enfermedades" Width="243px" OnClick="btnEnfermedades_Click" /></td> 
                    <td><asp:Button ID="btnCata" runat="server" class="btnPrin" Text="Consultar Expendientes" Width="285px" OnClick="btnCata_Click" /></td>
                </tr>
                <tr>
                    <td> 
                        <asp:Button ID="btnPaciente" runat="server" class="btnPrin" Text="Administrar Paciente" OnClick="btnPaciente_Click"  /></td>
                   <td>
                       <asp:Button ID="btnAgregar" runat="server" class="btnPrin" Text="Diagnosticar Paciente" OnClick="btnAgregar_Click" />
                       </td> 
                </tr>
                <tr>
                    <asp:Button ID="btnSalir" runat="server" class="btnPrin" Text="Salir" OnClick="btnSalir_Click"  />
                </tr>
            </table>
        </div>
        </div>
    </form>
</body>
</html>
