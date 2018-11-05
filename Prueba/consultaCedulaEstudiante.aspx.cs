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

        public enum MessageType { Success, Error, Info, Warning };

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                cargarEstIden();
            }
        }

        private void cargarEstIden()
        {
            Data datos = new Data();
            DataSet ds_info = new DataSet();
            string error_msj = "";
            int error_num = 0;
            string identificacion = cedula.Value.ToString();
            // Ejecuta PA para obtener listado del estudiante
            ds_info = datos.consultar_estudiantes("pa_listar_todos_usuarios",identificacion, ref error_msj, ref error_num);
            if (error_msj == "ok" && error_num == 0)
            {
                // Carga los datos en el datagrid
                gridEstudiante.DataSource = ds_info;
                gridEstudiante.DataBind();
            }
        }
    }
}