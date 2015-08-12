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

namespace ITSupport
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

        private void create_Click(object sender, RoutedEventArgs e)
        {
            string d = DateTime.Today.ToString("d-M-yyyy");
            string priority = "";
            string path = "";
            //turn the checkboxes into radios...
            if ((bool)plow.IsChecked&&!((bool)phigh.IsChecked)&&!((bool)pmed.IsChecked)) {
                priority = "low";
                path = "c:\\briefings\\low\\";
            }
            else if ((bool)pmed.IsChecked && !((bool)phigh.IsChecked) && !((bool)plow.IsChecked))
            {
                priority = "medium";
                path = "c:\\briefings\\medium\\";
            }
            else if ((bool)phigh.IsChecked && !((bool)plow.IsChecked) && !((bool)pmed.IsChecked))
            {
                priority = "high";
                path = "c:\\briefings\\high\\";
            }
            else
            {
                priority = "erroneous priority set";
                path = "c:\\briefings\\";
            }
            //build the string to write
            string str = d + "\r\nstaff member: " + sname.Text + "\r\njob title: " + jtitle.Text + "\r\npriority: " + priority + "\r\njob description: \r\n"+desc.Text + "\r\n";
            //build path
            System.IO.File.WriteAllText(path + d +"_" + jtitle.Text + ".txt", str);
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

 /*       private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            string job;
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                job = System.IO.File.ReadAllText(dlg.FileName);

                //JobWindow jw = new JobWindow();
                //jw.Show();
            }
            
        }*/

    }
}
