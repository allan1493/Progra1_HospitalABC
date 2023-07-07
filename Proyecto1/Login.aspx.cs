using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
                string user = txtLogin.Text;
                string password = txtpassword.Text;

                if (user == "admi" && password == "admi")
                {
                    Response.Redirect("/Admi.aspx");//si el usuario es administrador,va directo al form de admi
                }
                else if (user == "medic" && password == "medic")
            {
                    Response.Redirect("/Medic.aspx");// si el usuario es Medico, va directo al form de medico
                }
                else
                {//si el usuario ingresa la contrasena o usuario mal se les envia un mensaje
                // Establecer el texto del mensaje
                mensajeTexto.InnerText = "Nombre de usuario o contraseña incorrectos.";
                // Mostrar el cuadro de mensaje
                divMensaje.Style["display"] = "block";

            }
            
        }
    }
}