<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="ConsultCitas.aspx.cs" Inherits="Proyecto1.ConsultCitas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Consulta o sacar Citas</title>
    <link href="Style/Style.css" rel="stylesheet" />
    <script src="Scripts/General.js"></script>
</head>
<body>
    <div class="containerTable">
            <asp:TextBox ID="txtGlobal" runat="server" Visible="false"></asp:TextBox>
        <form id="frmConsulta" runat="server">
    <table class="centrar-Arriba text-center tablaLogin" >
    <tr><td colspan="2" class="h1Prin"><h1>Listado Citas</h1></td></tr>
    
    
        <tr>
          <td>  <asp:GridView ID="GVConsulta" CssClass="gridview" runat="server" OnRowCommand ="gridViewConsulta_RowCommand"></asp:GridView> </td>
        
   </tr>
       </table>      
            <table class="centrar-Prin text-center tablaLogin">
                <tr>
                <td colspan="2" class="h1Prin"><h1>Crear Cita</h1></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LCita" runat="server" Text="ID Cita: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCita" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LFecha" runat="server" Text="Fecha Cita: "></asp:Label>
                    </td>
                    <td>
                        <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LPaciente" runat="server" Text="Identificación Paciente: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPaciente" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LHora" runat="server" Text="Hora: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txt_Hora" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LSucursal" runat="server" Text="Sucursal: "></asp:Label>

                    </td>
                    <td>
                        <asp:DropDownList ID="DDLSucursal" runat="server"></asp:DropDownList>
                    </td>
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
                        <asp:Button ID="btnGuardar" class="btnPrin" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnAtras" class="btnPrin" runat="server" Text="Atras" OnClick="btnAtras_Click" />
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
