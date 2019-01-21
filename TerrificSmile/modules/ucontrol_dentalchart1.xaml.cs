using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Text.RegularExpressions;
using TerrificSmile.modules.Codes;
namespace TerrificSmile.modules
{
    /// <summary>
    /// Interaction logic for ucontrol_dentalchart1.xaml
    /// </summary>
    public partial class ucontrol_dentalchart1 : UserControl
    {
        public ucontrol_dentalchart1()
        {
            InitializeComponent();
            refresh();
            Listview_teethStatus.ItemsSource = th.teeth_source;
            generateId();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        dentalInformation di = new dentalInformation();
        database_connection dc = new database_connection();
        dentalrecord th = new dentalrecord();
        report r = new report();
        getId gid = new getId();
        private async void generateId()
        {
            gid = new getId();
            string year = DateTime.Now.ToString("yyyy") + "-";
            string patientId = await gid._patientId();
            string dateReservedId =  year + await gid._dateReservedId();
            string transactionId = await gid._transactionId();
            textbox_patientId.Text = patientId;
            textbox_reservationId.Text = dateReservedId;
            textbox_transactionId.Text = transactionId;
        }
        private void refresh()
        {
            dc = new database_connection();
            string query;
            query = $@"delete from tbl_teethexam";
            dc.Connection2(query);
        }
        #region 1st panel
        private void bttn_55_Click(object sender, RoutedEventArgs e)
        {
            icon55.Kind = th.teethSourceId("55");
        }
        private void bttn_54_Click(object sender, RoutedEventArgs e)
        {
            icon54.Kind = th.teethSourceId("54");
        }
        private void bttn_53_Click(object sender, RoutedEventArgs e)
        {
            icon53.Kind = th.teethSourceId("53");
        }
        private void bttn_52_Click(object sender, RoutedEventArgs e)
        {
            icon52.Kind = th.teethSourceId("52");
        }
        private void bttn_51_Click(object sender, RoutedEventArgs e)
        {
            icon51.Kind = th.teethSourceId("51");
        }
        #endregion
        #region 2nd panel
        private void Bttn_18_Click(object sender, RoutedEventArgs e)
        {
            icon18.Kind = th.teethSourceId("18");
        }
        private void Bttn_17_Click(object sender, RoutedEventArgs e)
        {
            icon17.Kind = th.teethSourceId("17");
        }
        private void Bttn_16_Click(object sender, RoutedEventArgs e)
        {
            icon16.Kind = th.teethSourceId("16");
        }
        private void Bttn_15_Click(object sender, RoutedEventArgs e)
        {
            icon15.Kind = th.teethSourceId("15");
        }
        private void Bttn_14_Click(object sender, RoutedEventArgs e)
        {
            icon14.Kind = th.teethSourceId("14");
        }
        private void Bttn_13_Click(object sender, RoutedEventArgs e)
        {
            icon13.Kind = th.teethSourceId("13");
        }
        private void Bttn_12_Click(object sender, RoutedEventArgs e)
        {
            icon12.Kind = th.teethSourceId("12");
        }
        private void Bttn_11_Click(object sender, RoutedEventArgs e)
        {
            icon11.Kind = th.teethSourceId("11");
        }
        #endregion
        #region 3rd panel
        private void Bttn_41_Click(object sender, RoutedEventArgs e)
        {
            icon41.Kind = th.teethSourceId("41");
        }

        private void Bttn_42_Click(object sender, RoutedEventArgs e)
        {
            icon42.Kind = th.teethSourceId("42");
        }

        private void Bttn_43_Click(object sender, RoutedEventArgs e)
        {
            icon43.Kind = th.teethSourceId("43");
        }

        private void Bttn_44_Click(object sender, RoutedEventArgs e)
        {
            icon44.Kind = th.teethSourceId("44");
        }

        private void Bttn_45_Click(object sender, RoutedEventArgs e)
        {
            icon45.Kind = th.teethSourceId("45");
        }

        private void Bttn_46_Click(object sender, RoutedEventArgs e)
        {
            icon46.Kind = th.teethSourceId("46");
        }

        private void Bttn_47_Click(object sender, RoutedEventArgs e)
        {
            icon47.Kind = th.teethSourceId("47");
        }

        private void Bttn_48_Click(object sender, RoutedEventArgs e)
        {
            icon48.Kind = th.teethSourceId("48");
        }
        #endregion
        #region 4th panel
        private void Bttn_81_Click(object sender, RoutedEventArgs e)
        {
            icon81.Kind = th.teethSourceId("81");
        }

        private void Bttn_82_Click(object sender, RoutedEventArgs e)
        {
            icon82.Kind = th.teethSourceId("82");
        }

        private void Bttn_83_Click(object sender, RoutedEventArgs e)
        {
            icon83.Kind = th.teethSourceId("83");
        }

        private void Bttn_84_Click(object sender, RoutedEventArgs e)
        {
            icon84.Kind = th.teethSourceId("84");
        }

        private void Bttn_85_Click(object sender, RoutedEventArgs e)
        {
            icon85.Kind = th.teethSourceId("85");
        }
        #endregion
        #region 5th panel
        private void Bttn_61_Click(object sender, RoutedEventArgs e)
        {
            icon61.Kind = th.teethSourceId("61");
        }

        private void Bttn_62_Click(object sender, RoutedEventArgs e)
        {
            icon62.Kind = th.teethSourceId("62");
        }

        private void Bttn_63_Click(object sender, RoutedEventArgs e)
        {
            icon63.Kind = th.teethSourceId("63");
        }

        private void Bttn_64_Click(object sender, RoutedEventArgs e)
        {
            icon64.Kind = th.teethSourceId("64");
        }

        private void Bttn_65_Click(object sender, RoutedEventArgs e)
        {
            icon65.Kind = th.teethSourceId("65");
        }
        #endregion
        #region 6th panel
        private void Bttn_28_Click(object sender, RoutedEventArgs e)
        {
            icon28.Kind = th.teethSourceId("28");
        }

        private void Bttn_27_Click(object sender, RoutedEventArgs e)
        {
            icon27.Kind = th.teethSourceId("27");
        }

        private void Bttn_26_Click(object sender, RoutedEventArgs e)
        {
            icon26.Kind = th.teethSourceId("26");
        }

        private void Bttn_25_Click(object sender, RoutedEventArgs e)
        {
            icon25.Kind = th.teethSourceId("25");
        }

        private void Bttn_24_Click(object sender, RoutedEventArgs e)
        {
            icon24.Kind = th.teethSourceId("24");
        }

        private void Bttn_23_Click(object sender, RoutedEventArgs e)
        {
            icon23.Kind = th.teethSourceId("23");
        }

        private void Bttn_22_Click(object sender, RoutedEventArgs e)
        {
            icon22.Kind = th.teethSourceId("22");
        }

        private void Bttn_21_Click(object sender, RoutedEventArgs e)
        {
            icon21.Kind = th.teethSourceId("21");
        }
        #endregion
        #region 7th panel
        private void Bttn_31_Click(object sender, RoutedEventArgs e)
        {
            icon31.Kind = th.teethSourceId("31");
        }

        private void Bttn_32_Click(object sender, RoutedEventArgs e)
        {
            icon32.Kind = th.teethSourceId("32");
        }

        private void Bttn_33_Click(object sender, RoutedEventArgs e)
        {
            icon33.Kind = th.teethSourceId("33");
        }

        private void Bttn_34_Click(object sender, RoutedEventArgs e)
        {
            icon34.Kind = th.teethSourceId("34");
        }

        private void Bttn_35_Click(object sender, RoutedEventArgs e)
        {
            icon35.Kind = th.teethSourceId("35");
        }

        private void Bttn_36_Click(object sender, RoutedEventArgs e)
        {
            icon36.Kind = th.teethSourceId("36");
        }

        private void Bttn_37_Click(object sender, RoutedEventArgs e)
        {
            icon37.Kind = th.teethSourceId("37");
        }

        private void Bttn_38_Click(object sender, RoutedEventArgs e)
        {
            icon38.Kind = th.teethSourceId("38");
        }
        #endregion
        #region 8th panel
        private void Bttn_75_Click(object sender, RoutedEventArgs e)
        {
            icon75.Kind = th.teethSourceId("75");
        }

        private void Bttn_74_Click(object sender, RoutedEventArgs e)
        {
            icon74.Kind = th.teethSourceId("74");
        }

        private void Bttn_73_Click(object sender, RoutedEventArgs e)
        {
            icon73.Kind = th.teethSourceId("73");
        }

        private void Bttn_72_Click(object sender, RoutedEventArgs e)
        {
            icon72.Kind = th.teethSourceId("72");
        }

        private void Bttn_71_Click(object sender, RoutedEventArgs e)
        {
            icon71.Kind = th.teethSourceId("71");
        }
        #endregion
        private void bttn_done_Click(object sender, RoutedEventArgs e)
        {
            r.receipt();
            dentalrecord.teethsource currentteeth;
            int ctr, total;
            total = th.teeth_source.Count;
            string query;
            for (ctr = 0; ctr < total; ctr++)
            {
                currentteeth = th.teeth_source[ctr];
                if (currentteeth.teeth_status != null)
                {
                    query = $@"update tbl_teethexam set col_teethstatus = '{currentteeth.teeth_status}' where col_teethid = '{currentteeth.teeth_id}'";
                    dc.Connection2(query);
                }
            }
            grid_receipt.Visibility = Visibility.Visible;
            richbox_receiptD.Document = report.mcFlowDoc;
        }
        #region Receip
        private void bttn_cancel_Click(object sender, RoutedEventArgs e)
        {
            grid_receipt.Visibility = Visibility.Collapsed;
        }
        int change;
        private void bttn_print_Click(object sender, RoutedEventArgs e)
        {
            di = new dentalInformation();
            di._save(textbox_transactionId.Text, textbox_patientId.Text, textbox_name.Text, 
                    textbox_age.Text, textbox_address.Text, textbox_phoneno.Text, combox_gender.Text, 
                    combox_patientassitant.Text,textbox_reservationId.Text,datepicker_dateReserved.Text
                    ,textbox_payment.Text,textbox_amount.Text,textbox_change.Text);
            gid = new getId();
            gid.updatePatientId();
        }
        #endregion

        private void textbox_amount_LostFocus(object sender, RoutedEventArgs e)
        {
            change = int.Parse(textbox_payment.Text) - int.Parse(textbox_amount.Text);
            textbox_change.Text = change.ToString();
        }
    }
}
