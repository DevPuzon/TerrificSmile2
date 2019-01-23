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
    /// Interaction logic for ucontrol_admin.xaml
    /// </summary>
    public partial class ucontrol_admin : UserControl
    {
        public ucontrol_admin()
        {
            InitializeComponent();
            _datasource();
        }
        EditAdminAssistant ea = new EditAdminAssistant();
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
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
            Visibility v = Visibility.Visible;
            if(v == AdminAccess._accessAdmin(textbox_adminusername.Text, passbox_adminpass.Password))
            {
                grid_frontform.Visibility = Visibility.Collapsed;
            }
        }

        private void Bttn_settings_Click(object sender, RoutedEventArgs e)
        {
            grid_edit.Visibility = AdminAccess._accessAdmin(textbox_adminusername.Text, passbox_adminpass.Password);
        }

        private void _datasource()
        {
            DataGrid_patientinfo.ItemsSource = di.information_source;
            DataGrid_reservation.ItemsSource = di.information_source;
            DataGrid_transaction.ItemsSource = di.information_source;
            di._select();
            
            DataGrid_admin.ItemsSource = ea.adminSource;
            DataGrid_patientAssistant.ItemsSource = ea.patientAssistantSource;
            ea._select();
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
            textbox_reservationid.Text = selecteditem.reservationId;
            datepick_reserveDate.Text = selecteditem.dateReserved;

            _status = status.select;
        }

        private void DataGrid_reservation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid_reservation.SelectedItem == null) return;
            var selecteditem = DataGrid_reservation.SelectedItem as dentalInformation.informationSource;
            textbox_patientId.Text = selecteditem.patientId;
            textbox_name.Text = selecteditem.name;
            textbox_age.Text = selecteditem.age;
            textbox_phoneno.Text = selecteditem.phoneNumber;
            textbox_address.Text = selecteditem.address;
            textbox_gender.Text = selecteditem.gender;
            combox_patientassitant.Text = selecteditem.patientAssistant;
            textbox_reservationid.Text = selecteditem.reservationId;
            datepick_reserveDate.Text = selecteditem.dateReserved;

            _status = status.select;
        }

        private void DataGrid_transaction_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid_transaction.SelectedItem == null) return;
            var selecteditem = DataGrid_transaction.SelectedItem as dentalInformation.informationSource;
            
            if (selecteditem.patientId != "")
            {
                textbox_patientId.Text = selecteditem.patientId;
                textbox_name.Text = selecteditem.name;
                textbox_age.Text = selecteditem.age;
                textbox_phoneno.Text = selecteditem.phoneNumber;
                textbox_address.Text = selecteditem.address;
                textbox_gender.Text = selecteditem.gender;
                combox_patientassitant.Text = selecteditem.patientAssistant;
                textbox_reservationid.Text = selecteditem.reservationId;
                datepick_reserveDate.Text = selecteditem.dateReserved;
            }
            else
            {
                MessageBox.Show("No patient register");
            }

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
set col_patientId = '{textbox_patientId.Text}'
,col_name = '{textbox_name.Text}'
,col_age = {textbox_age.Text}
,col_address = '{textbox_address.Text}'
,col_phoneNumber = {textbox_phoneno.Text}
,col_gender = '{textbox_gender.Text}'
,col_patientAssitant = '{combox_patientassitant.Text}'
,col_dateReserved = '{datepick_reserveDate.Text}'
where col_patientId = '{textbox_patientId.Text}'";
                    dc.Connection2(query);
                    _clear();
                    di._clear();
                    di._select();
                    _status = status.update;
                    MessageBox.Show("Updated");
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
                    query = $@"delete from tbl_main where col_patientId = '{textbox_patientId.Text}'";
                    dc.Connection2(query);
                    _clear();
                    di._clear();
                    di._select();
                    _status = status.delete;
                    MessageBox.Show("Deleted");
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
        #region Editadmin
        public string idAdmin;
        enum adminStatus
        {
            save,
            delete,
            select,
            none
        }
        bool adminAdd = false;
        adminStatus admin_status = adminStatus.none;
        private void _clearAdmin()
        {
            textbox_editadminusername.Text = "";
            textbox_editpasswordadmin.Text = "";
        }

        private void Bttn_newAdmin_Click(object sender, RoutedEventArgs e)
        {
            _clearAdmin();
            adminAdd = true;
            idAdmin = "0123456789";
            MessageBox.Show("Add new admin");
        }

        private void Bttn_saveAdmin_Click(object sender, RoutedEventArgs e)
        {
            if (admin_status == adminStatus.select || adminAdd)
            {
                ea._saveAdmin(idAdmin, textbox_editadminusername.Text, textbox_editpasswordadmin.Text);
                adminAdd = false;
                _clearAdmin();
                ea._clearSelect();
                admin_status = adminStatus.save;
            }
            else
            {
                MessageBox.Show("Please select the admin row or click new admin");
            }
        }

        private void Bttn_deleteAdmin_Click(object sender, RoutedEventArgs e)
        {
            if (admin_status == adminStatus.select)
            {
                ea._deleteAdmin(idAdmin);
                _clearAdmin();
                ea._clearSelect();
                admin_status = adminStatus.delete;
            }
            else
            {
                MessageBox.Show("Please select the admin row");
            }
        }

        private void DataGrid_admin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid_admin.SelectedItem == null) return;
            var selectedItem = DataGrid_admin.SelectedItem as EditAdminAssistant.admin_source;
            idAdmin = selectedItem.id;
            textbox_editadminusername.Text = selectedItem.adminUserName;
            textbox_editpasswordadmin.Text = selectedItem.password;

            admin_status = adminStatus.select;
        }
        #endregion
        #region EditAsisstant
        public string idAssistant;
        public enum assistantStatus
        {
            save,
            delete,
            select,
            none
        }
        assistantStatus assistant_status = assistantStatus.none;
        bool assistantAdd = false;
        private void _clearAssistant()
        {
            textbox_patientAssistant.Text = "";
        }

        private void Bttn_newAssistant_Click(object sender, RoutedEventArgs e)
        {
            _clearAssistant();
            assistantAdd = true;
            idAssistant  = "0123456789";
            MessageBox.Show("Add new admin");
        }

        private void DataGrid_patientAssistant_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid_patientAssistant.SelectedItem == null) return;
            var selectedItem = DataGrid_patientAssistant.SelectedItem as EditAdminAssistant.patientassistant_source;
            idAssistant = selectedItem.id;
            textbox_patientAssistant.Text = selectedItem.patientAssistant;

            assistant_status = assistantStatus.select;
        }

        private void Bttn_deletePatientAsistatn_Click(object sender, RoutedEventArgs e)
        {
            if (assistant_status == assistantStatus.select)
            {
                ea._deletePatientAssistant(idAssistant);
                _clearAssistant();
                ea._clearSelect();
                assistant_status = assistantStatus.delete;
            }
            else
            {
                MessageBox.Show("Please select the assistant row");
            }
        }

        private void Bttn_savePatientAssistant_Click(object sender, RoutedEventArgs e)
        {
            if (assistant_status == assistantStatus.select || assistantAdd)
            {
                ea._saveAssistant(idAssistant, textbox_patientAssistant.Text);
                assistantAdd = false;
                _clearAssistant();
                ea._clearSelect();
                assistant_status = assistantStatus.save;
            }
            else
            {
                MessageBox.Show("Please select the admin row  or click new assistant");
            }
        }
        #endregion

        private void Btnn_back_Click(object sender, RoutedEventArgs e)
        {
            grid_edit.Visibility = Visibility.Collapsed;
        }
    }
}
