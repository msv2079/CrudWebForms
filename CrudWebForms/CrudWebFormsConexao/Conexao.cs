using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWebFormsConexao
{
    public class Conexao
    {
        SqlConnection cnn = new SqlConnection(@"");

        private void AbrirConexao()
        {
            cnn.Open();
        }

        private void FecharConexao()
        {
            if (cnn != null && cnn.State != ConnectionState.Closed)
            {
                cnn.Close();
            }
        }

        protected int ExecuteNonQuery(string query)
        {
            var resultado = 0;

            AbrirConexao();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;

            cmd.Connection = cnn;

            resultado = cmd.ExecuteNonQuery();

            FecharConexao();

            return resultado;
        }

        protected DataTable ExecuteDataTable(string query)
        {
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.Connection = cnn;

            da.SelectCommand = cmd;

            AbrirConexao();

            da.Fill(dt);

            FecharConexao();

            return dt;
        }
    }
}
