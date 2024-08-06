using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace MyApp
{
    class ClaseConexion
    {
        public string cadena = "Data Source=server;Initial Catalog=BD;Persist Security Info=True;User ID=sa;Password=12345;";

        public DataTable consultarLista()
        {
            SqlConnection con = new SqlConnection(cadena);
            DataTable dt = new DataTable();
            try
            {
                string sql = "Select * From Lista";
                SqlCommand comando = new SqlCommand(sql, con);
                comando.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(comando);
                da.Fill(dt);
                con.Close();
                NumeroLineasSelect(dt);
                return dt;
            }
            catch (Exception ex)
            {
                con.Close();
                throw ex;
            }

        }

        public string NumeroLineasSelect(DataTable dt)
        {
            try
            {
                string numero = dt.Rows.count.ToString();
                return "Se consultaron " + numero + " lineas";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int numeroLineasAfectadas(string query)
        {
            int result = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(cadena))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand(query, con);
                    result = command.ExecuteNonQuery();
                    con.Close();
                }
                return result;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

    }
}