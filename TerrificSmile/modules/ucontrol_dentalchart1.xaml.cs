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
        }
        database_connection dc = new database_connection();
        private void refresh()
        {
            dc = new database_connection();
            string query;
            query = $@"delete from tbl_teethexam";
            dc.Connection2(query);
        }
        dentalrecord th = new dentalrecord();
        #region 1st Stackpanel 
        bool bool55;
        bool bool54;
        bool bool53;
        bool bool52;
        bool bool51;
        private void bttn_55_Click(object sender, RoutedEventArgs e)
        {
            th.teethSourceId("55");
            if (bool55)
            {
                icon55.Kind = MahApps.Metro.IconPacks.PackIconEntypoKind.Circle;
                icon55.Foreground = Brushes.Black;
                bool55 = false;
            }else
            {
                icon55.Kind = MahApps.Metro.IconPacks.PackIconEntypoKind.CircleWithCross;
                icon55.Foreground = Brushes.Red;
                bool55 = true;
            }
        }
        private void bttn_54_Click(object sender, RoutedEventArgs e)
        {
            th.teethSourceId("54");
            if (bool54)
            {
                icon54.Kind = MahApps.Metro.IconPacks.PackIconEntypoKind.Circle;
                icon54.Foreground = Brushes.Black;
                bool54 = false;
            }
            else
            {
                icon54.Kind = MahApps.Metro.IconPacks.PackIconEntypoKind.CircleWithCross;
                icon54.Foreground = Brushes.Red;
                bool54 = true;
            }

        }

        private void bttn_53_Click(object sender, RoutedEventArgs e)
        {
            th.teethSourceId("53");
            if (bool53)
            {
                icon53.Kind = MahApps.Metro.IconPacks.PackIconEntypoKind.Circle;
                icon53.Foreground = Brushes.Black;
                bool53 = false;
            }
            else
            {
                icon53.Kind = MahApps.Metro.IconPacks.PackIconEntypoKind.CircleWithCross;
                icon53.Foreground = Brushes.Red;
                bool53 = true;
            }
        }

        private void bttn_52_Click(object sender, RoutedEventArgs e)
        {
            th.teethSourceId("52");
            if (bool52)
            {
                icon52.Kind = MahApps.Metro.IconPacks.PackIconEntypoKind.Circle;
                icon52.Foreground = Brushes.Black;
                bool52 = false;
            }
            else
            {
                icon52.Kind = MahApps.Metro.IconPacks.PackIconEntypoKind.CircleWithCross;
                icon52.Foreground = Brushes.Red;
                bool52 = true;
            }
        }
        private void bttn_51_Click(object sender, RoutedEventArgs e)
        {
            th.teethSourceId("51");
            if (bool51)
            {
                icon51.Kind = MahApps.Metro.IconPacks.PackIconEntypoKind.Circle;
                icon51.Foreground = Brushes.Black;
                bool51 = false;
            }
            else
            {
                icon51.Kind = MahApps.Metro.IconPacks.PackIconEntypoKind.CircleWithCross;
                icon51.Foreground = Brushes.Red;
                bool51 = true;
            }
        }

        #endregion
        private void bttn_save_Click(object sender, RoutedEventArgs e)
        {
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
            //foreach (dentalrecord.teethsource coll in th.teeth_source)
            //{

            //    MessageBox.Show(coll.teeth_id.ToString());
            //}
        }
    }
}
