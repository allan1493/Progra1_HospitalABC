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
    public partial class Enfer_Admi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargaTablaPersonas();
            //asinga el evento a cada fila
            // Asigna el evento de selección a cada fila del GridView
            foreach (GridViewRow row in GVEfm.Rows)
            {
                row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GVEfm, "Select$" + row.RowIndex);
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admi.aspx");//se redirecciona al Login
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string enfermedad = txt_Enfermedad.Text;
                string descripcion = txt_Descrip.Text;

                if (!string.IsNullOrEmpty(enfermedad) || !string.IsNullOrEmpty(descripcion))
                {
                    string ConStr = "";
                    //getting the path of the file       
                    string path = Server.MapPath("BD/Base.xlsx");
                    //connection string for that file which extantion is .xlsx      
                    ConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;ReadOnly=False;HDR=Yes;\"";
                    //making query      
                    string query = "INSERT INTO [Enfermedades$] ([Enfermedad], [Descripcion]) VALUES('" + enfermedad + "','" + descripcion + "')";
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
                        txt_Enfermedad.Text = "";
                        txt_Descrip.Text = "";
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
                    mensajeTexto.InnerText = "El nombre o la descripcion no puede ser vacío.";
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
                cmd.CommandText = "select * from [Enfermedades$]";
                cmd.Connection = conn;
                OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                oleDbDataAdapter.Fill(dataTable);
                GVEfm.DataSource = dataTable;
                GVEfm.DataBind();

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

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {

                string ConStr = "";
                //getting the path of the file       
                string path = Server.MapPath("BD/Base.xlsx");
                //connection string for that file which extantion is .xlsx      
                ConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;HDR=Yes;\"";
                //making query      
                string query = "UPDATE [Enfermedades$] SET [Enfermedad] = '" + txt_Enfermedad.Text + "', [Descripcion] = '" + txt_Descrip.Text + "' WHERE [Enfermedad] = '" + txtGlobal.Text + "'";
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
                    mensajeTexto.InnerText = "<script>alert('Sucessfully Data Updated Into Excel')</script>";
                    divMensaje.Style["display"] = "block";
                }
                else
                {
                    mensajeTexto.InnerText = "<script>alert('Sorry!\n Update Failed')</script>";
                    divMensaje.Style["display"] = "block";
                }
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

        protected void gridViewEnfermedad_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = GVEfm.Rows[index];
                if (e.CommandName == "Select")
                {


                    txt_Enfermedad.Text = selectedRow.Cells[0].Text;
                    txtGlobal.Text = selectedRow.Cells[0].Text;
                    txt_Descrip.Text = selectedRow.Cells[1].Text;
                    


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

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {

                string ConStr = "";
                //getting the path of the file       
                string path = Server.MapPath("BD/Base.xlsx");
                //connection string for that file which extantion is .xlsx      
                ConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;HDR=Yes;\"";
                //making query      
                string query = "UPDATE [Enfermedades$] SET [Enfermedad] = '', [Descripcion] = '' WHERE [Enfermedad] = '" + txtGlobal.Text + "'";
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
                    mensajeTexto.InnerText = "<script>alert('Sucessfully Data Eliminated')</script>";
                    divMensaje.Style["display"] = "block";
                }
                else
                {
                    mensajeTexto.InnerText = "<script>alert('Sorry!\n Elimination Failed')</script>";
                    divMensaje.Style["display"] = "block";
                }
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
    }
}