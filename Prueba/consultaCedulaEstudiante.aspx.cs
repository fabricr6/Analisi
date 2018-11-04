using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;

namespace Prueba
{
    public partial class consultaCedulaEstudiante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void cargarEstIden()
        {
            Data datos = new Data();
            DataSet ds_info = new DataSet();
            string error_msj = "";
            int error_num = 0;
            // Ejecuta PA para obtener listado de los roles
            ds_info = datos.("pa_listar_rol", ref error_msj, ref error_num);
            if (error_msj == "ok" && error_num == 0)
            {
                // Carga los datos en el DRopDownList "ddlrol"
                ddlRol.DataSource = ds_info.Tables[0];
                ddlRol.DataTextField = "nombreRol";
                ddlRol.DataValueField = "idRol";
                ddlRol.DataBind();
                ddlRol.Items.Insert(0, "-- Seleccionar --");
                ddlRol.SelectedIndex = 0;
            }
        }
    }
}