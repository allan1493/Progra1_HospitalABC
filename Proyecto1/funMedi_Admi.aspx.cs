using ClosedXML.Excel;
using DocumentFormat.OpenXml.Bibliography;
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
    public partial class funMedi_Admi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GVExpediente.Rows)
            {
                row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GVExpediente, "Select$" + row.RowIndex);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargaTablaExpendiente();
        }

        private void CargaTablaExpendiente()
        {

            if (!string.IsNullOrEmpty(txtPaciente.Text))
            {
                if (!string.IsNullOrEmpty(txtPaciente.Text))
                {
                    try
                    {
                        string connectionstring = "";
                        string query = "SELECT [Pacientes$].[Identificacion] as pacienteID, [Pacientes$].[Nombre] as nomPaciente, [Pacientes$].[Apellido1] as pacApellido1, [Enfermedades$].[Enfermedad] as enfPaciente, [Enfermedades$].[Descripcion] as descEnf, [Medicos$].[ID] as medID, [Medicos$].[Nombre] as nomMed, [Medicos$].[Apellido1] as apMed, [Medicos$].[Especialidad] as espMed, [Medicamentos$].[Nombre] as medic, [Medicamentos$].[CasaFarmaceutica] as farmMedic, [Citas$].[IDCita] as citaID, [Citas$].[Fecha] as fechaCit, [Citas$].[Hora] as horaCit, [Citas$].[Sucursal] as citSuc";
                        query += " FROM ((((([Expediente$] INNER JOIN [Medicos$] ON [Expediente$].[Medico] = [Medicos$].[ID])";
                        query += " INNER JOIN [Pacientes$] ON [Expediente$].[Paciente] = [Pacientes$].[Identificacion])";
                        query += " INNER JOIN [Enfermedades$] ON [Expediente$].[Enfermedad] = [Enfermedades$].[Enfermedad])";
                        query += " INNER JOIN [Medicamentos$] ON [Expediente$].[Medicamento] = [Medicamentos$].[Nombre])";
                        query += " INNER JOIN [Citas$] ON [Expediente$].[Paciente] = [Citas$].[Paciente])";
                        query += " WHERE [Expediente$].[Paciente] = @Paciente";
                        query += " GROUP BY [Pacientes$].[Identificacion], [Pacientes$].[Nombre], [Pacientes$].[Apellido1], [Enfermedades$].[Enfermedad], [Enfermedades$].[Descripcion], [Medicos$].[ID], [Medicos$].[Nombre], [Medicos$].[Apellido1], [Medicos$].[Especialidad], [Medicamentos$].[Nombre], [Medicamentos$].[CasaFarmaceutica], [Citas$].[IDCita], [Citas$].[Fecha], [Citas$].[Hora], [Citas$].[Sucursal];";

                        string path = Server.MapPath("BD/Base.xlsx");
                        connectionstring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;HDR=YES;IMEX=2\"";
                        OleDbConnection conn = new OleDbConnection(connectionstring);
                        OleDbCommand cmd = new OleDbCommand();
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.CommandText = query;
                        cmd.Connection = conn;
                        cmd.Parameters.AddWithValue("@Paciente", txtPaciente.Text);

                        OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(cmd);
                        DataTable dataTable = new DataTable();

                        oleDbDataAdapter.Fill(dataTable);

                        // Eliminar duplicados utilizando un DataView
                         DataView view = new DataView(dataTable);
                         DataTable distinctTable = view.ToTable(true, "pacienteID", "nomPaciente", "pacApellido1", "enfPaciente", "descEnf", "medID", "nomMed", "apMed", "espMed", "medic", "farmMedic", "citaID", "fechaCit", "horaCit", "citSuc");

                         GVExpediente.DataSource = distinctTable;
                        //GVExpediente.DataSource = dataTable;
                        GVExpediente.DataBind();
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
                else
                {
                    // Establecer el texto del mensaje
                    mensajeTexto.InnerText = "El nombre o la identificación no puede ser vacío.";
                    // Mostrar el cuadro de mensaje
                    divMensaje.Style["display"] = "block";
                }
            }
        }


        /* protected void descargarXML()
         {
             try
             {
                 //obtener la lista de la seccion
                 var listaPersonas = (List<oPersona>)Session["listaPersona"];
                 if (listaPersonas != null)
                 {//guarda el archivo de forma local en el servidor, de la libreria de IO
                     var dt = generaTablaDinamica<oPersona>(listaPersonas);//convertir la info a una tabla
                     dt.TableName = "Persona";//nombre de la Tabla



                     DataSet ds = new DataSet("listaPersonas");//aparece como un tag en el archivo.xml
                     ds.Tables.Add(dt);



                     //configurar la ruta para guardar el archivo de forma temporal en el servidor,antes de descargar
                     string random = DateTime.Now.ToFileTime().ToString();
                     string folder = "~/Uploads/";



                     string ruta = Server.MapPath(folder + random + "archivo.xml");



                     //escribir el archivo XML
                     ds.WriteXml(ruta);



                     //devuelve el archivo XML al cliente
                     Response.Clear();
                     Response.AppendHeader("content-disposition", "application;filename=Personas.xml");//cuando el usuario lo vaya a descargar ya tiene el nombre predeterminado
                     Response.ContentType = "application/xml";
                     Response.WriteFile(ruta);
                     Response.End();
                 }
                 else
                 {
                     //establer el texto del mensaje
                     mensajeTexto.InnerText = "No hay datos para descargar";
                     //mostrar el cuadro del mensaje
                     divMensaje.Style["display"] = "block";
                 }
             }
             catch (Exception ex)
             {
                 //establer el texto del mensaje
                 mensajeTexto.InnerText = "No hay datos que mostrar";
                 //mostrar el cuadro del mensaje
                 divMensaje.Style["display"] = "block";
             }
         } */

        protected void gridViewExpediente_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = GVExpediente.Rows[index];
                if (e.CommandName == "Select")
                {



                    txtGlobalPaciente.Text = selectedRow.Cells[0].Text;
                    txtGlobalCita.Text = selectedRow.Cells[4].Text;
                    


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
            Response.Redirect("/Admi.aspx");
        }
    }
}