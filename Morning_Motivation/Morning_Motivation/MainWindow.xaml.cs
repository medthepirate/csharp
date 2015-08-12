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
using System.IO;

namespace Morning_Motivation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string sFeeling, mgoal, wgoal, dgoal, sGood, sBad, sExcited, sForward, sGrateful, path;
        public MainWindow()
        {
            InitializeComponent();
            // get current path
            path = System.Environment.CurrentDirectory;
            //get the monthly goal and weekly goal from a file and insert it
            mgoal = File.ReadAllText(path + "\\mgoal.txt");
            wgoal = File.ReadAllText(path + "\\wgoal.txt");
            monthgoal.Text = mgoal;
            weekgoal.Text = wgoal;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sFeeling = feeling.SelectedValue.ToString().Split(':').Last();
            
            
        }

        private void log_Click(object sender, RoutedEventArgs e)
        {
            DateTime d = DateTime.Now;
            string ds = d.ToString("d-M-yyyy");
            string writeString = d + "\r\n" + sFeeling + "\r\n" + sGood + "\r\n" + sBad + "\r\n" + sForward + "\r\n" + sExcited + "\r\n" + sGrateful + "\r\n" + mgoal + "\r\n" + wgoal;
            File.WriteAllText(path + "\\briefings\\" + ds + "_briefing.txt", writeString);
        }

        private void monthgoal_TextChanged(object sender, TextChangedEventArgs e)
        {
            File.WriteAllText(path + "\\mgoal.txt", monthgoal.Text);
        }

        private void daygoal_TextChanged(object sender, TextChangedEventArgs e)
        {
            dgoal = daygoal.Text;
        }

        private void good_TextChanged(object sender, TextChangedEventArgs e)
        {
            sGood = good.Text;
        }

        private void bad_TextChanged(object sender, TextChangedEventArgs e)
        {
            sBad = bad.Text;
        }

        private void forward_TextChanged(object sender, TextChangedEventArgs e)
        {
            sForward = forward.Text;
        }

        private void grateful_TextChanged(object sender, TextChangedEventArgs e)
        {
            sGrateful = grateful.Text;
        }

        private void excited_TextChanged(object sender, TextChangedEventArgs e)
        {
            sExcited = excited.Text;
        }

        private void weekgoal_TextChanged(object sender, TextChangedEventArgs e)
        {
            File.WriteAllText(path + "\\wgoal.txt", weekgoal.Text);
        }

        private void read_Click(object sender, RoutedEventArgs e)
        {
            DateTime d = DateTime.Now;
            string ds = d.ToString("d-M-yyyy");

            if (File.Exists(path + "\\briefings\\" + ds + "_briefing.txt"))
            {
                System.Diagnostics.Process.Start(path + "\\briefings\\" + ds + "_briefing.txt");
            }
        }
    }
}
