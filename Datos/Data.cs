using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Security;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using Conexion;

namespace Datos
{
    public class Data : IDisposable
    {
        SqlConnection conn;
        string error_message = string.Empty;
        int error_number = 0;
        DataSet ds;
        bool disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    ds = null;
                    conn = null;
                    error_message = string.Empty;
                    error_number = 0;
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /*-------*/
        public int ins_contenido_tb(string sql, int opcion, string nom_cont, string txt_cont, bool est_cont, int id_tipo_contenido, string img_galeria, int id_contenido, ref string error_msj, ref int error_num, ref int result, ref int OUT_ID)//Funcion para Insertar contenido en admin_contenido en el metodo "guardarContenido()"
        {
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return -1;
            }
            else
            {
                ParamStruct[] Params = new ParamStruct[9];
                OutPutValues[] OutValues = new OutPutValues[2];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@opcion", SqlDbType.Int, id_contenido, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 1, "@nom_cont", SqlDbType.VarChar, nom_cont, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 2, "@txt_cont", SqlDbType.VarChar, txt_cont, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 3, "@est_cont", SqlDbType.Bit, est_cont, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 4, "@id_tipo_contenido", SqlDbType.Int, id_tipo_contenido, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 5, "@img_galeria", SqlDbType.VarChar, img_galeria, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 6, "@result", SqlDbType.Int, result, ParameterDirection.Output);
                cls_SQL.Add_Data_Param_Struct(ref Params, 7, "@OUT_id", SqlDbType.Int, OUT_ID, ParameterDirection.Output);
                cls_SQL.Add_Data_Param_Struct(ref Params, 8, "@id_contenido", SqlDbType.Int, id_contenido, ParameterDirection.Input);
                cls_SQL.Connect(conn, ref error_message, ref error_number);
                cls_SQL.Execute_SQL_Command(conn, sql, true, Params, ref error_message, ref error_number, ref OutValues);
                if (error_number == 0 && error_message == "ok")
                {
                    result = int.Parse(OutValues[0].Param_Value);
                    OUT_ID = int.Parse(OutValues[1].Param_Value);
                    int e_number = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    if (error_number == 0)
                    {
                        error_num = 0;
                        error_msj = "ok";
                        return e_number;
                    }
                    else
                    {
                        return e_number;
                    }
                }
                else
                {
                    error_msj = error_message;
                    error_num = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return error_number;
                }
            }
        }
        /*------*/
        public int ins_rel_gal_contenido(string sql, int id_galeria, int id_contenido, ref string error_msj, ref int error_num, ref int result)//Funcion utilizada para insertar la galeria de contenido en el metodo "Guardar Contenido" en admin_contenido
        {
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return -1;
            }
            else
            {
                ParamStruct[] Params = new ParamStruct[3];
                OutPutValues[] OutValues = new OutPutValues[1];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@id_categoria", SqlDbType.Int, id_galeria, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 1, "@id_contenido", SqlDbType.Int, id_contenido, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 2, "@result", SqlDbType.Int, result, ParameterDirection.Output);
                cls_SQL.Connect(conn, ref error_message, ref error_number);
                cls_SQL.Execute_SQL_Command(conn, sql, true, Params, ref error_message, ref error_number, ref OutValues);
                if (error_number == 0 && error_message == "ok")
                {
                    result = int.Parse(OutValues[0].Param_Value);
                    int e_number = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    if (error_number == 0)
                    {
                        error_num = 0;
                        error_msj = "ok";
                        return e_number;
                    }
                    else
                    {
                        return e_number;
                    }
                }
                else
                {
                    error_msj = error_message;
                    error_num = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return error_number;
                }
            }
        }
        /*-------*/
        public int eli_id(string sql, int id_generico, ref string error_msj, ref int error_num, ref int result)//procedemiento que elimina el id  usuario bloqueado ,formulario admin_bloqueo metodo  EliminarBloque
        {
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return -1;
            }
            else
            {
                ParamStruct[] Params = new ParamStruct[2];
                OutPutValues[] OutValues = new OutPutValues[1];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@id_generico", SqlDbType.Int, id_generico, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 1, "@result", SqlDbType.Int, result, ParameterDirection.Output);
                cls_SQL.Connect(conn, ref error_message, ref error_number);
                cls_SQL.Execute_SQL_Command(conn, sql, true, Params, ref error_message, ref error_number, ref OutValues);
                if (error_number == 0 && error_message == "ok")
                {
                    result = int.Parse(OutValues[0].Param_Value);
                    int e_number = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    if (error_number == 0)
                    {
                        error_num = 0;
                        error_msj = "ok";
                        return e_number;
                    }
                    else
                    {
                        return e_number;
                    }
                }
                else
                {
                    error_msj = error_message;
                    error_num = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return error_number;
                }
            }
        }
        /*-------*/
        public int ins_rel_rol_contenido(string sql, int id_rol, int id_contenido, ref string error_msj, ref int error_num, ref int result)//Funcion que inserta el rol de contenido en el formulario admin_contenido en el metodo Guardar Contenido
        {
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return -1;
            }
            else
            {
                ParamStruct[] Params = new ParamStruct[3];
                OutPutValues[] OutValues = new OutPutValues[1];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@id_rol", SqlDbType.Int, id_rol, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 1, "@id_contenido", SqlDbType.Int, id_contenido, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 2, "@result", SqlDbType.Int, result, ParameterDirection.Output);
                cls_SQL.Connect(conn, ref error_message, ref error_number);
                cls_SQL.Execute_SQL_Command(conn, sql, true, Params, ref error_message, ref error_number, ref OutValues);
                if (error_number == 0 && error_message == "ok")
                {
                    result = int.Parse(OutValues[0].Param_Value);
                    int e_number = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    if (error_number == 0)
                    {
                        error_num = 0;
                        error_msj = "ok";
                        return e_number;
                    }
                    else
                    {
                        return e_number;
                    }
                }
                else
                {
                    error_msj = error_message;
                    error_num = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return error_number;
                }
            }
        }
        /*-------*/
        public int ins_arch_contenido(string sql, string nom_archivo, int id_contenido, ref string error_msj, ref int error_num, ref int result)//Funcion de insertar  archivo del contenido ubicado en el formulario de admin_contenido en el metodo "GuardarContenido()"
        {
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return -1;
            }
            else
            {
                ParamStruct[] Params = new ParamStruct[3];
                OutPutValues[] OutValues = new OutPutValues[1];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@nom_archivo", SqlDbType.VarChar, nom_archivo, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 1, "@id_contenido", SqlDbType.Int, id_contenido, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 2, "@result", SqlDbType.Int, result, ParameterDirection.Output);
                cls_SQL.Connect(conn, ref error_message, ref error_number);
                cls_SQL.Execute_SQL_Command(conn, sql, true, Params, ref error_message, ref error_number, ref OutValues);
                if (error_number == 0 && error_message == "ok")
                {
                    result = int.Parse(OutValues[0].Param_Value);
                    int e_number = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    if (error_number == 0)
                    {
                        error_num = 0;
                        error_msj = "ok";
                        return e_number;
                    }
                    else
                    {
                        return e_number;
                    }
                }
                else
                {
                    error_msj = error_message;
                    error_num = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return error_number;
                }
            }
        }
        /*-------*/
        public DataSet consult_id2(string sql, int id_generico, ref string error_msj, ref int error_num)
        {
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return null;
            }
            else
            {
                ParamStruct[] Params = new ParamStruct[1];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@id_generico", SqlDbType.Int, id_generico, ParameterDirection.Input);
                ds = cls_SQL.Execute_DS(conn, sql, true, Params, ref error_message, ref error_number);
                if (error_number == 0 && error_message == "ok")
                {
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        if (ds.Tables.Count > 1)
                        {
                            for (int i = 1; i < ds.Tables.Count; i++)
                            {
                                if (ds.Tables[i].Rows.Count > 0)
                                {
                                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                                    error_num = 0;
                                    error_msj = "ok";
                                    return ds;
                                }
                            }
                            cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                            error_num = 0;
                            error_msj = "ok";
                            return null;
                        }
                        else
                        {
                            cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                            error_num = 0;
                            error_msj = "ok";
                            return null;
                        }
                    }
                    else
                    {
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        error_num = 0;
                        error_msj = "ok";
                        return ds;
                    }
                }
                else
                {
                    error_msj = error_message;
                    error_num = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return null;
                }
            }
        }

        /*-------------------Crear usuario-----------------*/
        public DataSet consultar_condicion(string nom_pa, ref string error_msj, ref int error_num)
        {
            // Realiza conexión con la BD
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return null;
            }
            else
            {
                // Ejecuta el PA para realizar la consulta de datos
                ds = cls_SQL.Execute_DS(conn, nom_pa, true, ref error_message, ref error_number);
                if (error_number == 0 && error_message == "ok")
                {
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        error_num = 0;
                        error_msj = "ok";
                        return null;
                    }
                    else
                    {
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        error_num = 0;
                        error_msj = "ok";
                        return ds;
                    }
                }
                else
                {
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return null;
                }
            }
        }

        public DataSet listar_regiones(string nom_pa, ref string error_msj, ref int error_num)
        {
            // Realiza conexión con la BD
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return null;
            }
            else
            {
                // Ejecuta el PA para realizar la consulta de datos
                ds = cls_SQL.Execute_DS(conn, nom_pa, true, ref error_message, ref error_number);
                if (error_number == 0 && error_message == "ok")
                {
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        error_num = 0;
                        error_msj = "ok";
                        return null;
                    }
                    else
                    {
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        error_num = 0;
                        error_msj = "ok";
                        return ds;
                    }
                }
                else
                {
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return null;
                }
            }
        }

        public DataSet listar_roles(string nom_pa, ref string error_msj, ref int error_num)
        {
            // Realiza conexión con la BD
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return null;
            }
            else
            {
                // Ejecuta el PA para realizar la consulta de datos
                ds = cls_SQL.Execute_DS(conn, nom_pa, true, ref error_message, ref error_number);
                if (error_number == 0 && error_message == "ok")
                {
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        error_num = 0;
                        error_msj = "ok";
                        return null;
                    }
                    else
                    {
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        error_num = 0;
                        error_msj = "ok";
                        return ds;
                    }
                }
                else
                {
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return null;
                }
            }
        }

        public DataSet listar_filtro_regiones(string nom_pa, ref string error_msj, ref int error_num)
        {
            // Realiza conexión con la BD
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return null;
            }
            else
            {
                // Ejecuta el PA para realizar la consulta de datos
                ds = cls_SQL.Execute_DS(conn, nom_pa, true, ref error_message, ref error_number);
                if (error_number == 0 && error_message == "ok")
                {
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        error_num = 0;
                        error_msj = "ok";
                        return null;
                    }
                    else
                    {
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        error_num = 0;
                        error_msj = "ok";
                        return ds;
                    }
                }
                else
                {
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return null;
                }
            }
        }

        public int insertar_usuario(string nom_pa, string nom_institucion, string tel_institucion, string nom_encargado, int id_tipo_institucion, int id_nom_region, int id_rol, string usuario, string contrasena, Boolean bad, Boolean bxm, Boolean scs, Boolean tcs, Boolean estado, ref string error_msj, ref int error_num, ref int result)

        {
            int bad_sp, bxm_sp, tcs_sp, scs_sp;

            if (bxm == true)
            {
                bxm_sp = 1;
            }
            else
            {
                bxm_sp = 0;
            }

            if (bad == true)
            {
                bad_sp = 2;
            }
            else
            {
                bad_sp = 0;
            }

            if (tcs == true)
            {
                tcs_sp = 3;
            }
            else
            {
                tcs_sp = 0;
            }

            if (scs == true)
            {
                scs_sp = 4;
            }
            else
            {
                scs_sp = 0;
            }

            // Realiza conexión con la BD
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return -1;
            }
            else
            {
                // Agrega los parámetros 
                ParamStruct[] Params = new ParamStruct[14];
                OutPutValues[] OutValues = new OutPutValues[1];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@nom_usuario", SqlDbType.VarChar, usuario, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 1, "@contrasena", SqlDbType.VarChar, contrasena, ParameterDirection.Input);

                cls_SQL.Add_Data_Param_Struct(ref Params, 2, "@idmadurez", SqlDbType.Int, bxm_sp, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 3, "@idedad", SqlDbType.Int, bad_sp, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 4, "@idsegundo", SqlDbType.Int, tcs_sp, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 5, "@idtercero", SqlDbType.Int, scs_sp, ParameterDirection.Input);

                cls_SQL.Add_Data_Param_Struct(ref Params, 6, "@idrol", SqlDbType.Int, id_rol, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 7, "@estado", SqlDbType.Bit, estado, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 8, "@nombreinsti", SqlDbType.VarChar, nom_institucion, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 9, "@telefono", SqlDbType.VarChar, tel_institucion, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 10, "@encargado", SqlDbType.VarChar, nom_encargado, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 11, "@idtipoinsti", SqlDbType.Int, id_tipo_institucion, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 12, "@idregion", SqlDbType.Int, id_nom_region, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 13, "@result", SqlDbType.Int, result, ParameterDirection.Output);

                // Ejecuta el PA para realizar la inserción de datos
                cls_SQL.Connect(conn, ref error_message, ref error_number);
                cls_SQL.Execute_SQL_Command(conn, nom_pa, true, Params, ref error_message, ref error_number, ref OutValues);
                //
                if (error_number == 0 && error_message == "ok")
                {
                    result = int.Parse(OutValues[0].Param_Value);
                    int e_number = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    if (error_number == 0)
                    {
                        error_num = 0;
                        error_msj = "ok";
                        return e_number;
                    }
                    else
                    {
                        return e_number;
                    }
                }
                else
                {
                    error_msj = error_message;
                    error_num = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return error_number;
                }
            }
        }

        public DataSet consult_id_sede(string sql, int id_generico, ref string error_msj, ref int error_num)
        {
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return null;
            }
            else
            {
                ParamStruct[] Params = new ParamStruct[1];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@idregion", SqlDbType.Int, id_generico, ParameterDirection.Input);
                ds = cls_SQL.Execute_DS(conn, sql, true, Params, ref error_message, ref error_number);
                if (error_number == 0 && error_message == "ok")
                {
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        if (ds.Tables.Count > 1)
                        {
                            for (int i = 1; i < ds.Tables.Count; i++)
                            {
                                if (ds.Tables[i].Rows.Count > 0)
                                {
                                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                                    error_num = 0;
                                    error_msj = "ok";
                                    return ds;
                                }
                            }
                            cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                            error_num = 0;
                            error_msj = "ok";
                            return null;
                        }
                        else
                        {
                            cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                            error_num = 0;
                            error_msj = "ok";
                            return null;
                        }
                    }
                    else
                    {
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        error_num = 0;
                        error_msj = "ok";
                        return ds;
                    }
                }
                else
                {
                    error_msj = error_message;
                    error_num = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return null;
                }
            }
        }

        public DataSet consult_id_usuario(string sql, int id_generico, ref string error_msj, ref int error_num)
        {
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return null;
            }
            else
            {
                ParamStruct[] Params = new ParamStruct[1];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@id_generico", SqlDbType.Int, id_generico, ParameterDirection.Input);
                ds = cls_SQL.Execute_DS(conn, sql, true, Params, ref error_message, ref error_number);
                if (error_number == 0 && error_message == "ok")
                {
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        if (ds.Tables.Count > 1)
                        {
                            for (int i = 1; i < ds.Tables.Count; i++)
                            {
                                if (ds.Tables[i].Rows.Count > 0)
                                {
                                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                                    error_num = 0;
                                    error_msj = "ok";
                                    return ds;
                                }
                            }
                            cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                            error_num = 0;
                            error_msj = "ok";
                            return null;
                        }
                        else
                        {
                            cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                            error_num = 0;
                            error_msj = "ok";
                            return null;
                        }
                    }
                    else
                    {
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        error_num = 0;
                        error_msj = "ok";
                        return ds;
                    }
                }
                else
                {
                    error_msj = error_message;
                    error_num = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return null;
                }
            }
        }

        public DataSet consult_info_paquete(string sql, int id_generico, ref string error_msj, ref int error_num)
        {
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return null;
            }
            else
            {
                ParamStruct[] Params = new ParamStruct[1];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@idpaquete", SqlDbType.Int, id_generico, ParameterDirection.Input);
                ds = cls_SQL.Execute_DS(conn, sql, true, Params, ref error_message, ref error_number);
                if (error_number == 0 && error_message == "ok")
                {
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        if (ds.Tables.Count > 1)
                        {
                            for (int i = 1; i < ds.Tables.Count; i++)
                            {
                                if (ds.Tables[i].Rows.Count > 0)
                                {
                                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                                    error_num = 0;
                                    error_msj = "ok";
                                    return ds;
                                }
                            }
                            cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                            error_num = 0;
                            error_msj = "ok";
                            return null;
                        }
                        else
                        {
                            cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                            error_num = 0;
                            error_msj = "ok";
                            return null;
                        }
                    }
                    else
                    {
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        error_num = 0;
                        error_msj = "ok";
                        return ds;
                    }
                }
                else
                {
                    error_msj = error_message;
                    error_num = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return null;
                }
            }
        }

        public DataSet consultar_id_usuario(string nom_pa, int id_usuario, ref string error_msj, ref int error_num, ref int bad, ref int madurez, ref int tcs, ref int scs)
        {
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return null;
            }
            else
            {
                // Agrega los parámetros 

                ParamStruct[] Params = new ParamStruct[5];
                OutPutValues[] OutValues = new OutPutValues[4];

                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@idusuario", SqlDbType.Int, id_usuario, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 1, "@madurez", SqlDbType.Int, madurez, ParameterDirection.Output);
                cls_SQL.Add_Data_Param_Struct(ref Params, 2, "@edad", SqlDbType.Int, bad, ParameterDirection.Output);
                cls_SQL.Add_Data_Param_Struct(ref Params, 3, "@segundo", SqlDbType.Int, scs, ParameterDirection.Output);
                cls_SQL.Add_Data_Param_Struct(ref Params, 4, "@tercero", SqlDbType.Int, tcs, ParameterDirection.Output);

                // Ejecuta el PA para realizar la consulta de datos
                ds = cls_SQL.Execute_DS(conn, nom_pa, true, Params, ref error_message, ref error_number);
                if (error_number == 0 && error_message == "ok")
                {
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        error_num = 0;
                        error_msj = "ok";
                        return null;
                    }
                    else
                    {
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        error_num = 0;
                        error_msj = "ok";
                        return ds;
                    }
                }
                else
                {
                    error_msj = error_message;
                    error_num = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return null;
                }
            }
        }

        public DataSet consultar_usuarios(string nom_pa, ref string error_msj, ref int error_num)
        {
            // Realiza conexión con la BD
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return null;
            }
            else
            {
                // Ejecuta el PA para realizar la consulta de datos
                ds = cls_SQL.Execute_DS(conn, nom_pa, true, ref error_message, ref error_number);
                if (error_number == 0 && error_message == "ok")
                {
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        error_num = 0;
                        error_msj = "ok";
                        return null;
                    }
                    else
                    {
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        error_num = 0;
                        error_msj = "ok";
                        return ds;
                    }
                }
                else
                {
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return null;
                }

            }
        }

        public DataSet ver_inicio_sesion(string sql, string usu, string cnt, ref string error_msj, ref int error_num)
        {
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return null;
            }
            else
            {
                ParamStruct[] Params = new ParamStruct[2];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@nom_usuario", SqlDbType.VarChar, usu, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 1, "@contrasena", SqlDbType.VarChar, cnt, ParameterDirection.Input);
                ds = cls_SQL.Execute_DS(conn, sql, true, Params, ref error_message, ref error_number);
                if (error_number == 0 && error_message == "ok")
                {
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        error_num = 0;
                        error_msj = "ok";
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        return null;
                    }
                    else
                    {
                        error_num = 0;
                        error_msj = "ok";
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        return ds;
                    }
                }
                else
                {
                    error_msj = error_message;
                    error_num = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return null;
                }
            }
        }

        public DataSet ver_transferencia_paquete(string sql, int idusuario, int idinstitucion, int idpaquete, ref string error_msj, ref int error_num, ref int result)
        {
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return null;
            }
            else
            {
                ParamStruct[] Params = new ParamStruct[4];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@idusuario", SqlDbType.Int, idusuario, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 1, "@idpaquete", SqlDbType.Int, idpaquete, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 2, "@idinstitucion", SqlDbType.Int, idinstitucion, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 3, "@result", SqlDbType.Int, result, ParameterDirection.Output);

                ds = cls_SQL.Execute_DS(conn, sql, true, Params, ref error_message, ref error_number);

                if (error_number == 0 && error_message == "ok")
                {
                    if (ds.Tables[0].Rows.Count <= 0)
                    {

                        error_num = 0;
                        error_msj = "ok";
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        return null;
                    }
                    else
                    {
                        error_num = 0;
                        error_msj = "ok";
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        return ds;
                    }
                }
                else
                {
                    error_msj = error_message;
                    error_num = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return null;
                }
            }
        }

        public DataSet verificar_id_prematricula(string sql, string identificacion, int id_convocatoria, ref string error_msj, ref int error_num, ref int result)
        {
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return null;
            }
            else
            {
                ParamStruct[] Params = new ParamStruct[3];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@cedula", SqlDbType.VarChar, identificacion, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 1, "@idconvo", SqlDbType.Int, id_convocatoria, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 2, "@result", SqlDbType.Int, result, ParameterDirection.Output);

                ds = cls_SQL.Execute_DS(conn, sql, true, Params, ref error_message, ref error_number);

                if (error_number == 0 && error_message == "ok")
                {
                    if (ds.Tables[0].Rows.Count <= 0)
                    {

                        error_num = 0;
                        error_msj = "ok";
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        return null;
                    }
                    else
                    {

                        error_num = 0;
                        error_msj = "ok";
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        return ds;
                    }
                }
                else
                {
                    error_msj = error_message;
                    error_num = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return null;
                }
            }
        }

        public int verificar_id_prematricul_correccion(string nom_pa, string identificacion, int id_convocatoria, ref string error_msj, ref int error_num, ref int result)
        {                                                                                   //string nom_pa, string identificacion, ref string error_msj, ref int error_num, ref int result
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return -1;
            }
            else
            {
                ParamStruct[] Params = new ParamStruct[3];
                OutPutValues[] OutValues = new OutPutValues[1];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@cedula", SqlDbType.VarChar, identificacion, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 1, "@idconvo", SqlDbType.Int, id_convocatoria, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 2, "@result", SqlDbType.Int, result, ParameterDirection.Output);

                // Ejecuta el PA 
                cls_SQL.Connect(conn, ref error_message, ref error_number);
                cls_SQL.Execute_SQL_Command(conn, nom_pa, true, Params, ref error_message, ref error_number, ref OutValues);

                //ds = cls_SQL.Execute_DS(conn, sql, true, Params, ref error_message, ref error_number, ref OutValues);

                if (error_number == 0 && error_message == "ok")
                {
                    result = int.Parse(OutValues[0].Param_Value);
                    int e_number = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    if (error_number == 0)
                    {
                        error_num = 0;
                        error_msj = "ok";
                        return e_number;
                    }
                    else
                    {
                        return e_number;
                    }
                }
                else
                {
                    error_msj = error_message;
                    error_num = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return error_number;
                }

            }
        }

        public int actualizar_usuario(string nom_pa, int id_usuario, string nombre_institucion, string telefono, string encargado, int id_tipo_institucion, int id_region, int id_rol, string nom_usuario, string contrasena, int BXM, int BAD, int SCS, int TCS, bool estado, ref string error_msj, ref int error_num, ref int result)
        {


            // Realiza conexión con la BD
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return -1;
            }
            else
            {
                // Agrega los parámetros 
                ParamStruct[] Params = new ParamStruct[15];
                OutPutValues[] OutValues = new OutPutValues[1];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@idusuario", SqlDbType.Int, id_usuario, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 1, "@nombreinsti", SqlDbType.VarChar, nombre_institucion, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 2, "@telefono", SqlDbType.VarChar, telefono, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 3, "@encargado", SqlDbType.VarChar, encargado, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 4, "@id_tipo_institucion", SqlDbType.Int, id_tipo_institucion, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 5, "@idregion", SqlDbType.Int, id_region, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 6, "@idrol", SqlDbType.Int, id_rol, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 7, "@nom_usuario", SqlDbType.VarChar, nom_usuario, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 8, "@contrasena", SqlDbType.VarChar, contrasena, ParameterDirection.Input);

                cls_SQL.Add_Data_Param_Struct(ref Params, 9, "@madurez", SqlDbType.Int, BXM, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 10, "@edad", SqlDbType.Int, BAD, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 11, "@segundo", SqlDbType.Int, SCS, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 12, "@tercero", SqlDbType.Int, TCS, ParameterDirection.Input);

                cls_SQL.Add_Data_Param_Struct(ref Params, 13, "@estado", SqlDbType.Bit, estado, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 14, "@result", SqlDbType.Int, result, ParameterDirection.Output);
                // Ejecuta el PA para realizar la actualización de datos
                cls_SQL.Connect(conn, ref error_message, ref error_number);
                cls_SQL.Execute_SQL_Command(conn, nom_pa, true, Params, ref error_message, ref error_number, ref OutValues);
                //
                if (error_number == 0 && error_message == "ok")
                {
                    result = int.Parse(OutValues[0].Param_Value);
                    int e_number = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    if (error_number == 0)
                    {
                        error_num = 0;
                        error_msj = "ok";
                        return e_number;
                    }
                    else
                    {
                        return e_number;
                    }
                }
                else
                {
                    error_msj = error_message;
                    error_num = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return error_number;
                }
            }
        }

        public int eliminar_usuario(string nom_pa, int id_usuario, ref string error_msj, ref int error_num, ref int result)
        {
            // Realiza conexión con la BD
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return -1;
            }
            else
            {
                // Agrega los parámetros 
                ParamStruct[] Params = new ParamStruct[2];
                OutPutValues[] OutValues = new OutPutValues[1];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@idusuario", SqlDbType.Int, id_usuario, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 1, "@result", SqlDbType.Int, result, ParameterDirection.Output);
                cls_SQL.Connect(conn, ref error_message, ref error_number);
                // Ejecuta el PA para realizar la eliminación de datos
                cls_SQL.Execute_SQL_Command(conn, nom_pa, true, Params, ref error_message, ref error_number, ref OutValues);
                if (error_number == 0 && error_message == "ok")
                {
                    result = int.Parse(OutValues[0].Param_Value);
                    int e_number = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    if (error_number == 0)
                    {
                        error_num = 0;
                        error_msj = "ok";
                        return e_number;
                    }
                    else
                    {
                        error_num = 0;
                        error_msj = "ok";
                        return e_number;
                    }
                }
                else
                {
                    error_num = error_number;
                    error_msj = error_message;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return error_number;
                }
            }
        }

        public DataSet consultar_propuesta(string sql, string identificacion, int id_convocatoria, ref string error_msj, ref int error_num)
        {
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return null;
            }
            else
            {
                ParamStruct[] Params = new ParamStruct[2];

                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@cedula", SqlDbType.VarChar, identificacion, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 1, "@idconvo", SqlDbType.Int, id_convocatoria, ParameterDirection.Input);


                ds = cls_SQL.Execute_DS(conn, sql, true, Params, ref error_message, ref error_number);

                if (error_number == 0 && error_message == "ok")
                {

                    if (ds.Tables[0].Rows.Count <= 0)
                    {

                        error_num = 0;
                        error_msj = "ok";
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        return null;
                    }
                    else
                    {

                        error_num = 0;
                        error_msj = "ok";
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        return ds;
                    }
                }
                else
                {
                    error_msj = error_message;
                    error_num = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return null;
                }
            }
        }

        public int consultar_si_existe_estudiante(string nom_pa, string identificacion, ref string error_msj, ref int error_num, ref int result)
        {
            // Realiza conexión con la BD
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return -1;
            }
            else
            {
                // Agrega los parámetros 
                ParamStruct[] Params = new ParamStruct[2];
                OutPutValues[] OutValues = new OutPutValues[1];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@cedula", SqlDbType.VarChar, identificacion, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 1, "@result", SqlDbType.Int, result, ParameterDirection.Output);

                // Ejecuta el PA para realizar la inserción de datos
                cls_SQL.Connect(conn, ref error_message, ref error_number);
                cls_SQL.Execute_SQL_Command(conn, nom_pa, true, Params, ref error_message, ref error_number, ref OutValues);
                //
                if (error_number == 0 && error_message == "ok")
                {
                    result = int.Parse(OutValues[0].Param_Value);
                    int e_number = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    if (error_number == 0)
                    {
                        error_num = 0;
                        error_msj = "ok";
                        return e_number;
                    }
                    else
                    {
                        return e_number;
                    }
                }
                else
                {
                    error_msj = error_message;
                    error_num = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return error_number;
                }
            }
        }


        public DataSet verificar_region_institucion(string sql, int id_institucion, ref string error_msj, ref int error_num)
        {
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return null;
            }
            else
            {
                ParamStruct[] Params = new ParamStruct[1];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@idinstitucion", SqlDbType.Int, id_institucion, ParameterDirection.Input);

                ds = cls_SQL.Execute_DS(conn, sql, true, Params, ref error_message, ref error_number);
                if (error_number == 0 && error_message == "ok")
                {
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        error_num = 0;
                        error_msj = "ok";
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        return null;
                    }
                    else
                    {
                        error_num = 0;
                        error_msj = "ok";
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        return ds;
                    }
                }
                else
                {
                    error_msj = error_message;
                    error_num = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return null;
                }
            }
        }

        public DataSet consultar_id_estudiante(string sql, string cedula, ref string error_msj, ref int error_num)
        {
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return null;
            }
            else
            {
                ParamStruct[] Params = new ParamStruct[1];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@cedula", SqlDbType.VarChar, cedula, ParameterDirection.Input);

                ds = cls_SQL.Execute_DS(conn, sql, true, Params, ref error_message, ref error_number);
                if (error_number == 0 && error_message == "ok")
                {
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        error_num = 0;
                        error_msj = "ok";
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        return null;
                    }
                    else
                    {
                        error_num = 0;
                        error_msj = "ok";
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        return ds;
                    }
                }
                else
                {
                    error_msj = error_message;
                    error_num = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return null;
                }
            }
        }

        /*---------------Crear convocatoria---------------*/
        //Lista los programas tal cual están en la tabla
        public DataSet listar_programa_ddl(string nom_pa, ref string error_msj, ref int error_num)
        {
            // Realiza conexión con la BD
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return null;
            }
            else
            {
                // Ejecuta el PA para realizar la consulta de datos
                ds = cls_SQL.Execute_DS(conn, nom_pa, true, ref error_message, ref error_number);
                if (error_number == 0 && error_message == "ok")
                {
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        error_num = 0;
                        error_msj = "ok";
                        return null;
                    }
                    else
                    {
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        error_num = 0;
                        error_msj = "ok";
                        return ds;
                    }
                }
                else
                {
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return null;
                }
            }
        }

        //Insertar la convocatoria 
        public int insertar_convocatoria(string nom_pa, string nom_convocatoria, DateTime fechafinal, DateTime fechainicio, int id_programa, Boolean estado_pa, int num_prueba, ref string error_msj, ref int error_num, ref int result)
        {
            // Realiza conexión con la BD
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return -1;
            }
            else
            {
                // Agrega los parámetros 
                ParamStruct[] Params = new ParamStruct[7];
                OutPutValues[] OutValues = new OutPutValues[1];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@nomconvo", SqlDbType.VarChar, nom_convocatoria, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 1, "@fechafin", SqlDbType.DateTime2, fechafinal, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 2, "@fechainicio", SqlDbType.DateTime2, fechainicio, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 3, "@idprograma", SqlDbType.Int, id_programa, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 4, "@estado", SqlDbType.Bit, estado_pa, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 5, "@numconvoca", SqlDbType.Int, num_prueba, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 6, "@result", SqlDbType.Int, result, ParameterDirection.Output);

                // Ejecuta el PA para realizar la inserción de datos
                cls_SQL.Connect(conn, ref error_message, ref error_number);
                cls_SQL.Execute_SQL_Command(conn, nom_pa, true, Params, ref error_message, ref error_number, ref OutValues);
                //
                if (error_number == 0 && error_message == "ok")
                {
                    result = int.Parse(OutValues[0].Param_Value);
                    int e_number = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    if (error_number == 0)
                    {
                        error_num = 0;
                        error_msj = "ok";
                        return e_number;
                    }
                    else
                    {
                        return e_number;
                    }
                }
                else
                {
                    error_msj = error_message;
                    error_num = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return error_number;
                }
            }
        }

        //Retorna un listado general de las convocatorias, no se le aplica filtro
        public DataSet listar_usuarios(string nom_pa, ref string error_msj, ref int error_num)
        {
            // Realiza conexión con la BD
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return null;
            }
            else
            {
                // Ejecuta el PA para realizar la consulta de datos
                ds = cls_SQL.Execute_DS(conn, nom_pa, true, ref error_message, ref error_number);
                if (error_number == 0 && error_message == "ok")
                {
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        error_num = 0;
                        error_msj = "ok";
                        return null;
                    }
                    else
                    {
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        error_num = 0;
                        error_msj = "ok";
                        return ds;
                    }
                }
                else
                {
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return null;
                }
            }
        }

        //Se usa para cargar el listado de paquetes en el ddl
        public DataSet consultar_paquetes_1(string nom_pa, ref string error_msj, ref int error_num)
        {
            // Realiza conexión con la BD
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return null;
            }
            else
            {
                // Ejecuta el PA para realizar la consulta de datos
                ds = cls_SQL.Execute_DS(conn, nom_pa, true, ref error_message, ref error_number);
                if (error_number == 0 && error_message == "ok")
                {
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        error_num = 0;
                        error_msj = "ok";
                        return null;
                    }
                    else
                    {
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        error_num = 0;
                        error_msj = "ok";
                        return ds;
                    }
                }
                else
                {
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return null;
                }
            }
        }

        //Se usa para cargar el listado de paquetes en el grid (prueba)
        public DataSet consultar_paquetes(string sql, int id_convocatoria, int id_institucion, ref string error_msj, ref int error_num)
        {
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return null;
            }
            else
            {
                ParamStruct[] Params = new ParamStruct[2];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@idconvo", SqlDbType.Int, id_convocatoria, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 1, "@idinstitucion", SqlDbType.Int, id_institucion, ParameterDirection.Input);
                ds = cls_SQL.Execute_DS(conn, sql, true, Params, ref error_message, ref error_number);
                if (error_number == 0 && error_message == "ok")
                {
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        error_num = 0;
                        error_msj = "ok";
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        return null;
                    }
                    else
                    {
                        error_num = 0;
                        error_msj = "ok";
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        return ds;
                    }
                }
                else
                {
                    error_msj = error_message;
                    error_num = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return null;
                }
            }
        }

        //Se usa para cargar el listado de estudiantes en el grid 
        public DataSet consultar_estudiantes_paquete(string sql, int id_convocatoria, int id_paquete, int id_programa, int num_convoca, ref string error_msj, ref int error_num)
        {
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return null;
            }
            else
            {
                ParamStruct[] Params = new ParamStruct[4];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@idpaquete", SqlDbType.Int, id_paquete, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 1, "@idconvo", SqlDbType.Int, id_convocatoria, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 2, "@idprograma", SqlDbType.Int, id_programa, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 3, "@numconvoca", SqlDbType.Int, num_convoca, ParameterDirection.Input);
                ds = cls_SQL.Execute_DS(conn, sql, true, Params, ref error_message, ref error_number);
                if (error_number == 0 && error_message == "ok")
                {
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        error_num = 0;
                        error_msj = "ok";
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        return null;
                    }
                    else
                    {
                        error_num = 0;
                        error_msj = "ok";
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        return ds;
                    }
                }
                else
                {
                    error_msj = error_message;
                    error_num = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return null;
                }
            }
        }

        //Se usa para cargar el id del programa por medio del id de la convocatoria
        public DataSet consultar_id_programa(string sql, int id_convocatoria, ref string error_msj, ref int error_num)
        {
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return null;
            }
            else
            {
                ParamStruct[] Params = new ParamStruct[1];

                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@idconvocatoria", SqlDbType.Int, id_convocatoria, ParameterDirection.Input);
                ds = cls_SQL.Execute_DS(conn, sql, true, Params, ref error_message, ref error_number);
                if (error_number == 0 && error_message == "ok")
                {
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        error_num = 0;
                        error_msj = "ok";
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        return null;
                    }
                    else
                    {
                        error_num = 0;
                        error_msj = "ok";
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        return ds;
                    }
                }
                else
                {
                    error_msj = error_message;
                    error_num = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return null;
                }
            }
        }
        //Consulta para reporte de paquete, lista los estudiantes y materias en un paquete puntual
        public DataSet consultar_estudiantes_paquete2(string sql, int id_convocatoria, int id_paquete, ref string error_msj, ref int error_num)
        {
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return null;
            }
            else
            {
                ParamStruct[] Params = new ParamStruct[2];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@idpaquete", SqlDbType.Int, id_paquete, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 1, "@idconvo", SqlDbType.Int, id_convocatoria, ParameterDirection.Input);
                ds = cls_SQL.Execute_DS(conn, sql, true, Params, ref error_message, ref error_number);
                if (error_number == 0 && error_message == "ok")
                {
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        error_num = 0;
                        error_msj = "ok";
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        return null;
                    }
                    else
                    {
                        error_num = 0;
                        error_msj = "ok";
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        return ds;
                    }
                }
                else
                {
                    error_msj = error_message;
                    error_num = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return null;
                }
            }
        }

        //Consulta para llamar la prematricula de un estudiante en específico
        public DataSet consultar_estudiante_prematricula(string sql, int id_estudiante, int id_convocatoria, ref string error_msj, ref int error_num)
        {
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return null;
            }
            else
            {
                ParamStruct[] Params = new ParamStruct[2];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@idestudiante", SqlDbType.Int, id_estudiante, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 1, "@idconvo", SqlDbType.Int, id_convocatoria, ParameterDirection.Input);
                ds = cls_SQL.Execute_DS(conn, sql, true, Params, ref error_message, ref error_number);
                if (error_number == 0 && error_message == "ok")
                {
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        error_num = 0;
                        error_msj = "ok";
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        return null;
                    }
                    else
                    {
                        error_num = 0;
                        error_msj = "ok";
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        return ds;
                    }
                }
                else
                {
                    error_msj = error_message;
                    error_num = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return null;
                }
            }
        }

        //Elimina la convocatoria pasando el id por parámetro
        public int eliminar_convocatoria(string nom_pa, int id_convocatoria, ref string error_msj, ref int error_num, ref int result)
        {
            // Realiza conexión con la BD
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return -1;
            }
            else
            {
                // Agrega los parámetros 
                ParamStruct[] Params = new ParamStruct[2];
                OutPutValues[] OutValues = new OutPutValues[1];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@id_convocatoria", SqlDbType.Int, id_convocatoria, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 1, "@result", SqlDbType.Int, result, ParameterDirection.Output);
                cls_SQL.Connect(conn, ref error_message, ref error_number);
                // Ejecuta el PA para realizar la eliminación de datos
                cls_SQL.Execute_SQL_Command(conn, nom_pa, true, Params, ref error_message, ref error_number, ref OutValues);
                if (error_number == 0 && error_message == "ok")
                {
                    result = int.Parse(OutValues[0].Param_Value);
                    int e_number = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    if (error_number == 0)
                    {
                        error_num = 0;
                        error_msj = "ok";
                        return e_number;
                    }
                    else
                    {
                        error_num = 0;
                        error_msj = "ok";
                        return e_number;
                    }
                }
                else
                {
                    error_num = error_number;
                    error_msj = error_message;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return error_number;
                }
            }
        }

        //Actualizar convocatoria
        public int actualizar_convocatoria(string nom_pa, int id_convocatoria, string nom_convocatoria, DateTime fecha_inicio, DateTime fecha_fin, bool estado, int id_programa, int num_convoca, ref string error_msj, ref int error_num, ref int result)
        {
            // Realiza conexión con la BD
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return -1;
            }
            else
            {
                // Agrega los parámetros 
                ParamStruct[] Params = new ParamStruct[8];
                OutPutValues[] OutValues = new OutPutValues[1];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@idconvocatoria", SqlDbType.Int, id_convocatoria, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 1, "@nombreconvocatoria", SqlDbType.VarChar, nom_convocatoria, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 2, "@fechainicio", SqlDbType.DateTime2, fecha_inicio, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 3, "@fechafin", SqlDbType.DateTime2, fecha_fin, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 4, "@idestado", SqlDbType.Bit, estado, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 5, "@idprograma", SqlDbType.Int, id_programa, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 6, "@numconvoca", SqlDbType.Int, num_convoca, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 7, "@result", SqlDbType.Int, result, ParameterDirection.Output);
                // Ejecuta el PA para realizar la inserción de datos
                cls_SQL.Connect(conn, ref error_message, ref error_number);
                cls_SQL.Execute_SQL_Command(conn, nom_pa, true, Params, ref error_message, ref error_number, ref OutValues);
                //
                if (error_number == 0 && error_message == "ok")
                {
                    result = int.Parse(OutValues[0].Param_Value);
                    int e_number = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    if (error_number == 0)
                    {
                        error_num = 0;
                        error_msj = "ok";
                        return e_number;
                    }
                    else
                    {
                        return e_number;
                    }
                }
                else
                {
                    error_msj = error_message;
                    error_num = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return error_number;
                }
            }
        }

        //Consulta convocatoria por ID
        public DataSet consultar_id_convocatoria(string nom_pa, int id_convocatoria, ref string error_msj, ref int error_num)
        {
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return null;
            }
            else
            {
                // Agrega los parámetros 
                ParamStruct[] Params = new ParamStruct[1];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@id_convocatoria", SqlDbType.Int, id_convocatoria, ParameterDirection.Input);
                // Ejecuta el PA para realizar la consulta de datos
                ds = cls_SQL.Execute_DS(conn, nom_pa, true, Params, ref error_message, ref error_number);
                if (error_number == 0 && error_message == "ok")
                {
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        error_num = 0;
                        error_msj = "ok";
                        return null;
                    }
                    else
                    {
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        error_num = 0;
                        error_msj = "ok";
                        return ds;
                    }
                }
                else
                {
                    error_msj = error_message;
                    error_num = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return null;
                }
            }
        }

        /*-------------Prematrícula-----------*/
        public DataSet listar_convocatorias_activas(string nom_pa, ref string error_msj, ref int error_num)
        {
            // Realiza conexión con la BD
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return null;
            }
            else
            {
                // Ejecuta el PA para realizar la consulta de datos
                ds = cls_SQL.Execute_DS(conn, nom_pa, true, ref error_message, ref error_number);
                if (error_number == 0 && error_message == "ok")
                {
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        error_num = 0;
                        error_msj = "ok";
                        return null;
                    }
                    else
                    {
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        error_num = 0;
                        error_msj = "ok";
                        return ds;
                    }
                }
                else
                {
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return null;
                }
            }
        }

        public DataSet listar_convocatorias_activas_por_institucion(string sql, int id_institucion, ref string error_msj, ref int error_num)
        {
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return null;
            }
            else
            {
                ParamStruct[] Params = new ParamStruct[1];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@idinstitucion", SqlDbType.Int, id_institucion, ParameterDirection.Input);
                ds = cls_SQL.Execute_DS(conn, sql, true, Params, ref error_message, ref error_number);
                if (error_number == 0 && error_message == "ok")
                {
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        error_num = 0;
                        error_msj = "ok";
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        return null;
                    }
                    else
                    {
                        error_num = 0;
                        error_msj = "ok";
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        return ds;
                    }
                }
                else
                {
                    error_msj = error_message;
                    error_num = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return null;
                }
            }
        }

        public DataSet consult_info(string sql, ref string error_msj, ref int error_num)
        {
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return null;
            }
            else
            {

                ds = cls_SQL.Execute_DS(conn, sql, true, ref error_message, ref error_number);
                if (error_number == 0 && error_message == "ok")
                {
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        error_num = 0;
                        error_msj = "ok";
                        return null;
                    }
                    else
                    {
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        error_num = 0;
                        error_msj = "ok";
                        return ds;
                    }
                }
                else
                {
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return null;
                }
            }
        }

        public DataSet consult_id(string sql, int id_generico, ref string error_msj, ref int error_num)
        {
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return null;
            }
            else
            {
                ParamStruct[] Params = new ParamStruct[1];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@idprograma", SqlDbType.Int, id_generico, ParameterDirection.Input);
                ds = cls_SQL.Execute_DS(conn, sql, true, Params, ref error_message, ref error_number);
                if (error_number == 0 && error_message == "ok")
                {
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        if (ds.Tables.Count > 1)
                        {
                            for (int i = 1; i < ds.Tables.Count; i++)
                            {
                                if (ds.Tables[i].Rows.Count > 0)
                                {
                                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                                    error_num = 0;
                                    error_msj = "ok";
                                    return ds;
                                }
                            }
                            cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                            error_num = 0;
                            error_msj = "ok";
                            return null;
                        }
                        else
                        {
                            cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                            error_num = 0;
                            error_msj = "ok";
                            return null;
                        }
                    }
                    else
                    {
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        error_num = 0;
                        error_msj = "ok";
                        return ds;
                    }
                }
                else
                {
                    error_msj = error_message;
                    error_num = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return null;
                }
            }
        }

        public DataSet consult_convo_unica(string sql, int id_generico, ref string error_msj, ref int error_num)
        {
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return null;
            }
            else
            {
                ParamStruct[] Params = new ParamStruct[1];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@idconvo", SqlDbType.Int, id_generico, ParameterDirection.Input);
                ds = cls_SQL.Execute_DS(conn, sql, true, Params, ref error_message, ref error_number);
                if (error_number == 0 && error_message == "ok")
                {
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        if (ds.Tables.Count > 1)
                        {
                            for (int i = 1; i < ds.Tables.Count; i++)
                            {
                                if (ds.Tables[i].Rows.Count > 0)
                                {
                                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                                    error_num = 0;
                                    error_msj = "ok";
                                    return ds;
                                }
                            }
                            cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                            error_num = 0;
                            error_msj = "ok";
                            return null;
                        }
                        else
                        {
                            cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                            error_num = 0;
                            error_msj = "ok";
                            return null;
                        }
                    }
                    else
                    {
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        error_num = 0;
                        error_msj = "ok";
                        return ds;
                    }
                }
                else
                {
                    error_msj = error_message;
                    error_num = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return null;
                }
            }
        }

        public DataSet listar_paquetes_disponibles(string sql, int id_convocatoria, int id_institucion, ref string error_msj, ref int error_num)
        {
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return null;
            }
            else
            {
                ParamStruct[] Params = new ParamStruct[2];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@idconvo", SqlDbType.Int, id_convocatoria, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 1, "@idinstitucion", SqlDbType.Int, id_institucion, ParameterDirection.Input);
                ds = cls_SQL.Execute_DS(conn, sql, true, Params, ref error_message, ref error_number);
                if (error_number == 0 && error_message == "ok")
                {
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        error_num = 0;
                        error_msj = "ok";
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        return null;
                    }
                    else
                    {
                        error_num = 0;
                        error_msj = "ok";
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        return ds;
                    }
                }
                else
                {
                    error_msj = error_message;
                    error_num = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return null;
                }
            }
        }

        public DataSet cargar_paquete_click(string sql, int id_convocatoria, int id_institucion, int id_paquete, ref string error_msj, ref int error_num)
        {
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return null;
            }
            else
            {
                ParamStruct[] Params = new ParamStruct[3];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@idconvo", SqlDbType.Int, id_convocatoria, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 1, "@idinstitucion", SqlDbType.Int, id_institucion, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 2, "@idpaquete", SqlDbType.Int, id_paquete, ParameterDirection.Input);
                ds = cls_SQL.Execute_DS(conn, sql, true, Params, ref error_message, ref error_number);
                if (error_number == 0 && error_message == "ok")
                {
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        error_num = 0;
                        error_msj = "ok";
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        return null;
                    }
                    else
                    {
                        error_num = 0;
                        error_msj = "ok";
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        return ds;
                    }
                }
                else
                {
                    error_msj = error_message;
                    error_num = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return null;
                }
            }
        }

        public DataSet contador_boletas_prematriculadas(string sql, int id_convocatoria, int id_institucion, int id_paquete, ref string error_msj, ref int error_num)
        {
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return null;
            }
            else
            {
                ParamStruct[] Params = new ParamStruct[3];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@idconvo", SqlDbType.Int, id_convocatoria, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 1, "@idinstitucion", SqlDbType.Int, id_institucion, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 2, "@idpaquete", SqlDbType.Int, id_paquete, ParameterDirection.Input);
                ds = cls_SQL.Execute_DS(conn, sql, true, Params, ref error_message, ref error_number);
                if (error_number == 0 && error_message == "ok")
                {
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        error_num = 0;
                        error_msj = "ok";
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        return null;
                    }
                    else
                    {
                        error_num = 0;
                        error_msj = "ok";
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        return ds;
                    }
                }
                else
                {
                    error_msj = error_message;
                    error_num = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return null;
                }
            }
        }

        public DataSet verificar_disp_paquete(string sql, int id_convocatoria, int id_institucion, ref string error_msj, ref int error_num, ref int total)
        {
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return null;
            }
            else
            {
                ParamStruct[] Params = new ParamStruct[3];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@idconvo", SqlDbType.Int, id_convocatoria, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 1, "@idinstitucion", SqlDbType.Int, id_institucion, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 2, "@total", SqlDbType.Int, total, ParameterDirection.Output);

                ds = cls_SQL.Execute_DS(conn, sql, true, Params, ref error_message, ref error_number);
                if (error_number == 0 && error_message == "ok")
                {
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        error_num = 0;
                        error_msj = "ok";
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        return null;
                    }
                    else
                    {
                        error_num = 0;
                        error_msj = "ok";
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        return ds;
                    }
                }
                else
                {
                    error_msj = error_message;
                    error_num = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return null;
                }
            }
        }

        public DataSet listar_condicion_paquete(string nom_pa, ref string error_msj, ref int error_num)
        {
            // Realiza conexión con la BD
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return null;
            }
            else
            {
                // Ejecuta el PA para realizar la consulta de datos
                ds = cls_SQL.Execute_DS(conn, nom_pa, true, ref error_message, ref error_number);
                if (error_number == 0 && error_message == "ok")
                {
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        error_num = 0;
                        error_msj = "ok";
                        return null;
                    }
                    else
                    {
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        error_num = 0;
                        error_msj = "ok";
                        return ds;
                    }
                }
                else
                {
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return null;
                }
            }
        }

        public int insertar_paquete(string nom_pa, Boolean estado_paquete, int id_convocatoria, int tamano_paq, int num_paquete, int tipoPaqueteCondicion, int id_institucion, ref string error_msj, ref int error_num, ref int result)
        {
            // Realiza conexión con la BD
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return -1;
            }
            else
            {
                // Agrega los parámetros 
                ParamStruct[] Params = new ParamStruct[7];
                OutPutValues[] OutValues = new OutPutValues[1];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@estado", SqlDbType.Bit, estado_paquete, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 1, "@tamano", SqlDbType.Int, tamano_paq, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 2, "@numeropaq", SqlDbType.Int, num_paquete, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 3, "@idcondicion", SqlDbType.Int, tipoPaqueteCondicion, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 4, "@idinstitucion", SqlDbType.Int, id_institucion, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 5, "@idconvo", SqlDbType.Int, id_convocatoria, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 6, "@result", SqlDbType.Int, result, ParameterDirection.Output);

                // Ejecuta el PA para realizar la inserción de datos
                cls_SQL.Connect(conn, ref error_message, ref error_number);
                cls_SQL.Execute_SQL_Command(conn, nom_pa, true, Params, ref error_message, ref error_number, ref OutValues);
                //
                if (error_number == 0 && error_message == "ok")
                {
                    result = int.Parse(OutValues[0].Param_Value);
                    int e_number = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    if (error_number == 0)
                    {
                        error_num = 0;
                        error_msj = "ok";
                        return e_number;
                    }
                    else
                    {
                        return e_number;
                    }
                }
                else
                {
                    error_msj = error_message;
                    error_num = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return error_number;
                }
            }
        }

        public int eliminar_paquete(string nom_pa, int id_paquete, ref string error_msj, ref int error_num, ref int result)
        {
            // Realiza conexión con la BD
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return -1;
            }
            else
            {
                // Agrega los parámetros 
                ParamStruct[] Params = new ParamStruct[2];
                OutPutValues[] OutValues = new OutPutValues[1];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@idpaquete", SqlDbType.Int, id_paquete, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 1, "@result", SqlDbType.Int, result, ParameterDirection.Output);
                cls_SQL.Connect(conn, ref error_message, ref error_number);
                // Ejecuta el PA para realizar la eliminación de datos
                cls_SQL.Execute_SQL_Command(conn, nom_pa, true, Params, ref error_message, ref error_number, ref OutValues);
                if (error_number == 0 && error_message == "ok")
                {
                    result = int.Parse(OutValues[0].Param_Value);
                    int e_number = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    if (error_number == 0)
                    {
                        error_num = 0;
                        error_msj = "ok";
                        return e_number;
                    }
                    else
                    {
                        error_num = 0;
                        error_msj = "ok";
                        return e_number;
                    }
                }
                else
                {
                    error_num = error_number;
                    error_msj = error_message;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return error_number;
                }
            }
        }

        public int actualizar_paquete(string nom_pa, int id_paquete, int tamano_paquete, int numero_paquete, Boolean estado, int id_condicion, ref string error_msj, ref int error_num, ref int result)
        {


            // Realiza conexión con la BD
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return -1;
            }
            else
            {
                // Agrega los parámetros 
                ParamStruct[] Params = new ParamStruct[6];
                OutPutValues[] OutValues = new OutPutValues[1];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@idpaquete", SqlDbType.Int, id_paquete, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 1, "@estado", SqlDbType.Bit, estado, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 2, "@tamano", SqlDbType.Int, tamano_paquete, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 3, "@numeropaq", SqlDbType.Int, numero_paquete, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 4, "@idcondicion", SqlDbType.Int, id_condicion, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 5, "@result", SqlDbType.Int, result, ParameterDirection.Output);
                // Ejecuta el PA para realizar la actualización de datos
                cls_SQL.Connect(conn, ref error_message, ref error_number);
                cls_SQL.Execute_SQL_Command(conn, nom_pa, true, Params, ref error_message, ref error_number, ref OutValues);
                //
                if (error_number == 0 && error_message == "ok")
                {
                    result = int.Parse(OutValues[0].Param_Value);
                    int e_number = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    if (error_number == 0)
                    {
                        error_num = 0;
                        error_msj = "ok";
                        return e_number;
                    }
                    else
                    {
                        return e_number;
                    }
                }
                else
                {
                    error_msj = error_message;
                    error_num = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return error_number;
                }
            }
        }

        public DataSet consultar_nacimientos(string nom_pa, string identificacion, ref string error_msj, ref int error_num)
        {
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return null;
            }
            else
            {
                // Agrega los parámetros 
                ParamStruct[] Params = new ParamStruct[1];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@cedula", SqlDbType.VarChar, identificacion, ParameterDirection.Input);
                // Ejecuta el PA para realizar la consulta de datos
                ds = cls_SQL.Execute_DS(conn, nom_pa, true, Params, ref error_message, ref error_number);
                if (error_number == 0 && error_message == "ok")
                {
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        error_num = 0;
                        error_msj = "ok";
                        return null;
                    }
                    else
                    {
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        error_num = 0;
                        error_msj = "ok";
                        return ds;
                    }
                }
                else
                {
                    error_msj = error_message;
                    error_num = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return null;
                }
            }
        }

        public DataSet consultar_estudiantes(string nom_pa, string identificacion, ref string error_msj, ref int error_num)
        {

            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return null;
            }
            else
            {
                // Agrega los parámetros 
                ParamStruct[] Params = new ParamStruct[1];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@cedula", SqlDbType.VarChar, identificacion, ParameterDirection.Input);
                // Ejecuta el PA para realizar la consulta de datos
                ds = cls_SQL.Execute_DS(conn, nom_pa, true, Params, ref error_message, ref error_number);
                if (error_number == 0 && error_message == "ok")
                {
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        error_num = 0;
                        error_msj = "ok";
                        return null;
                    }
                    else
                    {
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        error_num = 0;
                        error_msj = "ok";
                        return ds;
                    }
                }
                else
                {
                    error_msj = error_message;
                    error_num = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return null;
                }
            }
        }

        public DataSet calcular_edad(string sql, string id_generico, ref string error_msj, ref int error_num)
        {
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return null;
            }
            else
            {
                ParamStruct[] Params = new ParamStruct[1];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@cedula", SqlDbType.VarChar, id_generico, ParameterDirection.Input);
                ds = cls_SQL.Execute_DS(conn, sql, true, Params, ref error_message, ref error_number);
                if (error_number == 0 && error_message == "ok")
                {
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        if (ds.Tables.Count > 1)
                        {
                            for (int i = 1; i < ds.Tables.Count; i++)
                            {
                                if (ds.Tables[i].Rows.Count > 0)
                                {
                                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                                    error_num = 0;
                                    error_msj = "ok";
                                    return ds;
                                }
                            }
                            cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                            error_num = 0;
                            error_msj = "ok";
                            return null;
                        }
                        else
                        {
                            cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                            error_num = 0;
                            error_msj = "ok";
                            return null;
                        }
                    }
                    else
                    {
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        error_num = 0;
                        error_msj = "ok";
                        return ds;
                    }
                }
                else
                {
                    error_msj = error_message;
                    error_num = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return null;
                }
            }
        }

        public DataSet consult_id_dist(string sql, int id_generico, ref string error_msj, ref int error_num)
        {
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return null;
            }
            else
            {
                ParamStruct[] Params = new ParamStruct[1];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@numprueba", SqlDbType.Int, id_generico, ParameterDirection.Input);
                ds = cls_SQL.Execute_DS(conn, sql, true, Params, ref error_message, ref error_number);
                if (error_number == 0 && error_message == "ok")
                {
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        if (ds.Tables.Count > 1)
                        {
                            for (int i = 1; i < ds.Tables.Count; i++)
                            {
                                if (ds.Tables[i].Rows.Count > 0)
                                {
                                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                                    error_num = 0;
                                    error_msj = "ok";
                                    return ds;
                                }
                            }
                            cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                            error_num = 0;
                            error_msj = "ok";
                            return null;
                        }
                        else
                        {
                            cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                            error_num = 0;
                            error_msj = "ok";
                            return null;
                        }
                    }
                    else
                    {
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        error_num = 0;
                        error_msj = "ok";
                        return ds;
                    }
                }
                else
                {
                    error_msj = error_message;
                    error_num = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return null;
                }
            }
        }

        //Consulta el id de prematricula de una materia en específico
        public DataSet consultar_id_prem_materia(string nom_pa, string cedula, int materia, int id_convocatoria, int id_programa, ref string error_msj, ref int error_num)
        {

            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return null;
            }
            else
            {
                // Agrega los parámetros 
                ParamStruct[] Params = new ParamStruct[4];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@cedula", SqlDbType.VarChar, cedula, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 1, "@idmateria ", SqlDbType.Int, materia, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 2, "@idconvo", SqlDbType.Int, id_convocatoria, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 3, "@idprograma", SqlDbType.Int, id_programa, ParameterDirection.Input);
                // Ejecuta el PA para realizar la consulta de datos
                ds = cls_SQL.Execute_DS(conn, nom_pa, true, Params, ref error_message, ref error_number);
                if (error_number == 0 && error_message == "ok")
                {
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        error_num = 0;
                        error_msj = "ok";
                        return null;
                    }
                    else
                    {
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        error_num = 0;
                        error_msj = "ok";
                        return ds;
                    }
                }
                else
                {
                    error_msj = error_message;
                    error_num = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return null;
                }
            }
        }

        //Insertar estudiante
        public int insertar_estudiante(string nom_pa, string cedula, string nombre, string apel1, string apel2, int edad, string telefono, Boolean genero, DateTime fecha_nacimiento, string nomCon, string apelcon1, string apelcon2, Boolean exonerado, Boolean extranjero, Boolean indocumentado, Boolean conocido, ref string error_msj, ref int error_num, ref int result)
        {
            // Realiza conexión con la BD
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return -1;
            }
            else
            {
                // Agrega los parámetros 
                ParamStruct[] Params = new ParamStruct[16];
                OutPutValues[] OutValues = new OutPutValues[1];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@cedula", SqlDbType.VarChar, cedula, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 1, "@nombre", SqlDbType.VarChar, nombre, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 2, "@apel1", SqlDbType.VarChar, apel1, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 3, "@apel2", SqlDbType.VarChar, apel2, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 4, "@edad", SqlDbType.Int, edad, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 5, "@fecha", SqlDbType.DateTime2, fecha_nacimiento, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 6, "@telefono", SqlDbType.VarChar, telefono, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 7, "@genero", SqlDbType.Bit, genero, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 8, "@apecon1", SqlDbType.VarChar, apelcon1, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 9, "@apecon2", SqlDbType.VarChar, apelcon2, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 10, "@nomcon", SqlDbType.VarChar, nomCon, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 11, "@exonerado", SqlDbType.Bit, exonerado, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 12, "@extranjero", SqlDbType.Bit, extranjero, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 13, "@indocumentado", SqlDbType.Bit, indocumentado, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 14, "@conocido", SqlDbType.Bit, conocido, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 15, "@result", SqlDbType.Int, result, ParameterDirection.Output);

                // Ejecuta el PA para realizar la inserción de datos
                cls_SQL.Connect(conn, ref error_message, ref error_number);
                cls_SQL.Execute_SQL_Command(conn, nom_pa, true, Params, ref error_message, ref error_number, ref OutValues);
                //
                if (error_number == 0 && error_message == "ok")
                {
                    result = int.Parse(OutValues[0].Param_Value);
                    int e_number = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    if (error_number == 0)
                    {
                        error_num = 0;
                        error_msj = "ok";
                        return e_number;
                    }
                    else
                    {
                        return e_number;
                    }
                }
                else
                {
                    error_msj = error_message;
                    error_num = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return error_number;
                }
            }
        }

        //Actualizar estudiante
        public int actualizar_estudiante(string nom_pa, int id_estudiante, string cedula, string nombre, string apel1, string apel2, int edad, string telefono, Boolean genero, DateTime fecha_nacimiento, string nomCon, string apelcon1, string apelcon2, Boolean exonerado, Boolean extranjero, Boolean indocumentado, Boolean conocido, ref string error_msj, ref int error_num, ref int result)
        {
            // Realiza conexión con la BD
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return -1;
            }
            else
            {
                // Agrega los parámetros 
                ParamStruct[] Params = new ParamStruct[17];
                OutPutValues[] OutValues = new OutPutValues[1];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@idestudiante", SqlDbType.Int, id_estudiante, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 1, "@cedula", SqlDbType.VarChar, cedula, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 2, "@nombre", SqlDbType.VarChar, nombre, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 3, "@apel1", SqlDbType.VarChar, apel1, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 4, "@apel2", SqlDbType.VarChar, apel2, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 5, "@edad", SqlDbType.Int, edad, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 6, "@fecha", SqlDbType.DateTime2, fecha_nacimiento, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 7, "@telefono", SqlDbType.VarChar, telefono, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 8, "@genero", SqlDbType.Bit, genero, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 9, "@apecon1", SqlDbType.VarChar, apelcon1, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 10, "@apecon2", SqlDbType.VarChar, apelcon2, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 11, "@nomcon", SqlDbType.VarChar, nomCon, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 12, "@conocido", SqlDbType.Bit, conocido, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 13, "@exonerado", SqlDbType.Bit, exonerado, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 14, "@extranjero", SqlDbType.Bit, extranjero, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 15, "@indocumentado", SqlDbType.Bit, indocumentado, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 16, "@result", SqlDbType.Int, result, ParameterDirection.Output);
                // Ejecuta el PA para realizar la inserción de datos
                cls_SQL.Connect(conn, ref error_message, ref error_number);
                cls_SQL.Execute_SQL_Command(conn, nom_pa, true, Params, ref error_message, ref error_number, ref OutValues);
                //
                if (error_number == 0 && error_message == "ok")
                {
                    result = int.Parse(OutValues[0].Param_Value);
                    int e_number = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    if (error_number == 0)
                    {
                        error_num = 0;
                        error_msj = "ok";
                        return e_number;
                    }
                    else
                    {
                        return e_number;
                    }
                }
                else
                {
                    error_msj = error_message;
                    error_num = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return error_number;
                }
            }
        }

        //Inserción de la prematrícula
        public int insertar_prematricula(string nom_pa, string identificacion, int id_convocatoria, int id_programa, int id_Paquete, int id_condicion, int id_materia, int id_region, int id_sede, int id_institucion, int id_region_inst, ref string error_msj, ref int error_num, ref int result)
        {
            // Realiza conexión con la BD
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return -1;
            }
            else
            {
                // Agrega los parámetros 
                ParamStruct[] Params = new ParamStruct[11];
                OutPutValues[] OutValues = new OutPutValues[1];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@cedula", SqlDbType.Int, identificacion, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 1, "@idconvocatoria", SqlDbType.Int, id_convocatoria, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 2, "@idprograma", SqlDbType.Int, id_programa, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 3, "@idpaquete", SqlDbType.Int, id_Paquete, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 4, "@idcondicion", SqlDbType.Int, id_condicion, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 5, "@idmateria", SqlDbType.Int, id_materia, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 6, "@idregion", SqlDbType.Int, id_region, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 7, "@idsede", SqlDbType.Int, id_sede, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 8, "@idinstitucion", SqlDbType.Int, id_institucion, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 9, "@idregioninsti", SqlDbType.Int, id_region_inst, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 10, "@result", SqlDbType.Int, result, ParameterDirection.Output);

                // Ejecuta el PA para realizar la inserción de datos
                cls_SQL.Connect(conn, ref error_message, ref error_number);
                cls_SQL.Execute_SQL_Command(conn, nom_pa, true, Params, ref error_message, ref error_number, ref OutValues);
                //
                if (error_number == 0 && error_message == "ok")
                {
                    result = int.Parse(OutValues[0].Param_Value);
                    int e_number = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    if (error_number == 0)
                    {
                        error_num = 0;
                        error_msj = "ok";
                        return e_number;
                    }
                    else
                    {
                        return e_number;
                    }
                }
                else
                {
                    error_msj = error_message;
                    error_num = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return error_number;
                }
            }
        }

        //Actualizar prematricula
        public int actualizar_prematricula(string nom_pa, int id_prematricula, string identificacion, int id_convocatoria, int id_programa, int id_Paquete, int id_condicion, int id_materia, int id_region, int id_sede, int id_institucion, ref string error_msj, ref int error_num, ref int result)
        {
            // Realiza conexión con la BD
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return -1;
            }
            else
            {
                // Agrega los parámetros 
                ParamStruct[] Params = new ParamStruct[11];
                OutPutValues[] OutValues = new OutPutValues[1];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@cedula", SqlDbType.Int, identificacion, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 1, "@idconvocatoria", SqlDbType.Int, id_convocatoria, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 2, "@idprograma", SqlDbType.Int, id_programa, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 3, "@idpaquete", SqlDbType.Int, id_Paquete, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 4, "@idcondicion", SqlDbType.Int, id_condicion, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 5, "@idmateria", SqlDbType.Int, id_materia, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 6, "@idregion", SqlDbType.Int, id_region, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 7, "@idsede", SqlDbType.Int, id_sede, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 8, "@idinstitucion", SqlDbType.Int, id_institucion, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 9, "@idprematricula", SqlDbType.Int, id_prematricula, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 10, "@result", SqlDbType.Int, result, ParameterDirection.Output);

                // Ejecuta el PA para realizar la inserción de datos
                cls_SQL.Connect(conn, ref error_message, ref error_number);
                cls_SQL.Execute_SQL_Command(conn, nom_pa, true, Params, ref error_message, ref error_number, ref OutValues);
                //
                if (error_number == 0 && error_message == "ok")
                {
                    result = int.Parse(OutValues[0].Param_Value);
                    int e_number = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    if (error_number == 0)
                    {
                        error_num = 0;
                        error_msj = "ok";
                        return e_number;
                    }
                    else
                    {
                        return e_number;
                    }
                }
                else
                {
                    error_msj = error_message;
                    error_num = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return error_number;
                }
            }
        }

        //Eliminar prematrícula
        public int eliminar_prematricula(string nom_pa, int id_estudiante, int id_convocatoria, ref string error_msj, ref int error_num, ref int result)
        {
            // Realiza conexión con la BD
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return -1;
            }
            else
            {
                // Agrega los parámetros 
                ParamStruct[] Params = new ParamStruct[3];
                OutPutValues[] OutValues = new OutPutValues[1];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@idestudiante", SqlDbType.Int, id_estudiante, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 1, "@idconvo", SqlDbType.Int, id_convocatoria, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 2, "@result", SqlDbType.Int, result, ParameterDirection.Output);
                cls_SQL.Connect(conn, ref error_message, ref error_number);
                // Ejecuta el PA para realizar la eliminación de datos
                cls_SQL.Execute_SQL_Command(conn, nom_pa, true, Params, ref error_message, ref error_number, ref OutValues);
                if (error_number == 0 && error_message == "ok")
                {
                    result = int.Parse(OutValues[0].Param_Value);
                    int e_number = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    if (error_number == 0)
                    {
                        error_num = 0;
                        error_msj = "ok";
                        return e_number;
                    }
                    else
                    {
                        error_num = 0;
                        error_msj = "ok";
                        return e_number;
                    }
                }
                else
                {
                    error_num = error_number;
                    error_msj = error_message;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return error_number;
                }
            }
        }

        //Eliminar solo una materia de la prematrícula, es decir, no la prematricula completa
        public int eliminar_materia_prematricula(string nom_pa, int id_prematricula, ref string error_msj, ref int error_num, ref int result)
        {
            // Realiza conexión con la BD
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return -1;
            }
            else
            {
                // Agrega los parámetros 
                ParamStruct[] Params = new ParamStruct[2];
                OutPutValues[] OutValues = new OutPutValues[1];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@idprematricula", SqlDbType.Int, id_prematricula, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 1, "@result", SqlDbType.Int, result, ParameterDirection.Output);
                cls_SQL.Connect(conn, ref error_message, ref error_number);
                // Ejecuta el PA para realizar la eliminación de datos
                cls_SQL.Execute_SQL_Command(conn, nom_pa, true, Params, ref error_message, ref error_number, ref OutValues);
                if (error_number == 0 && error_message == "ok")
                {
                    result = int.Parse(OutValues[0].Param_Value);
                    int e_number = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    if (error_number == 0)
                    {
                        error_num = 0;
                        error_msj = "ok";
                        return e_number;
                    }
                    else
                    {
                        error_num = 0;
                        error_msj = "ok";
                        return e_number;
                    }
                }
                else
                {
                    error_num = error_number;
                    error_msj = error_message;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return error_number;
                }
            }
        }
        /*---------------Reportes-----------*/
        //consult_idx2
        public DataSet consulta_rptUsuarios(string sql, int id_generico1, int id_generico2, ref string error_msj, ref int error_num)
        {
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return null;
            }
            else
            {
                ParamStruct[] Params = new ParamStruct[2];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@id_generico1", SqlDbType.Int, id_generico1, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 1, "@id_generico2", SqlDbType.Int, id_generico2, ParameterDirection.Input);
                ds = cls_SQL.Execute_DS(conn, sql, true, Params, ref error_message, ref error_number);
                if (error_number == 0 && error_message == "ok")
                {
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        if (ds.Tables.Count > 1)
                        {
                            for (int i = 1; i < ds.Tables.Count; i++)
                            {
                                if (ds.Tables[i].Rows.Count > 0)
                                {
                                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                                    error_num = 0;
                                    error_msj = "ok";
                                    return ds;
                                }
                            }
                            cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                            error_num = 0;
                            error_msj = "ok";
                            return null;
                        }
                        else
                        {
                            cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                            error_num = 0;
                            error_msj = "ok";
                            return null;
                        }
                    }
                    else
                    {
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        error_num = 0;
                        error_msj = "ok";
                        return ds;
                    }
                }
                else
                {
                    error_msj = error_message;
                    error_num = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return null;
                }
            }
        }

        public DataSet consult_estudiante_materias(string sql, string id_usuario, int id_convocatoria, ref string error_msj, ref int error_num)
        {
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return null;
            }
            else
            {
                ParamStruct[] Params = new ParamStruct[2];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@cedula", SqlDbType.VarChar, id_usuario, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 1, "@idconvo", SqlDbType.Int, id_convocatoria, ParameterDirection.Input);
                ds = cls_SQL.Execute_DS(conn, sql, true, Params, ref error_message, ref error_number);
                if (error_number == 0 && error_message == "ok")
                {
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        error_num = 0;
                        error_msj = "ok";
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        return null;
                    }
                    else
                    {
                        error_num = 0;
                        error_msj = "ok";
                        cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                        return ds;
                    }
                }
                else
                {
                    error_msj = error_message;
                    error_num = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return null;
                }
            }
        }

        /*---------------Bitácora-----------*/
        public int ins_bitacora(string nom_pa, string accion, int usuario, ref string error_msj, ref int error_num, ref int result)
        {
            conn = cls_SQL.Make_Connection("ConexionP", ref error_message, ref error_number);
            if (conn == null)
            {
                return -1;
            }
            else
            {
                ParamStruct[] Params = new ParamStruct[3];
                OutPutValues[] OutValues = new OutPutValues[1];
                cls_SQL.Add_Data_Param_Struct(ref Params, 0, "@idusuario", SqlDbType.Int, usuario, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 1, "@accion", SqlDbType.VarChar, accion, ParameterDirection.Input);
                cls_SQL.Add_Data_Param_Struct(ref Params, 2, "@result", SqlDbType.Int, result, ParameterDirection.Output);
                cls_SQL.Connect(conn, ref error_message, ref error_number);
                // Ejecuta el PA para realizar la eliminación de datos
                cls_SQL.Execute_SQL_Command(conn, nom_pa, true, Params, ref error_message, ref error_number, ref OutValues);
                if (error_number == 0 && error_message == "ok")
                {
                    result = int.Parse(OutValues[0].Param_Value);
                    int e_number = error_number;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    if (error_number == 0)
                    {
                        error_num = 0;
                        error_msj = "ok";
                        return e_number;
                    }
                    else
                    {
                        error_num = 0;
                        error_msj = "ok";
                        return e_number;
                    }
                }
                else
                {
                    error_num = error_number;
                    error_msj = error_message;
                    cls_SQL.Disconnect(conn, ref error_message, ref error_number);
                    return error_number;
                }
            }
        }
    }
}
