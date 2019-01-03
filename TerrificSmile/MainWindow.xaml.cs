using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using TerrificSmile.modules;

namespace TerrificSmile
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ucontrol_dentalchart1 h = new ucontrol_dentalchart1();
            ucontrol_main.Content = h;
        }
        private void bttn_windowclose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void grid_drag_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        bool click;
        private void bttn_windowmaximize_Click(object sender, RoutedEventArgs e)
        {
            if (click)
            {
                this.WindowState = WindowState.Maximized;
                click = false;
            }else
            {
                this.WindowState = WindowState.Normal;
                 click = true;
            }
            
        }

        private void bttn_windowminimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void bttn_dentalrecord_Click(object sender, RoutedEventArgs e)
        {
            ucontrol_dentalchart1 h = new ucontrol_dentalchart1();
            ucontrol_main.Content = h;
        }

        private void bttn_report_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bttn_admin_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bttn_devoption_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bttn_about_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
