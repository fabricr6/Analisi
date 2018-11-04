using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Conexion
{
    public struct ParamStruct
    {
        public string Param_Name;
        public SqlDbType DataType;
        public Object ParamValue;
        public ParameterDirection Direction;
    }
    public struct OutPutValues
    {
        public string Param_Name;
        public string Param_Value;
    }
    public static class cls_SQL
    {
        public static SqlConnection Make_Connection(string conn_name, ref string error_message, ref int error_number)
        {
            SqlConnection conn;
            try
            {
                string conn_string = "";
                conn_string = ConfigurationManager.ConnectionStrings[conn_name].ToString();
                conn = new SqlConnection(conn_string);
                error_message = String.Empty;
                error_number = 0;
                return conn;
            }
            catch (NullReferenceException ex)
            {
                error_message = "No se pudo establecer conexión: " + conn_name + ". Info.Adicional: " + ex.Message;
                error_number = -1;
                return null;
            }
            catch (ConfigurationException ex)
            {
                error_message = "Error, información adicional: " + ex.Message;
                error_number = -2;
                return null;
            }
        }

        public static void Connect(SqlConnection connection, ref string error_message, ref int error_number)
        {
            try
            {
                connection.Open();
                error_message = "ok";
                error_number = 0;
            }
            catch (SqlException ex)
            {
                error_message = "Connection Error, Additional Information: " + ex.Message;
                error_number = ex.Number;
            }
        }

        public static void Disconnect(SqlConnection connection, ref string error_message, ref int error_number)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    error_message = "closed";
                    error_number = 0;
                }
                else
                {
                    connection.Close();
                    error_message = "ok";
                }
            }
            catch (SqlException ex)
            {
                error_message = "Connection Error, Additional Information: " + ex.Message;
                error_number = ex.Number;
            }
        }

        public static DataSet Execute_DS(SqlConnection connection, string sql, bool is_st_proc, ref string error_message, ref int error_number)
        {
            SqlDataAdapter sql_ds;
            DataSet ds = new DataSet();
            try
            {
                sql_ds = new SqlDataAdapter(sql, connection);
                if (is_st_proc)
                {
                    sql_ds.SelectCommand.CommandType = CommandType.StoredProcedure;
                }
                sql_ds.Fill(ds);
                error_number = 0;
                error_message = "ok";
                return ds;
            }
            catch (SqlException ex)
            {
                error_number = ex.Number;
                error_message = ex.Message;
                return null;
            }
        }

        public static DataSet Execute_DS(SqlConnection connection, string sql, bool is_st_proc, ParamStruct[] Params, ref string error_message, ref int error_number)
        {
            SqlDataAdapter sql_ds;
            DataSet ds = new DataSet();
            try
            {
                sql_ds = new SqlDataAdapter(sql, connection);
                sql_ds.SelectCommand.CommandTimeout = 5000;
                if (is_st_proc)
                {
                    sql_ds.SelectCommand.CommandType = CommandType.StoredProcedure;

                }
                foreach (ParamStruct var in Params)
                {
                    Add_Param(ref sql_ds, var.Param_Name, var.ParamValue.ToString(), var.DataType, var.Direction);
                }
                sql_ds.Fill(ds);
                error_number = 0;
                error_message = "ok";
                return ds;
            }
            catch (SqlException ex)
            {
                error_number = ex.Number;
                error_message = ex.Message;
                return null;
            }
        }

        public static void Execute_DR(ref SqlDataReader sql_dr, SqlCommand sql_command, ref string error_message, ref int error_number)
        {
            try
            {
                sql_command.CommandTimeout = 0;
                sql_dr = sql_command.ExecuteReader(CommandBehavior.CloseConnection);
                error_number = 0;
                error_message = "ok";
            }
            catch (SqlException ex)
            {
                error_number = ex.Number;
                error_message = ex.Message;
            }
        }

        public static void Execute_SQL_Command(SqlConnection connection, string sql, bool is_st_proc, ref string error_message, ref int error_number)
        {
            SqlCommand sql_command;
            try
            {
                sql_command = new SqlCommand(sql, connection);
                sql_command.CommandTimeout = 5000;
                if (is_st_proc)
                {
                    sql_command.CommandType = CommandType.StoredProcedure;
                }
                int res = 0;
                res = sql_command.ExecuteNonQuery();
                error_message = "ok";
                error_number = res;
            }
            catch (SqlException ex)
            {
                error_message = "Error executing SQL, more information: " + ex.Message;
                error_number = ex.Number;
            }
        }

        public static void Execute_SQL_Command(SqlConnection connection, string sql, bool is_st_proc, ParamStruct[] Params, ref string error_message, ref int error_number)
        {
            SqlCommand sql_command;
            try
            {
                int res = 0;
                sql_command = new SqlCommand(sql, connection);
                sql_command.CommandTimeout = 0;
                if (is_st_proc)
                {
                    sql_command.CommandType = CommandType.StoredProcedure;
                }
                foreach (ParamStruct var in Params)
                {
                    Add_Param(ref sql_command, var.Param_Name, var.ParamValue.ToString(), var.DataType, var.Direction);
                }
                res = sql_command.ExecuteNonQuery();
                //error_message = sql_command.Parameters["@OUTRes"].Value.ToString();
                error_number = 0;
            }
            catch (SqlException ex)
            {
                error_message = "Error executing SQL, more information: " + ex.Message;
                error_number = ex.Number;
            }
        }

        public static void Execute_SQL_Command(SqlConnection connection, string sql, bool is_st_proc, ParamStruct[] Params, ref string error_message, ref int error_number, ref OutPutValues[] OutputVal)
        {
            SqlCommand sql_command;
            try
            {
                int res = 0;
                sql_command = new SqlCommand(sql, connection);
                sql_command.CommandTimeout = 0;
                if (is_st_proc)
                {
                    sql_command.CommandType = CommandType.StoredProcedure;
                }
                foreach (ParamStruct var in Params)
                {
                    Add_Param(ref sql_command, var.Param_Name, var.ParamValue.ToString(), var.DataType, var.Direction);
                }
                res = sql_command.ExecuteNonQuery();
                //error_message = sql_command.Parameters["@OUTRes"].Value.ToString();
                int x = 0;
                foreach (ParamStruct var in Params)
                {
                    if (var.Direction == ParameterDirection.Output)
                    {
                        Add_OutPutValues(ref OutputVal, x, sql_command.Parameters[var.Param_Name].ParameterName.ToString(),
                            sql_command.Parameters[var.Param_Name].Value.ToString());
                        ++x;
                    }

                }
                error_number = 0;

            }
            catch (SqlException ex)
            {
                error_message = "Error executing SQL, more information: " + ex.Message;
                error_number = ex.Number;
            }
        }

        public static void Add_Param(ref SqlCommand sql_command, string param_name, string param_value, SqlDbType data_type, ParameterDirection Direction)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = param_name;
            param.Value = param_value;
            param.Direction = Direction;
            param.SqlDbType = data_type;
            param.IsNullable = true;
            sql_command.Parameters.Add(param);
        }

        public static void Add_Param(ref SqlDataAdapter sql_da, string param_name, string param_value, SqlDbType data_type, ParameterDirection Direction)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = param_name;
            param.Value = param_value;
            param.Direction = Direction;
            param.SqlDbType = data_type;
            param.IsNullable = true;
            sql_da.SelectCommand.Parameters.Add(param);
        }

        public static void Add_OutPutValues(ref OutPutValues[] out_values, int pos, string param_name, string param_value)
        {
            out_values[pos].Param_Name = param_name;
            out_values[pos].Param_Value = param_value;
        }

        public static void Add_Data_Param_Struct(ref ParamStruct[] Params, int pos, string param_name, SqlDbType data_type, object param_value, ParameterDirection Direction)
        {
            Params[pos].Param_Name = param_name.ToString();
            Params[pos].DataType = data_type;
            Params[pos].ParamValue = param_value;
            Params[pos].Direction = Direction;
        }
    }
}
