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
    /// Interaction logic for AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : UserControl
    {
        MainWindow parrent;
        AdminPlans plan;
        AdminUsers user;
        AdminActivities activities;
        public AdminPanel(MainWindow mW)
        {
            parrent = mW;
            InitializeComponent();
            load();
        }
        private void load()
        {

            plan = new AdminPlans();
            user = new AdminUsers();
            activities = new AdminActivities();
            TabPlan.Content = plan;
            TabBruger.Content = user;
            TabAktivitet.Content = activities;
        }
        private void CmdLogout_Click(object sender, RoutedEventArgs e)
        {
            parrent.logout();

        }

        private void TabControler_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(TabControler.SelectedIndex == 0 && e.Source != plan)
            {
                plan.load();
                plan.loadPlaned();
            }
        }
    }
}
