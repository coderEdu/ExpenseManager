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
using ExpenseManager.Model;

namespace ExpenseManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // MessageBox.Show(connectionString);
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            Tools.CenterWindowOnScreen(this);
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            if (txt_user.Text.Length > 0 && txt_pass.Password.Length > 0)
            {
                // validating login
                int queryResult = Queries.ValidateLogin(txt_user.Text, txt_pass.Password.ToString());
                MessageBox.Show((queryResult > 0) ? "It matches" : "It doesn't matches");
            }

        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}