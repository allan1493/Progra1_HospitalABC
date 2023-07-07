using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto1
{
    public partial class Info_paciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargaTablaPersonas();
            }
        }

        private void CargaTablaPersonas()
        {
            try
            {
                string connectionstring = "";
                //getting the path of the file       
                string path = Server.MapPath("BD/Base.xlsx");
                connectionstring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;HDR=YES;IMEX=2\"";
                OleDbConnection conn = new OleDbConnection(connectionstring);
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from [Pacientes$]";
                cmd.Connection = conn;
                OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                oleDbDataAdapter.Fill(dataTable);
                GVPct.DataSource = dataTable;
                GVPct.DataBind();

                conn.Close();
            }
            catch (Exception ex)
            {
                // Establecer el texto del mensaje
                mensajeTexto.InnerText = "Ocurrió un error. (Error: " + ex.Message + ")";
                // Mostrar el cuadro de mensaje
                divMensaje.Style["display"] = "block";
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Medic.aspx");
        }
    }
}