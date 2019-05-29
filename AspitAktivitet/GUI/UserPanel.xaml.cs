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
    /// Interaction logic for UserPanel.xaml
    /// </summary>
    public partial class UserPanel : UserControl
    {
        User current;
        MainWindow parrent;
        public UserPanel(User u, MainWindow mW)
        {
            parrent = mW;
            current = u;
            InitializeComponent();
            lblBruger.Content = current.Name;
            lblWeek.Content = Util.getWeek(DateTime.Now);

            DB db = new DB();
            for (int i = 0; i < db.GetOffers().Count; i++)
            {

            }
            activityPanel.Children.Add(new RadioButton() {Content = "Lav dynamisk"});
        }

        private void CmdSignOut_Click(object sender, RoutedEventArgs e)
        {
            parrent.logout();
        }
    }
}
