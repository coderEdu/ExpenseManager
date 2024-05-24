using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ExpenseManager.Model
{
    class Queries
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        private static SqlConnection? sqlConnection = new(connectionString);

        public static int ValidateLogin(string user_name, string user_pass)
        {
            int r = 0;
            try
            {
                string queryString = "SELECT COUNT(*) AS match FROM usuarios WHERE usuarios.usuario = @user AND usuarios.clave = @pass";
                var command = new SqlCommand(queryString, sqlConnection);
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@user", user_name ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@pass", user_pass ?? (object)DBNull.Value);
                sqlConnection?.Open();
                r = (int)command.ExecuteScalar();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            finally { sqlConnection?.Close(); }
            return r;
        }
    }
}
