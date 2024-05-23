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
            //  MessageBox.Show(connectionString);
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            Tools.CenterWindowOnScreen(this);
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "select * from usuarios where usuarios.id = @UserId";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                sqlConnection?.Open();

                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.AddWithValue("@UserId", "1");

                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                if (sqlConnection?.State == ConnectionState.Open) { MessageBox.Show("Opened"); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally { sqlConnection?.Close(); }
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}