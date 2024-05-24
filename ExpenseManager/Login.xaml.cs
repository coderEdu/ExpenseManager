using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExpenseManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection? sqlConnection;

        public MainWindow()
        {
            InitializeComponent();
            var connectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);
            // MessageBox.Show(connectionString);
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            Tools.CenterWindowOnScreen(this);
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    string queryString = "select usuarios.usuario from usuarios where usuarios.id = 2";
            //    var command = new SqlCommand(queryString, sqlConnection);
            //    sqlConnection?.Open();
            //    using (var reader = command.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            MessageBox.Show(String.Format("{0}", reader[0]));
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
            //finally { sqlConnection?.Close(); }

            if (txt_user.Text.Length > 0 && txt_pass.Password.Length > 0) 
            {
                try
                {
                    string queryString = "SELECT COUNT(*) AS match FROM usuarios WHERE usuarios.usuario = @user AND usuarios.clave = @pass";
                    var command = new SqlCommand(queryString, sqlConnection);
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@user", txt_user.Text ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@pass", txt_pass.Password.ToString() ?? (object)DBNull.Value);
                    sqlConnection?.Open();
                    MessageBox.Show(((int)command.ExecuteScalar() > 0) ? "It matches" : "It doesn't matches");           
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                finally { sqlConnection?.Close(); }
            }


        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}