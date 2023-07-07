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
using Aspose;
using Aspose.Cells;

namespace Proyecto1
{
    public partial class Medi_Admi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargaTablaPersonas();
            //asinga el evento a cada fila
            // Asigna el evento de selección a cada fila del GridView
            foreach (GridViewRow row in GVMdm.Rows)
            {
                row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GVMdm, "Select$" + row.RowIndex);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                
                string nombre = txtNombre.Text;
                string farmaceutica = txtFarmaceutica.Text;
                string cantidad = txtCantidad.Text;
                

                if (!string.IsNullOrEmpty(nombre) || !string.IsNullOrEmpty(cantidad))
                {
                    string ConStr = "";
                    //getting the path of the file       
                    string path = Server.MapPath("BD/Base.xlsx");
                    //connection string for that file which extantion is .xlsx      
                    ConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;ReadOnly=False;HDR=Yes;\"";
                    //making query      
                    string query = "INSERT INTO [Medicamentos$] ([Nombre], [CasaFarmaceutica], [Cantidad]) VALUES('" + nombre + "','" + farmaceutica + "','" +cantidad +  "')";
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
                        txtCantidad.Text = "";
                        txtFarmaceutica.Text = "";
                        txtNombre.Text = "";
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
                    mensajeTexto.InnerText = "El nombre o la cantidad no puede ser vacío.";
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
                cmd.CommandText = "select * from [Medicamentos$]";
                cmd.Connection = conn;
                OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                oleDbDataAdapter.Fill(dataTable);
                GVMdm.DataSource = dataTable;
                GVMdm.DataBind();

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
            Response.Redirect("/Admi.aspx");//se redirecciona al Login
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
                string query = "UPDATE [Medicamentos$] SET [Nombre] = '" + txtNombre.Text + "', [CasaFarmaceutica] = '" + txtFarmaceutica.Text + "', [Cantidad] = '"+txtCantidad.Text+"' WHERE [Nombre] = '" + txtGlobal.Text + "'";
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

        protected void gridViewMedicamento_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = GVMdm.Rows[index];
                if (e.CommandName == "Select")
                {


                    txtNombre.Text = selectedRow.Cells[0].Text;
                    txtGlobal.Text = selectedRow.Cells[0].Text;
                    txtFarmaceutica.Text = selectedRow.Cells[1].Text;
                    txtCantidad.Text = selectedRow.Cells[2].Text;   


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
                string query = "UPDATE [Medicamentos$] SET [Nombre] = '', [CasaFarmaceutica] = '', [Cantidad] = '' WHERE [Nombre] = '" + txtGlobal.Text + "'";
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
                    mensajeTexto.InnerText = "<script>alert('Sucessfully Data Eliminated from Excel')</script>";
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