<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Diagnosticar.aspx.cs" Inherits="Proyecto1.Diagnosticar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Diagnosticar Paciente</title>
    <link href="Style/Style.css" rel="stylesheet" />
    <script src="Scripts/General.js"></script>
</head>
<body>

    <div class="containerTable">
            <asp:TextBox ID="txtGlobalCita" runat="server" Visible="false"></asp:TextBox>
        <asp:TextBox ID="txtGlobalPaciente" runat="server" Visible="false"></asp:TextBox>
        <form id="frmPaciente" runat="server">
    <table class="centrar-Arriba text-center tablaLogin" >
    <tr><td><h1>Listado Citas</h1></td></tr>
    
    
        <tr>
          <td>  <asp:GridView ID="GVCitas" CssClass="gridview" runat="server" OnRowCommand ="gridViewCitas_RowCommand"></asp:GridView> </td>
        
   </tr>
    </table>
            <table class="centrar-Prin text-center tablaLogin" >
                <tr>
                <td colspan="2" class="h1Prin"><h1>Diagnosticar Paciente</h1></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LMedico" runat="server" Text="ID Medico: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMedico" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LEnfermedad" runat="server" Text="Enfermedad: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEnfermedad" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LMedicamento" runat="server" Text="Medicamento: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMedicamento" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnGuardar" class="btnPrin" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnRemover" class="btnPrin" runat="server" Text="Remover Enfermedad" OnClick="btnRemover_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnSalir" class="btnPrin" runat="server" Text="Salir" OnClick="btnSalir_Click" />
                    </td>
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
