using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto1
{
    public partial class Admi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Login.aspx");//se redirecciona al Login
        }

        protected void btnSucusales_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Sucursales_Admi.aspx");//se manda al form de sucursales
        }

        protected void btnMedicos_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Medico_Admi.aspx");//se manda al form de medico
        }

        protected void btnEnfermedades_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Enfer_Admi.aspx");//se manda al form de enfermedades
        }

        protected void btnMedicamentos_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Medi_Admi.aspx");//se manda al form de medico
        }

        protected void btnMedicoF_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ConsultCitas.aspx");// se manda al form de funciones del medico
        }

        protected void btnCata_Click(object sender, EventArgs e)
        {
            Response.Redirect("/funMedi_Admi.aspx");// se manda al form de catalogos
        }

        protected void btnPaciente_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Paciente_Admi.aspx");// se manda al form de pacientes
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Diagnosticar.aspx");// se manda al form de pacientes
        }
    }
}