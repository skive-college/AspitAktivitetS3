using AspitAktivitet.Healpers;
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
            // Valider Bruger og kald tilbage til MainWindow "parrent" null hvis ikke gyldig
            using (DB db = new DB())
            {
                User us = new User();
                if (txtUsername.Text != "" && txtPassword.Password != "")
                {
                    us.Name = txtUsername.Text;

                    us.Password = txtPassword.Password;
                }
                u = (db.Users.Where(o => o.Name == us.Name && o.Password == us.Password)).FirstOrDefault();

            }
            parent.LoginSucces(u);

        }
    }
}
