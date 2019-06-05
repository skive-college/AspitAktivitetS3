using AspitAktivitet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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
    /// Interaction logic for UserPanel.xaml
    /// </summary>
    public partial class UserPanel : UserControl
    {
        User current;
        MainWindow parrent;
        Activity a;
        public UserPanel(User u, MainWindow mW)
        {
            parrent = mW;
            current = u;
            InitializeComponent();
            lblBruger.Content = current.Name;
            lblWeek.Content = Util.getWeek(DateTime.Now);
            Register reg = FindReg();
            DB db = new DB();
            foreach(Activity r in db.GetOffers(DateTime.Now))
            {
                RadioButton rd = new RadioButton();
                rd.Checked += new RoutedEventHandler(rb_Checked);
                Thickness margin = rd.Margin;
                margin.Left = 10;
                margin.Bottom = 10;
                rd.Margin = margin;
                Binding b = new Binding("Name");
                rd.DataContext = r;
                rd.SetBinding(RadioButton.ContentProperty, b);
                if (reg != null && r.ID == reg.ActivityID)
                {
                    rd.IsChecked = true;
                    cmdTilmeld.IsEnabled = false;
                }
                activityPanel.Children.Add(rd);
            }
            
        }

        private Register FindReg()
        {
            Register reg = null;

            using (DB db = new DB())
            {
                DateTime nu = DateTime.Now;
                int uge = Util.getWeek(nu);

                var quary = from r in db.Registrations
                            where nu.Year == r.Date.Year
                            && r.UserID == current.ID
                            select r;

                foreach(Register re in quary.ToList())
                {
                    if(uge == Util.getWeek(re.Date))
                    {
                        reg = re;
                    }
                }
                

            }
            return reg;
        }

        void rb_Checked(object sender, RoutedEventArgs e)
        {
            a = (sender as RadioButton).DataContext as Activity;
        }

        private void CmdSignOut_Click(object sender, RoutedEventArgs e)
        {
            parrent.logout();
        }

        private void CmdReg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (DB db = new DB())
                {
                    

                    Register r = new Register();

                    r.UserID = current.ID;
                    r.ActivityID = a.ID;
                    r.Date = DateTime.Now;
                    db.Registrations.Add(r);
                    db.SaveChanges();
                    MessageBox.Show($"du er nu tilmeldt {a.Name}", "Tilmeldt");
                    cmdTilmeld.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {

                //giv besked om Fejl
            }
        }

       
    }
}
