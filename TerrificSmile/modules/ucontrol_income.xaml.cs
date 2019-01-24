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
using TerrificSmile.modules.Codes;

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
            _start();
        }
        Income inc = new Income();
        private void _start()
        {
            combox_day.ItemsSource = inc._day();
            combox_month.ItemsSource = inc._month();
            combox_year.ItemsSource = inc._year();
            combox_searchmonth.ItemsSource = inc._month();
            combox_searchyear.ItemsSource = inc._year();
            combox_day.Text = DateTime.Now.Day.ToString("d");
            combox_month.Text = DateTime.Now.Month.ToString("0");
            combox_year.Text = DateTime.Now.ToString("yyyy");
            combox_searchmonth.Text = DateTime.Now.Month.ToString("0");
            combox_searchyear.Text = DateTime.Now.ToString("yyyy");
            inc._search(combox_searchmonth.Text, combox_searchyear.Text);
        }
        enum bttnStatus
        {
            add,
            save,
            delete,
            selectIncome,
            selectExpenses,
            search,
            none
        }
        bttnStatus btn_status = bttnStatus.none;
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Bttn_add_Click(object sender, RoutedEventArgs e)
        {
            _clear();
            btn_status = bttnStatus.add;
        }
        private void _clear()
        {
            textbox_gross.Text = "";
            textbox_commission.Text = "";
            textbox_perday.Text = "";
            textbox_other.Text = "";
            textbox_description.Text = "";
            textbox_fee.Text = "";
        }
        private void Bttn_save_Click(object sender, RoutedEventArgs e)
        {
            if (btn_status == bttnStatus.selectIncome)
            {
                //updateTbl_Monlthlyincome
            }
            else if (btn_status == bttnStatus.selectExpenses)
            {
                //updateTbl_Expenses

            }
            else if (//)
            {

            }
            else if (//)
            {

            }
            else
            {
                MessageBox.Show("");
            }

            btn_status = bttnStatus.save;
        }

        private void Bttn_delete_Click(object sender, RoutedEventArgs e)
        {

            btn_status = bttnStatus.delete;
        }

        private void Combox_month_DropDownClosed(object sender, EventArgs e)
        {
            inc._search(combox_searchmonth.Text, combox_searchyear.Text);
            btn_status = bttnStatus.search;
        }

        private void Combox_year_DropDownClosed(object sender, EventArgs e)
        {
            inc._search(combox_searchmonth.Text, combox_searchyear.Text);
            btn_status = bttnStatus.search;
        }

        private void DataGrid_dailyIncome_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            btn_status = bttnStatus.selectIncome;
        }

        private void DataGrid_expenses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            btn_status = bttnStatus.selectExpenses;
        }
    }
}
