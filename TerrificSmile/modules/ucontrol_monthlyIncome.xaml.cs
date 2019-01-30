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

namespace TerrificSmile.modules
{
    /// <summary>
    /// Interaction logic for ucontrol_monthlyIncome.xaml
    /// </summary>
    public partial class ucontrol_monthlyIncome : UserControl
    {
        public ucontrol_monthlyIncome()
        {
            InitializeComponent();
        }
        public static string _comboxYear()
        {
            string a;
            a = combox_year.Text;
            return a;
        }
    }
}
