using AspitAktivitet.GUI;
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

namespace AspitAktivitet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Login l;
        public MainWindow()
        {
            InitializeComponent();
            l = new Login(this);
            window.Children.Add(l);
            deafaultUSer();
        }
        private void deafaultUSer()
        {
            try
            {
                using (DB db = new DB())
                {
                    User u = new User() { Name = "Admin", Password = "password", Admin = true };
                    db.Users.Add(u);
                    db.SaveChanges();
                }
            }
            catch { }
        }
        public void LoginSucces(User u)
        {

            if (u != null)
            {
                window.Children.Remove(l);
                if (u.Admin == true)
                {
                    window.Children.Add(new AdminPanel(this));
                }
                else
                {
                    window.Children.Add(new UserPanel(u, this));
                }
            }
            
        }

        public void logout()
        {
            window.Children.Clear();
            window.Children.Add(l);
        }
    }
}
