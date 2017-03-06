using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Property = software_repo_collector.Properties.Settings;

namespace software_repo_collector
{
    /// <summary>
    /// Interaction logic for Configuration1.xaml
    /// </summary>
    public partial class Configuration1 : Window
    {
        public Configuration1()
        {
            InitializeComponent();
        }
        String path;
        String extension_filter;

        string[] fileEntries;

        public String Path
        {
            get
            {
                return path;
            }
        }

        public string[] FileEntries
        {
            get
            {
                return fileEntries;
            }
        }

        public String Extension_Filter
        {
            get
            {
                return extension_filter;
            }
        }

        private void btn_Browse_Folder_Click(object sender, RoutedEventArgs e)
        {
            DialogResult warning_result = System.Windows.Forms.MessageBox.Show("Changing your repository path will replace the list of your currently added files in the application, Are you sure about this?", "Warning", MessageBoxButtons.YesNo);
            if (warning_result == System.Windows.Forms.DialogResult.Yes)
            {
                using (var dialog = new FolderBrowserDialog())
                {
                    DialogResult result = dialog.ShowDialog();
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        path = dialog.SelectedPath;
                        txt_Repository_Path_Result.Text = path;
                        if (Directory.Exists(path))
                        {
                            fileEntries = Directory.GetFiles(path);
                        }
                        else
                        {
                            MessageBox.Show("Path does not exist");
                        }
                    }
                }

            }
        }

        private void btn_Save_And_Close_Click(object sender, RoutedEventArgs e)
        {
            this.path = txt_Repository_Path_Result.Text;
            this.extension_filter = txt_Extension_Filter.Text;
            this.DialogResult = true;
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txt_Repository_Path_Result.Text = Properties.Settings.Default.Repository_Path;
            txt_Extension_Filter.Text = Properties.Settings.Default.Extension_Filter;
            foreach(String scol in Property.Default.Name_Collections)
            {
                list_Software_Names.Items.Add(scol);
            }
        }
    }
}
