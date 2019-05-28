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

namespace AspitAktivitet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Login l;
        User user;
        public MainWindow()
        {
            InitializeComponent();
            l = new Login(this);
            window.Children.Add(l);
        }

        public void LoginSucces(User u)
        {

            if (u != null)
            {
                window.Children.Remove(l);
                if (u.Admin == true)
                {
                    window.Children.Add(new AdminPanel());
                }
                else
                {
                    window.Children.Add(new UserPanel());
                }
            }
            
        }
    }
}
