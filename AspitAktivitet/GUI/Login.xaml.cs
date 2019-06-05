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
using AspitAktivitet.Healpers;

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
            validate();

        }

        private void validate()
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
                if(u != null && u.Password == "password" && u.Name == "Admin")
                {
                    DialogPassword dialog = new DialogPassword();
                   
                    if (dialog.ShowDialog() == true)
                    {                        
                        var user = db.Users.SingleOrDefault(dbu => dbu.Name == u.Name);
                        user.Password = dialog.Password; ;
                        db.SaveChanges();
                    }
                }
            }

            if (u != null)
            {
                txtUsername.Text = "";
                txtPassword.Password = "";
            }
            else
            {
                string text = "Forkerte Login!";
                MessageBox.Show(text, "Fejl", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            parent.LoginSucces(u);
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                validate();
            }
        }
    }
}
