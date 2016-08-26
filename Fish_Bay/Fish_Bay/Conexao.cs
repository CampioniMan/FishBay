using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Fish_Bay
{
    public static class Conexao
    {
        private static SqlConnection cnn;
        public static SqlConnection getConexao()
        {
            string connetionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            cnn = new SqlConnection(connetionString);
            openConexao();
            return cnn;
        }

        public static void openConexao()
        {
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
        }

        public static void closeConexao()
        {
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }
        }
    }
}
