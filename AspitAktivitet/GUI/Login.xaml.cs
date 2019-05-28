using AspitAktivitet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AspitAktivitet.GUI
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        MainWindow parent;
        public Login(MainWindow window)
        {
            InitializeComponent();
            parent = window;
        }

        private void CmdLogin_Click(object sender, RoutedEventArgs e)
        {
            User u = null;

            u = new User() { Name = txtUsername.Text, Password = txtPassword.Password, Admin = true};
            // Valider Bruger og kald tilbage til MainWindow "parrent" null hvis ikke gyldig
            parent.LoginSucces(u);
        }
    }
}
