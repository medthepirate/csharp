using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace briefMe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //array to store the strings to be read/printed at the end
        string[] speechToText;
        public static string briefing,feeling, dailyGoal, weeklyGoal, monthlyGoal, lookingForward, good, bad, fix, grateful, excited, wow, remember, act,exercise;
        public static string[] tasks;
        public static int headlines;
        public MainWindow()
        {
            InitializeComponent();
            checkForSetup();
            checkForURLs();
            
        }
        private void checkForSetup()
        {

            if (!File.Exists("setup.txt"))
            {
                File.Create("setup.txt").Close();
                File.WriteAllText("setup.txt", "=initial=good morning! here are the headlines" + Environment.NewLine + 
                    "=numheadlines=3" + Environment.NewLine + 
                    "=dailygoal= =0" + Environment.NewLine + 
                    "=weeklygoal= =0" + Environment.NewLine + 
                    "=monthlygoal= =0" + Environment.NewLine + 
                    "=feeling=" + Environment.NewLine + 
                    "=good=" + Environment.NewLine + 
                    "=bad=" + Environment.NewLine + 
                    "=action= =0" + Environment.NewLine + 
                    "=grateful=" + Environment.NewLine + 
                    "=excited="+ Environment.NewLine +
                    "=forward=" + Environment.NewLine + 
                    "=exercise= =0" + Environment.NewLine + 
                    "=wow= =0" + Environment.NewLine + 
                    "=remember= =0" + Environment.NewLine + 
                    "=act= =0" + Environment.NewLine + 
                    "=conclusion=okay thats it, now finish your coffee, take your vitamins, drink some water, give me 50 and have a shower maggot!");
            }
        }

        private void checkForURLs()
        {
            if (!File.Exists("URLs.txt"))
            {
                File.Create("URLs.txt").Close();
                File.WriteAllText("URLs.txt", "=www.bbc.co.uk/news" + Environment.NewLine + "=www.bbc.co.uk/weather");
            }
        }
        //hitme
        private void hit_click(object sender, RoutedEventArgs e)
        {
            new hitme();   
        }
    
        //settings click
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void open_Click(object sender, RoutedEventArgs e)
        {
            string path = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Environment.CurrentDirectory + "\\briefings";
            ofd.ShowDialog();
            //TODO fix file dialog
            path = ofd.FileName;
            new oldBriefing(path);
        }
    }
}
