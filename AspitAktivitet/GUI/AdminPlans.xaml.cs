using AspitAktivitet.Healpers;
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
            for (int i = 0; i < 53; i++)
            {
                Week.Items.Add("Uge " + (i + 1));
            }
            Week.SelectedIndex = Util.getWeek(DateTime.Now) -1;
        }

        private void Week_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
