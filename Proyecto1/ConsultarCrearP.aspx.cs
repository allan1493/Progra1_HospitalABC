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
    public partial class ConsultarCrearP : System.Web.UI.Page
    {
        List<oTipoIdentificacion> listaTipoIdentifiacion = new List<oTipoIdentificacion>();
        List<oGenero> listaGenero = new List<oGenero>();
        List<oEstadoCivil> listaCivil = new List<oEstadoCivil>();
        List<oProvincia> listaProvincia = new List<oProvincia>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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

                listaProvincia.Add(new oProvincia { id = 1, provincia = "San José" });
                listaProvincia.Add(new oProvincia { id = 2, provincia = "Heredia" });
                listaProvincia.Add(new oProvincia { id = 3, provincia = "Puntarenas" });

                foreach (var item in listaProvincia)
                {
                    DDLProvincia.Items.Add(new ListItem(item.provincia, item.id.ToString()));
                }

            }
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Medic.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                string nombre = txt_Nombre.Text;
                string apellido1 = txt_apellido1.Text;
                string apellido2 = txt_apellido2.Text;
                string tipoID = DDLId.SelectedItem.Text;
                string identificacion = txt_identi.Text;
                string genero = DDLGenero.SelectedItem.Text;
                string estadoCivil = DDLCivil.SelectedItem.Text;
                string fechaNacimiento = Calendar1.SelectedDate.ToShortDateString();
                string residencia = DDLProvincia.SelectedItem.Text;
                string telefono = txt_TN.Text;
                string correo = txt_CE.Text;

                if (!string.IsNullOrEmpty(nombre) || !string.IsNullOrEmpty(identificacion))
                {
                    string ConStr = "";
                    //getting the path of the file       
                    string path = Server.MapPath("BD/Base.xlsx");
                    //connection string for that file which extantion is .xlsx      
                    ConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;ReadOnly=False;HDR=Yes;\"";
                    //making query      
                    string query = "INSERT INTO [Pacientes$] ([Nombre], [Apellido1], [Apellido2], [TipoID], [Identificacion], [Genero], [EstadoCivil], [Nacimiento], [Residencia], [Telefono], [Correo]) VALUES('" + nombre + "','" + apellido1 + "','" + apellido2 + "','" + tipoID + "','" + identificacion + "','" + genero + "','" + estadoCivil + "','" + fechaNacimiento + "','" + residencia + "','" + telefono + "','" + correo + "')";
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

        protected void btnActualizar_Click(object sender, EventArgs e)
        {

        }
    }
}