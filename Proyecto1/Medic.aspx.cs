using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto1
{
    public partial class Medic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Login.aspx");
        }

        protected void btnAdmiEnfer_Click(object sender, EventArgs e)
        {
            Response.Redirect("/enfermedades_Admin.aspx");
        }

        protected void btnAgreCon_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ConsultCitaMedic.aspx");
        }

        protected void btnInfoPaci_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Info_paciente.aspx");
        }

        protected void btnCoC_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ConsultarCrearP.aspx");
        }

        protected void btnEnfeMede_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Medicinas_admi.aspx");
        }

        protected void btnConsulExpe_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ConsulExpe.aspx");
        }

        protected void btnEnfer_Click(object sender, EventArgs e)
        {
            Response.Redirect("/DiagnosticarMedic.aspx");
        }
    }
}