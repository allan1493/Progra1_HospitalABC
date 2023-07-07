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
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace Proyecto1
{
    public partial class Medico_Admi : System.Web.UI.Page
    {
        List<oTipoIdentificacion> listaTipoIdentifiacion = new List<oTipoIdentificacion>();
        List<oGenero> listaGenero = new List<oGenero>();
        List<oEstadoCivil> listaCivil = new List<oEstadoCivil>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargaTablaPersonas();
                //llena la lista de Tipo identificacion
                listaTipoIdentifiacion.Add(new oTipoIdentificacion { id = 1, tipoIdentificacion = "Cédula nacional" });
                listaTipoIdentifiacion.Add(new oTipoIdentificacion { id = 2, tipoIdentificacion = "DIMEX" });
                listaTipoIdentifiacion.Add(new oTipoIdentificacion { id = 3, tipoIdentificacion = "Pasaporte" });

                foreach (var item in listaTipoIdentifiacion)
                {
                    DDLId.Items.Add(new ListItem(item.tipoIdentificacion, item.id.ToString()));
                }

                //*****************************************************
                //llena la lista de Genero
                listaGenero.Add(new oGenero { id = 1, genero = "Hombre" });
                listaGenero.Add(new oGenero { id = 2, genero = "Mujer" });
                listaGenero.Add(new oGenero { id = 3, genero = "Otro" });

                foreach (var item in listaGenero)
                {
                    DDLGenero.Items.Add(new ListItem(item.genero, item.id.ToString()));
                }

                listaCivil.Add(new oEstadoCivil { id = 1, estado = "Soltero(a)" });
                listaCivil.Add(new oEstadoCivil { id = 2, estado = "Casado(a)" });
                listaCivil.Add(new oEstadoCivil { id = 3, estado = "Divorciado(a)" });
                listaCivil.Add(new oEstadoCivil { id = 4, estado = "Viudo(a)" });

                foreach (var item in listaCivil)
                {
                    DDLCivil.Items.Add(new ListItem(item.estado, item.id.ToString()));
                }

                //asinga el evento a cada fila
                // Asigna el evento de selección a cada fila del GridView
                foreach (GridViewRow row in GVMedico.Rows)
                {
                    row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GVMedico, "Select$" + row.RowIndex);
                }

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
                    cmd.CommandText = "select * from [Medicos$]";
                    cmd.Connection = conn;
                    OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    oleDbDataAdapter.Fill(dataTable);
                    GVMedico.DataSource = dataTable;
                    GVMedico.DataBind();
                
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

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txt_Medico.Text;
                string nombre = txt_Nombre.Text;
                string apellido1 = txt_apellido1.Text;
                string apellido2 = txt_apellido2.Text;
                string tipoID = DDLId.SelectedItem.Text;
                string identificacion = txt_identi.Text;
                string genero = DDLGenero.SelectedItem.Text;
                string estadoCivil = DDLCivil.SelectedItem.Text;
                string fechaNacimiento = Calendar1.SelectedDate.ToShortDateString();
                string especialidad = txt_EspeMed.Text;
                string telefono = txt_TN.Text;
                string correo = txt_CE.Text;

                if (!string.IsNullOrEmpty(id) || !string.IsNullOrEmpty(identificacion))
                {
                    string ConStr = "";
                    //getting the path of the file       
                    string path = Server.MapPath("BD/Base.xlsx");
                    //connection string for that file which extantion is .xlsx      
                    ConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;ReadOnly=False;HDR=Yes;\"";
                    //making query      
                    string query = "INSERT INTO [Medicos$] ([ID], [Nombre], [Apellido1], [Apellido2], [TipoID], [Identificacion], [Genero], [EstadoCivil], [Nacimiento], [Especialidad], [Telefono], [Correo]) VALUES('" + id + "','" + nombre + "','" + apellido1 + "','" + apellido2 + "','" + tipoID + "','" + identificacion + "','" + genero + "','" + estadoCivil + "','" + fechaNacimiento + "','" + especialidad + "','" + telefono + "','" + correo +  "')";
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
                        txt_Medico.Text = "";
                        txt_Nombre.Text = "";
                        txt_apellido1.Text = "";
                        txt_apellido2.Text = "";
                        txt_identi.Text = "";
                        txt_EspeMed.Text = "";
                        txt_TN.Text = "";
                        txt_CE.Text = "";
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
                string query = "UPDATE [Medicos$] SET [ID] = '" + txt_Medico.Text +"', [Nombre] = '" + txt_Nombre.Text + "', [Apellido1] = '" + txt_apellido1.Text + "', [Apellido2] = '" + txt_apellido2.Text + "', [TipoID] = '" + DDLId.SelectedItem.Text + "', [Identificacion] ='" + txt_identi.Text + "', [Genero] = '" + DDLGenero.SelectedItem.Text + "', [EstadoCivil] = '" + DDLCivil.SelectedItem.Text + "', [Nacimiento] = '" + Calendar1.SelectedDate.ToShortDateString() + "', [Especialidad] = '"+txt_EspeMed.Text+"',  [Telefono] = '" + txt_TN.Text + "', [Correo] = '" + txt_CE.Text + "' WHERE [ID] = '" + txtGlobal.Text + "'";
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

        protected void gridViewMedico_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = GVMedico.Rows[index];
                if (e.CommandName == "Select")
                {


                    txt_Medico.Text = selectedRow.Cells[0].Text;
                    txt_Nombre.Text = selectedRow.Cells[1].Text;
                    txt_apellido1.Text = selectedRow.Cells[2].Text;
                    txt_apellido2.Text = selectedRow.Cells[3].Text;
                    DDLId.DataTextField = selectedRow.Cells[4].Text;

                    txt_identi.Text = selectedRow.Cells[5].Text;
                    txtGlobal.Text = selectedRow.Cells[0].Text.ToString();
                    DDLGenero.DataTextField = selectedRow.Cells[6].Text;
                    DDLCivil.DataTextField = selectedRow.Cells[7].Text;
                    //Calendar1.VisibleDate = DateTime.Parse(selectedRow.Cells[7].Text);
                    txt_EspeMed.Text = selectedRow.Cells[9].Text;   
                    txt_TN.Text = selectedRow.Cells[10].Text;
                    txt_CE.Text = selectedRow.Cells[11].Text;


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
                string query = "UPDATE [Medicos$] SET [ID] = '', [Nombre] = '', [Apellido1] = '', [Apellido2] = '', [TipoID] = '', [Identificacion] ='', [Genero] = '', [EstadoCivil] = '', [Nacimiento] = '', [Especialidad] = '',  [Telefono] = '', [Correo] = '' WHERE [ID] = '" + txtGlobal.Text + "'";
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
    }
}