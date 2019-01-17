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
using TerrificSmile.modules.Codes;
namespace TerrificSmile.modules
{
    /// <summary>
    /// Interaction logic for ucontrol_admin.xaml
    /// </summary>
    public partial class ucontrol_admin : UserControl
    {
        public ucontrol_admin()
        {
            InitializeComponent();
            _datasource();
        }
        enum status
        {
            delete,
            update,
            select,
            none
        }
        status _status = status.none;

        dentalInformation di = new dentalInformation();
        database_connection dc = new database_connection();
        private void bttn_login_Click(object sender, RoutedEventArgs e)
        {
            grid_adminform.Visibility = Visibility.Collapsed;
        }
        private void _datasource()
        {
            DataGrid_patientinfo.ItemsSource = di.information_source;
            DataGrid_reservation.ItemsSource = di.information_source;
            DataGrid_transaction.ItemsSource = di.information_source;
            di._select();
        }
        private void _clear()
        {
            textbox_patientId.Text = " ";
            textbox_name.Text = " ";
            textbox_age.Text = " ";
            textbox_phoneno.Text = " ";
            textbox_address.Text = " ";
            textbox_gender.Text = " ";
            combox_patientassitant.Text = " ";
        }
        private void Btnn_search_Click(object sender, RoutedEventArgs e)
        {
            di._clear();
            di._search(textbox_searchid.Text);
        }

        private void DataGrid_patientinfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid_patientinfo.SelectedItem == null) return;
            var selecteditem = DataGrid_patientinfo.SelectedItem as dentalInformation.informationSource;
            textbox_patientId.Text = selecteditem.patientId;
            textbox_name.Text = selecteditem.name;
            textbox_age.Text = selecteditem.age;
            textbox_phoneno.Text = selecteditem.phoneNumber;
            textbox_address.Text = selecteditem.address;
            textbox_gender.Text = selecteditem.gender;
            combox_patientassitant.Text = selecteditem.patientAssistant;

            _status = status.select;
        }

        private void Bttn_update_Click(object sender, RoutedEventArgs e)
        {
            dc = new database_connection();
            string query;
            try
            {
                if (_status == status.select)
                {
                    query = $@"update tbl_main 
set col_patientId = {textbox_patientId.Text}
col_name = '{textbox_name.Text}'
col_age = {textbox_age.Text}
col_address = '{textbox_address.Text}'
col_phoneNumber = {textbox_phoneno.Text}
col_gender = '{textbox_gender.Text}'
col_patientAssitant = '{combox_patientassitant.Text}'";
                    dc.Connection2(query);
                    _status = status.update;
                    MessageBox.Show("Updated");
                    _clear();
                }
                else
                {
                    MessageBox.Show("Please select the table row");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Bttn_delete_Click(object sender, RoutedEventArgs e)
        {
            dc = new database_connection();
            string query;
            try
            {
                if (_status == status.select)
                {
                    query = $@"delete from tbl_main";
                    dc.Connection2(query);
                    _status = status.delete;
                    MessageBox.Show("Deleted");
                    _clear();
                }
                else
                {
                    MessageBox.Show("Please select the table row");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
