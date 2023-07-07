<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultarCrearP.aspx.cs" Inherits="Proyecto1.ConsultarCrearP" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Consultar o crear paciente</title>
     <link href="Style/Style.css" rel="stylesheet" />
     <script src="Scripts/General.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="centrar-Prin text-center tablaLogin" >
                <tr>
                <td colspan="2" class="h1Prin"><h1>Administrar Pacientes</h1></td>
                </tr>
                <tr>
                <td colspan="2" class="h1Prin"><h3>Información Personal</h3></td>
                </tr>
                
                 <tr>
                <td><asp:Label ID="Nombre" runat="server" Text="Nombre:"></asp:Label></td>
                <td><asp:TextBox ID="txt_Nombre" runat="server" Width="235px"></asp:TextBox></td>
                 </tr>
                 <tr>
                <td><asp:Label ID="Apellido1" runat="server" Text="Primer Apellido:"></asp:Label></td>
                <td><asp:TextBox ID="txt_apellido1" runat="server" Width="235px"></asp:TextBox></td>
                 </tr>
                <tr>
                <td><asp:Label ID="Apellido2" runat="server" Text="Segundo Apellido:"></asp:Label></td>
                <td><asp:TextBox ID="txt_apellido2" runat="server" Width="235px"></asp:TextBox></td>
                 </tr>
                <tr>
                <td><asp:Label ID="identificacion" runat="server" Text="Identificación"></asp:Label></td>
                <td><asp:TextBox ID="txt_identi" runat="server" Width="235px"></asp:TextBox></td>
                 </tr>
               
                <tr>
                    <td><asp:Label ID="lblTI" runat="server" Text="Tipo de identificación"></asp:Label></td>
                    <td> <asp:DropDownList ID="DDLId" runat="server"></asp:DropDownList></td>
                 </tr>
                
                <tr>
                <td><asp:Label ID="lblGenero" runat="server" Text="Género"></asp:Label></td>
                <td><asp:DropDownList ID="DDLGenero" runat="server"></asp:DropDownList></td>
                 </tr>
                <tr>
                    <td><asp:Label ID="lblEC" runat="server" Text="Estado Civil"></asp:Label></td>
                    <td><asp:DropDownList ID="DDLCivil" runat="server"></asp:DropDownList></td>
                 </tr>
                <tr>
                <td><asp:Label ID="Label1" runat="server" Text="Fecha de Nacimiento"></asp:Label></td>
                    <td><asp:Calendar ID="Calendar1" runat="server"></asp:Calendar></td>
                 
                <td colspan="2" class="h1Prin"><h3>Lugar de Residencia</h3></td>
                </tr>
                 <tr>
                <td><asp:Label ID="lblResidencia" runat="server" Text="Provincia"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="DDLProvincia" runat="server"></asp:DropDownList></td>
                 </tr>
                <td colspan="2" class="h1Prin"><h3>Información de contacto</h3></td>
                 <tr>
                
                <td><asp:Label ID="lblNT" runat="server" Text="Números de teléfono"></asp:Label></td>
                <td><asp:TextBox ID="txt_TN" runat="server" Width="235px"></asp:TextBox></td>
                </tr>
                <tr>
                <td><asp:Label ID="lblCE" runat="server" Text="Correo electrónico"></asp:Label></td>
                <td><asp:TextBox ID="txt_CE" runat="server" Width="235px"></asp:TextBox></td>
                </tr>
                <tr>
                 <td><asp:Button ID="btnGuardar" runat="server" class="btnPrin" Text="Guardar" OnClick="btnGuardar_Click"  /></td>
                    <td><asp:Button ID="btnUpdate" runat="server" class="btnPrin" Text="Actualizar" OnClick="btnActualizar_Click"  /></td>
                 <td><asp:Button ID="btnAtras" runat="server" class="btnPrin" Text="Atras" OnClick="btnAtras_Click" Width="487px"/></td> 
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
