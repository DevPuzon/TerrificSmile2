﻿using System;
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
    /// Interaction logic for ucontrol_admin.xaml
    /// </summary>
    public partial class ucontrol_admin : UserControl
    {
        public ucontrol_admin()
        {
            InitializeComponent();
        }

        private void bttn_login_Click(object sender, RoutedEventArgs e)
        {
            grid_adminform.Visibility = Visibility.Collapsed;
        }
    }
}