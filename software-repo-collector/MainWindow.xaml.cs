﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace software_repo_collector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        String path;
        private void menu_Preferences_Click(object sender, RoutedEventArgs e)
        {
            Configuration1 config1 = new Configuration1();
            if (config1.ShowDialog() == true)
            {
                path = config1.Path;
                Properties.Settings.Default.Repository_Path = path;
                Properties.Settings.Default.Save();
            }
        }
    }
}
