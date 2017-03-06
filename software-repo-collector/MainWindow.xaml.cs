using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;
using MessageBox = System.Windows.Forms.MessageBox;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Collections.Specialized;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Property = software_repo_collector.Properties.Settings;


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
        
        private void menu_Preferences_Click(object sender, RoutedEventArgs e)
        {
            Configuration1 config1 = new Configuration1();
            if (config1.ShowDialog() == true)
            {
                Property.Default.Repository_Path = config1.Path;
                Property.Default.Extension_Filter = config1.Extension_Filter;
                Property.Default.Save();        
            }
        }

        private void btn_Scan_Click(object sender, RoutedEventArgs e)
        {
            list_Scanned_Files.Items.Clear();
            DirectoryInfo dirInfo = new DirectoryInfo(Property.Default.Repository_Path);
            FileInfo[] files = dirInfo.GetFiles(Property.Default.Extension_Filter);
            foreach (FileInfo file in files)
            {
                list_Scanned_Files.Items.Add(file.Name);
            }
            MessageBox.Show("Found "+files.Length.ToString()+" files");
        }

        private void list_Scanned_Files_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btn_Save_Software_Click(object sender, RoutedEventArgs e)
        {
            if (Property.Default.Name_Collections==null)
            {
                Property.Default.Name_Collections = new StringCollection();
                Property.Default.Pattern_Collections = new StringCollection();
            }
            if (!Property.Default.Name_Collections.Contains(txt_Software_Name_Add.Text))
            {
                Property.Default.Name_Collections.Add(txt_Software_Name_Add.Text);
                Property.Default.Pattern_Collections.Add(txt_Pattern_Add.Text);
            }
        }
    }
}
