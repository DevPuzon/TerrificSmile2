using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace TerrificSmile.modules
{
    /// <summary>
    /// Interaction logic for ucontrol_income.xaml
    /// </summary>
    public partial class ucontrol_income : UserControl
    {
        public ucontrol_income()
        {
            InitializeComponent();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Bttn_add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Bttn_save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Bttn_delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Combox_month_DropDownClosed(object sender, EventArgs e)
        {

        }

        private void Combox_year_DropDownClosed(object sender, EventArgs e)
        {

        }

        private void DataGrid_dailyIncome_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_expenses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
