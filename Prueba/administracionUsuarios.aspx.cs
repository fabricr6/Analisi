using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Text;
using System.IO;
using Datos;

namespace Prueba
{
    public partial class administracionUsuarios : System.Web.UI.Page
    {
        public enum MessageType { Success, Error, Info, Warning };

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                cargar_rol();
                cargarListadoUsuarios();
            }
        }
        private void cargar_rol()
        {
            Data datos = new Data();
            DataSet ds_info = new DataSet();
            string error_msj = "";
            int error_num = 0;
            // Ejecuta PA para obtener listado de los roles
            ds_info = datos.listar_roles("pa_listar_rol", ref error_msj, ref error_num);
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

        protected void ddlRol_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            // Filas
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Oculta la primer columna
                e.Row.Cells[0].Visible = false;
                // Obtiene la fila seleccionada
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gridUsuarios, "Select$" + e.Row.RowIndex);
                // Muestra mensaje de ayuda
                e.Row.ToolTip = "Seleccione el usuario a visualizar.";
            }
            // Encabezados
            if (e.Row.RowType == DataControlRowType.Header)
            {
                // Oculta los encabezados
                e.Row.Cells[0].Visible = false;
                //e.Row.Cells[1].Visible = false;
            }
        }

        protected void gridUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gridUsuarios.Rows)
            {
                // Valida la fila actualmente seleccionada con la posición del mouse
                if (row.RowIndex == gridUsuarios.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#99CCCC");
                    //cargarDatosUsuarios(Int32.Parse(row.Cells[0].Text));
                }
                else
                {
                    if (row.RowState == DataControlRowState.Alternate)
                    {
                        row.BackColor = ColorTranslator.FromHtml("#EFF3FB");
                    }
                    else
                    {
                        row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    }
                    row.ToolTip = "Seleccione esta fila haciendo click";
                }
            }
        }

        private void cargarListadoUsuarios()
        {
            Data datos = new Data();
            DataSet ds_info = new DataSet();
            string error_msj = "";
            int error_num = 0;
            // Ejecuta PA para obtener el listado convocatorias
            ds_info = datos.listar_usuarios("pa_listar_todos_usuarios", ref error_msj, ref error_num);
            if (error_msj == "ok" && error_num == 0)
            {
                if (ds_info != null)
                {
                    // Carga los datos en el datagrid
                    gridUsuarios.DataSource = ds_info;
                    gridUsuarios.DataBind();
                }
            }
        }
    }
}