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
using Microsoft.Win32;

namespace ReesterEditer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Header header;
        public MainWindow()
        {
            InitializeComponent();

            header = new Header
            {
                root = Registry.ClassesRoot.Name,
                user = Registry.CurrentUser.Name,
                machine = Registry.LocalMachine.Name,
                data = Registry.PerformanceData.Name,
                config = Registry.CurrentConfig.Name,
            };
            this.DataContext = header;

            
        }
        private void Add()
        {
            string[] User = Registry.CurrentUser.GetSubKeyNames();

            foreach (string key in User)
            {
                TreeViewItem item = new TreeViewItem();
                item.Header = item;
                item.Items.Add("*");
                USER.Items.Add(item);
            }
        }

        private void USER_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = (TreeViewItem)e.OriginalSource;
            item.Items.Clear();
            string[] key = Registry.CurrentUser.GetSubKeyNames();
            try
            {
                foreach (string subkey in key)
                {
                    TreeViewItem newItem = new TreeViewItem();
                    newItem.Header = subkey;
                    newItem.Items.Add("*");
                    item.Items.Add(newItem);
                }
            }
            catch
            { }
        }
    }
    class Header
    {
        public string root { get; set; }
        public string user { get; set; }
        public string machine { get; set; }
        public string data { get; set; }
        public string config { get; set; }
    }
}
