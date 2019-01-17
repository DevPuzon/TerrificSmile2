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
    /// Interaction logic for ucontrol_report.xaml
    /// </summary>
    public partial class ucontrol_report : UserControl
    {
        public ucontrol_report()
        {
            InitializeComponent();
            r.receipt();
            _datagrid_report();
        }
        report r = new report();
        dentalInformation di = new dentalInformation();
        private void _datagrid_report()
        {
            datagrid_report.ItemsSource = di.information_source;
            di._select();
        }
       
        private void txtbox_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            di._clear();
            di._search(txtbox_search.Text);
        }


    }
}
