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
    /// Interaction logic for AdminUsers.xaml
    /// </summary>
    public partial class AdminUsers : UserControl
    {
        public AdminUsers()
        {
            InitializeComponent();
            using (DB db = new DB())
            {
                lwUsers.DataContext = db.Users.ToList();
            }
        }

        private void CmdCreate_Click(object sender, RoutedEventArgs e)
        {
            using (DB db = new DB())
            {
                bool admin = false;
                if(cbAdmin.IsChecked == true)
                {
                    admin = true;
                }
                User u = new User() { Name = txtName.Text, Password = txtPassword.Text, Admin = admin};

                db.Users.Add(u);
                db.SaveChanges();
            }
        }
    }
}
