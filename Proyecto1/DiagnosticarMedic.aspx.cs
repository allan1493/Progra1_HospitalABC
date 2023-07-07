﻿using ClosedXML.Excel;
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
using static ClosedXML.Excel.XLPredefinedFormat;
namespace Proyecto1
{
    public partial class DiagnosticarMedic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargaTablaCitas();
            //asinga el evento a cada fila
            // Asigna el evento de selección a cada fila del GridView
            foreach (GridViewRow row in GVCitas.Rows)
            {
                row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GVCitas, "Select$" + row.RowIndex);
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
                GVCitas.DataSource = dataTable;
                GVCitas.DataBind();

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

        protected void gridViewCitas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = GVCitas.Rows[index];
                if (e.CommandName == "Select")
                {



                    txtGlobalPaciente.Text = selectedRow.Cells[1].Text;
                    txtGlobalCita.Text = selectedRow.Cells[0].Text;
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

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                string paciente = txtGlobalPaciente.Text;
                string cita = txtGlobalCita.Text;
                string medico = txtMedico.Text;
                string enfermedad = txtEnfermedad.Text;
                string medicamento = txtMedicamento.Text;


                if (!string.IsNullOrEmpty(paciente) || !string.IsNullOrEmpty(cita) || !string.IsNullOrEmpty(medico) || !string.IsNullOrEmpty(enfermedad) || !string.IsNullOrEmpty(medicamento))
                {
                    string ConStr = "";
                    //getting the path of the file       
                    string path = Server.MapPath("BD/Base.xlsx");
                    //connection string for that file which extantion is .xlsx      
                    ConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;ReadOnly=False;HDR=Yes;\"";
                    //making query      
                    string query = "INSERT INTO [Expediente$] ([Paciente], [Enfermedad], [Medico], [Medicamento], [Cita]) VALUES('" + paciente + "','" + enfermedad + "','" + medico + "','" + medicamento + "','" + cita + "')";
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

        protected void btnRemover_Click(object sender, EventArgs e)
        {
            try
            {

                string ConStr = "";
                //getting the path of the file       
                string path = Server.MapPath("BD/Base.xlsx");
                //connection string for that file which extantion is .xlsx      
                ConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;HDR=Yes;\"";
                //making query      
                string query = "UPDATE [Expediente$] SET [Enfermedad] = '' WHERE [Paciente] = '" + txtGlobalPaciente.Text + "'";
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
                    mensajeTexto.InnerText = "<script>alert('Sucessfully Data Eliminated Into Excel')</script>";
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

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admi.aspx");//se redirecciona al Login
        }
    }
}