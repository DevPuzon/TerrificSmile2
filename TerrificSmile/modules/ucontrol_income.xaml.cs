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
            DataGrid_expenses.ItemsSource = inc.expenses_source;
            DataGrid_dailyIncome.ItemsSource = inc.inventory_source;
            richbox_computation.Document = inc._computation(combox_searchmonth.Text, combox_searchyear.Text);
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
        private void _clear()
        {
            textbox_gross.Text = "";
            textbox_commission.Text = "";
            textbox_perday.Text = "";
            textbox_otherDescription.Text = "";
            textbox_otherFee.Text = "";
            textbox_description.Text = "";
            textbox_fee.Text = "";
        }
        private void _refreshData()
        {
            inc._clear();
            inc._search(combox_searchmonth.Text, combox_searchyear.Text);
            richbox_computation.Document = inc._computation(combox_searchmonth.Text, combox_searchyear.Text);
        }
        public string id_dailyInventory;
        public string id_expenses;
        private void Bttn_add_Click(object sender, RoutedEventArgs e)
        {
            inc._clear();
            _start();
            _clear();
            btn_status = bttnStatus.add;
        }
        private void Bttn_save_Click(object sender, RoutedEventArgs e)
        {
            if (btn_status == bttnStatus.selectIncome)
            {
                //updateTbl_Monlthlyincome
                inc._updateDailyInventory(textbox_gross.Text,
                                          textbox_commission.Text,
                                          textbox_perday.Text,
                                          textbox_otherDescription.Text,
                                          textbox_otherFee.Text,
                                          combox_day.Text,
                                          combox_month.Text,
                                          combox_year.Text,
                                          id_dailyInventory);
                MessageBox.Show("Updated data in table daily inventory");
                _clear();
            }
            else if (btn_status == bttnStatus.selectExpenses)
            {
                //updateTbl_Expenses
                inc._updateExpenses(textbox_description.Text,
                                    textbox_fee.Text,
                                    combox_month.Text,
                                    combox_year.Text,
                                    id_expenses);
                MessageBox.Show("Updated data in table expenses");
            }
            else if (textbox_gross.Text != "" &&
                    textbox_commission.Text !="" &&
                    textbox_perday.Text != "")
            {
                //insert tbl_daily
                inc._insertDailyInventory(textbox_gross.Text,
                                          textbox_commission.Text,
                                          textbox_perday.Text,
                                          textbox_otherDescription.Text,
                                          textbox_otherFee.Text,
                                          combox_day.Text,
                                          combox_month.Text,
                                          combox_year.Text);
                MessageBox.Show("Saved data in table daily inventory");
            }
            else if (textbox_description.Text != ""&&
                    textbox_fee.Text !="")
            {
                //insert tbl_expenses
                inc._insertExpenses(textbox_description.Text,
                                    textbox_fee.Text,
                                    combox_month.Text,
                                    combox_year.Text);
                MessageBox.Show("Saved data in table expenses");
            }
            else
            {
                MessageBox.Show("Please click the table to update or fill all the data information");
            }
            _clear();
            _refreshData();
            btn_status = bttnStatus.save;
        }

        private void Bttn_delete_Click(object sender, RoutedEventArgs e)
        {
            if (btn_status == bttnStatus.selectIncome)
            {
                //delete tbl_dailyinventory
                inc._deleteDailyInventory(id_dailyInventory);
                MessageBox.Show("Deleted the row of table daily inventory you selected");
            }
            else if (btn_status == bttnStatus.selectExpenses)
            {
                //delete tbl_expenses
                inc._deleteExpenses(id_expenses);
                MessageBox.Show("Deleted the row of table xpenses you selected");
            }
            else
            {
                MessageBox.Show("Please click the table row you want to delete");
            }
            _clear();
            _refreshData();
            btn_status = bttnStatus.delete;
        }

        private void Combox_month_DropDownClosed(object sender, EventArgs e)
        {
            _refreshData();
            btn_status = bttnStatus.search;
        }

        private void Combox_year_DropDownClosed(object sender, EventArgs e)
        {
            _refreshData();
            btn_status = bttnStatus.search;
        }

        private void DataGrid_dailyIncome_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid_dailyIncome.SelectedItem == null) return;
            var selecteditem = DataGrid_dailyIncome.SelectedItem as Income.inventorysource;
            id_dailyInventory = selecteditem.id;
            textbox_gross.Text = selecteditem.gross;
            textbox_commission.Text = selecteditem.commission;
            textbox_perday.Text = selecteditem.perday;
            textbox_otherDescription.Text = selecteditem.otherDescription;
            textbox_otherFee.Text = selecteditem.otherFee;
            combox_day.Text = selecteditem.day;
            combox_month.Text = selecteditem.month;
            combox_year.Text = selecteditem.year;
            btn_status = bttnStatus.selectIncome;
        }

        private void DataGrid_expenses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid_expenses.SelectedItem == null) return;
            var selecteditem = DataGrid_expenses.SelectedItem as Income.expensessource;
            id_expenses = selecteditem.id;
            textbox_description.Text = selecteditem.description;
            textbox_fee.Text = selecteditem.fee;
            combox_month.Text = selecteditem.month;
            combox_year.Text = selecteditem.year;
            btn_status = bttnStatus.selectExpenses;
        }
    }
}
