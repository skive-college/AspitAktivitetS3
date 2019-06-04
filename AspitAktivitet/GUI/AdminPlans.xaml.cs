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
    /// Interaction logic for AdminPlans.xaml
    /// </summary>
    public partial class AdminPlans : UserControl
    {
        public AdminPlans()
        {
            InitializeComponent();
            cmbUnassigned.Content = "<";
            DateTime d = DateTime.Now;

            d = new DateTime(d.Year, 1, 1);
            List<DateWrapper> uger = new List<DateWrapper>();
            for (int i = 0; i < 53; i++)
            {
                uger.Add(new DateWrapper(d));
                d = d.AddDays(7);
            }
            Week.DataContext = uger;
            Week.SelectedIndex = Util.getWeek(DateTime.Now) - 1;
            load();
        }
        
        public void load()
        {
            using (DB db = new DB())
            {
                lwUnassigned.DataContext = db.Activities.ToList();
            }
        }

        public void loadPlaned()
        {
            using (DB db = new DB())
            {
                if (Week.SelectedIndex != -1)
                { 
                    DateTime d = (Week.SelectedItem as DateWrapper).Date;
                    List<Activity> l = db.GetOffers(d);
                    lwAssigned.DataContext = l;
                }
            }
        }
        private void CmbAssigned_Click(object sender, RoutedEventArgs e)
        {
           
            if (lwUnassigned.SelectedIndex != -1)
            {
                using (DB db = new DB())
                {
                    try
                    {
                        DateTime d = (Week.SelectedItem as DateWrapper).Date;
                        Activity a = lwUnassigned.SelectedItem as Activity;

                        Planned p = new Planned() { ActivtyID = a.ID, Date = d };
                        db.PlannedActivities.Add(p);
                        db.SaveChanges();

                        loadPlaned();

                    }
                    catch(Exception ex)
                    {

                    }
                    

                }
                    
            }
        }

        private void Week_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            loadPlaned();
        }

        private void CmbUnassigned_Click(object sender, RoutedEventArgs e)
        {
            if (lwAssigned.SelectedIndex != -1)
            {
                using (DB db = new DB())
                {
                    try
                    {
                        DateTime d = (Week.SelectedItem as DateWrapper).Date;
                        Activity a = lwAssigned.SelectedItem as Activity;

                        Planned p = new Planned() { ActivtyID = a.ID, Date = d };

                        db.PlannedActivities.Attach(p);
                        db.PlannedActivities.Remove(p);
                        db.SaveChanges();

                        loadPlaned();

                    }
                    catch (Exception ex)
                    {

                    }


                }
            }
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
