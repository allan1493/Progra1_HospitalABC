using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto1
{
    public partial class ConsultCitas : System.Web.UI.Page
    {
        List<oProvincia> listaProvincia = new List<oProvincia>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargaTablaCitas();
                listaProvincia.Add(new oProvincia { id = 1, provincia = "San José" });
                listaProvincia.Add(new oProvincia { id = 2, provincia = "Heredia" });
                listaProvincia.Add(new oProvincia { id = 3, provincia = "Puntarenas" });

                foreach (var item in listaProvincia)
                {
                    DDLSucursal.Items.Add(new ListItem(item.provincia, item.id.ToString()));
                }
                //asinga el evento a cada fila
                // Asigna el evento de selección a cada fila del GridView
                foreach (GridViewRow row in GVConsulta.Rows)
                {
                    row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GVConsulta, "Select$" + row.RowIndex);
                }

            }
        }

        private void CargaTablaCitas()
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
                cmd.CommandText = "select * from [Citas$]";
                cmd.Connection = conn;
                OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                oleDbDataAdapter.Fill(dataTable);
                GVConsulta.DataSource = dataTable;
                GVConsulta.DataBind();

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

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                string cita = txtCita.Text;
                string paciente = txtPaciente.Text;
                string fecha = Calendar1.SelectedDate.ToShortDateString();
                string hora = txt_Hora.Text;
                string sucursal = DDLSucursal.SelectedItem.Text;
                string medico = txtMedico.Text;


                if (!string.IsNullOrEmpty(cita) || !string.IsNullOrEmpty(paciente) || !string.IsNullOrEmpty(medico))
                {
                    string ConStr = "";
                    //getting the path of the file       
                    string path = Server.MapPath("BD/Base.xlsx");
                    //connection string for that file which extantion is .xlsx      
                    ConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;ReadOnly=False;HDR=Yes;\"";
                    //making query      
                    string query = "INSERT INTO [Citas$] ([IDCita], [Paciente], [Fecha], [Hora], [Sucursal], [Medico]) VALUES('" + cita + "','" + paciente + "','" + fecha + "','" + hora + "','" + sucursal + "','" + medico + "')";
                    //Providing connection      
                    OleDbConnection conn = new OleDbConnection(ConStr);
                    //checking that connection state is closed or not if closed the       
                    //open the connection      
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    //create command object      
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        mensajeTexto.InnerText = "<script>alert('Sucessfully Data Inserted Into Excel')</script>";
                        divMensaje.Style["display"] = "block";
                    }
                    else
                    {
                        mensajeTexto.InnerText = "<script>alert('Sorry!\n Insertion Failed')</script>";
                        divMensaje.Style["display"] = "block";
                    }
                    conn.Close();




                }
                else
                {
                    // Establecer el texto del mensaje
                    mensajeTexto.InnerText = "El nombre o la identificación no puede ser vacío.";
                    // Mostrar el cuadro de mensaje
                    divMensaje.Style["display"] = "block";
                }
            }
            catch (Exception ex)
            {
                // Establecer el texto del mensaje
                mensajeTexto.InnerText = "Ocurrió un error. (Error: " + ex.Message + ")";
                // Mostrar el cuadro de mensaje
                divMensaje.Style["display"] = "block";
            }
        }


        protected void gridViewConsulta_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = GVConsulta.Rows[index];
                if (e.CommandName == "Select")
                {
                    txtCita.Text = selectedRow.Cells[0].Text;
                    txtPaciente.Text = selectedRow.Cells[1].Text;
                    txtGlobal.Text = selectedRow.Cells[0].Text;
                    txt_Hora.Text = selectedRow.Cells[3].Text;
                    txtMedico.Text = selectedRow.Cells[5].Text;

                }
            }


            catch (Exception ex)
            {
                // Establecer el texto del mensaje
                mensajeTexto.InnerText = "Ocurrió un error. (Error: " + ex.Message + ")";
                // Mostrar el cuadro de mensaje
                divMensaje.Style["display"] = "block";
            }
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admi.aspx");// se manda al form de catalogos
        }
    }
}