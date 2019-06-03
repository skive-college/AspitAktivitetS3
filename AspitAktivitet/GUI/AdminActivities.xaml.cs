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
    /// Interaction logic for AdminActivities.xaml
    /// </summary>
    public partial class AdminActivities : UserControl
    {
        public AdminActivities()
        {
            InitializeComponent();
            load();
        }

        private void load()
        {
            using (DB db = new DB())
            {
                lwActivities.DataContext = db.Activities.ToList();
            }
        }

        private void CmdCreate_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text != "")
            {
                using (DB db = new DB())
                {
                    Activity a = new Activity() { Name = txtName.Text };

                    db.Activities.Add(a);
                    db.SaveChanges();
                    txtName.Text = "";
                }
                load();
            }
        }

        private void CmdDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lwActivities.SelectedIndex != -1)
            {
                Activity a = lwActivities.SelectedItem as Activity;

                using (DB db = new DB())
                {
                    db.Activities.Attach(a);
                    db.Activities.Remove(a);
                    db.SaveChanges();
                }
                load();
            }
        }
    }
}
