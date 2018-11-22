using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prueba
{
    public partial class cargaArchivos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnCargarDatos_Click(object sender, EventArgs e)
        {
            if (FUBuscarEstudiante.HasFile)
            {
                string ext = System.IO.Path.GetExtension(FUBuscarEstudiante.FileName);
                string direccion = Server.MapPath("~/Archivos/" + FUBuscarEstudiante.FileName);
                if (ext == ".txt")
                {
                    FUBuscarEstudiante.SaveAs(direccion);
                    Data datos = new Data();
                    string error_msj = "";
                    int error_num = 0;
                    if (datos.cargarEstudiante("pa_cargar_estudiantes", direccion, ref error_msj, ref error_num) == 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Se cargo la base de datos exitosamente.');", true);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('El archivo seleccionado no corresponde al archivo que contiene la lista de estudiantes.');", true);
                    }
                    System.IO.File.Delete(direccion);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('El archivo seleccionado no es del formato correcto. Por favor seleccione un archivo de extensión .txt.');", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No se ha seleccionado ningún archivo. Por favor seleccione el archivo que desea cargar');", true);
            }
        }
        protected void btnCargarArchivosMatricula_Click(object sender, EventArgs e)
        {
            if (FUBuscarEstudiante.HasFile)
            {
                if (FUBuscarMatricula.HasFile)
                {
                    string ext = System.IO.Path.GetExtension(FUBuscarMatricula.FileName);
                    string direccion = Server.MapPath("~/Archivos/" + FUBuscarMatricula.FileName);
                    if (ext == ".txt")
                    {
                        FUBuscarMatricula.SaveAs(direccion);
                        Data datos = new Data();
                        string error_msj = "";
                        int error_num = 0;
                        if (datos.cargarMatriculas("pa_cargar_matriculas", direccion, ref error_msj, ref error_num) == 0)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Se cargo la base de datos exitosamente.');", true);
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('El archivo seleccionado no corresponde al archivo que contiene las matrículas.');", true);
                        }
                        System.IO.File.Delete(direccion);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('El archivo seleccionado no es del formato correcto. Por favor seleccione un archivo de extensión .txt.');", true);
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No se ha seleccionado ningún archivo. Por favor seleccione el archivo que desea cargar');", true);
                }
            }
        }
    }
}