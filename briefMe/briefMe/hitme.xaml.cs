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
using System.Windows.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpeechLib; //add reference..
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.IO;


namespace briefMe
{
    /// <summary>
    /// Interaction logic for hitme.xaml
    /// </summary>
    public partial class hitme : Window
    {
        public hitme()
        {
            InitializeComponent();
            dailygoalbox.Text = getField(6,"setup.txt");
            weeklygoalbox.Text = getField(9, "setup.txt");
            monthlygoalbox.Text = getField(12, "setup.txt");
            string numhl = getField(4, "setup.txt");
            MainWindow.headlines = int.Parse(numhl);
            //initially assign the goals
            MainWindow.dailyGoal = dailygoalbox.Text;
            MainWindow.weeklyGoal = weeklygoalbox.Text;
            MainWindow.monthlyGoal = monthlygoalbox.Text;
            this.Show();
            //speech code goes here
            //create a voice object
            //working but annoying for dev
            /*delete comment to add voice
            SpVoice voice = new SpVoice();
            voice.Speak("Ready?! Let's go. What is your goal for the day?");
            Thread.Sleep(5000);
            voice.Speak("what is your goal for the week?");
            Thread.Sleep(5000);
            voice.Speak("what is your goal for the month?");
            Thread.Sleep(5000);
            voice.Speak("how are you feeling today?");
            Thread.Sleep(5000);
            voice.Speak("what was good yesterday?");
            Thread.Sleep(5000);
            voice.Speak("what was bad yesterday?");
            Thread.Sleep(5000);
            voice.Speak("and what will you do to fix this?");
            Thread.Sleep(5000);
            voice.Speak("what are you grateful for in your life today?");
            Thread.Sleep(5000);
            voice.Speak("what are you excited about in your life today?");
            Thread.Sleep(5000);
            voice.Speak("what are you looking forward to?");
            Thread.Sleep(5000);
            voice.Speak("how will you exercise your body today?");
            Thread.Sleep(5000);
            voice.Speak("how will you wow people?");
            Thread.Sleep(5000);
            voice.Speak("what do you need to remember?");
            Thread.Sleep(5000);
            voice.Speak("How do you need to act today?");
            Thread.Sleep(5000);
            voice.Speak("OK, now fill in the form and I'll record it all, and we can begin your briefing...");*/
        }

        //method to get from the file
        string getField(int num, string filePath)
        {
            //read the file to the string
            string setupText = File.ReadAllText(filePath);
            setupText = setupText.Split('=')[num];
            return setupText;    
        }

        //feelingbox
        private void feelingbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainWindow.feeling = feelingbox.SelectedValue.ToString().Split(':')[1] + " "; // add space for voice to read properly
            //updateSetup(); 
        }

        private void dailygoalbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            updateSetup(); 
        }

        private void weeklygoalbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            updateSetup(); 
        }

        private void monthlygoalbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            updateSetup(); 
        }

        private void goodbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            MainWindow.good = goodbox.Text;
            //updateSetup(); 
        }

        private void badbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            MainWindow.bad = badbox.Text;
            //updateSetup(); 
        }

        private void actionbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            MainWindow.fix = actionbox.Text;
            //updateSetup(); 
        }

        private void gratefulbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            MainWindow.grateful = gratefulbox.Text;
            //updateSetup(); 
        }

        private void excitedbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            MainWindow.excited = excitedbox.Text;
            //updateSetup(); 
        }

        private void forwardbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            MainWindow.lookingForward = forwardbox.Text;
            //updateSetup(); 
        }

        private void exercisebox_TextChanged(object sender, TextChangedEventArgs e)
        {
            MainWindow.exercise = exercisebox.Text;
            //updateSetup(); 
        }

        private void wowbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            MainWindow.wow = wowbox.Text;
            //updateSetup();
        }

        private void rememberbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            MainWindow.remember = rememberbox.Text;
            //updateSetup();
        }

        private void actbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            MainWindow.act = actbox.Text;
            //updateSetup();
        }

        private void updateSetup()
        {
            
            MainWindow.monthlyGoal = monthlygoalbox.Text.Split('\n')[0];
            MainWindow.weeklyGoal = weeklygoalbox.Text.Split('\n')[0];
            MainWindow.dailyGoal = dailygoalbox.Text.Split('\n')[0];
        
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            updateSetup();
            MainWindow.briefing = "=initial=good morning! here are the headlines" + Environment.NewLine +
                    "=numheadlines=3" + Environment.NewLine +
                    "=dailygoal= =0"+MainWindow.dailyGoal + Environment.NewLine +
                    "=weeklygoal= =0" + MainWindow.weeklyGoal+ Environment.NewLine +
                    "=monthlygoal= =0" + MainWindow.monthlyGoal+ Environment.NewLine +
                    "=feeling="+MainWindow.feeling + Environment.NewLine +
                    "=good=" + MainWindow.good+ Environment.NewLine +
                    "=bad="+MainWindow.bad + Environment.NewLine +
                    "=action= =0"+MainWindow.fix + Environment.NewLine +
                    "=grateful=" +MainWindow.grateful+ Environment.NewLine +
                    "=excited=" +MainWindow.excited+ Environment.NewLine +
                    "=forward=" +MainWindow.lookingForward+ Environment.NewLine +
                    "=exercise= =0" +MainWindow.exercise+ Environment.NewLine +
                    "=wow= =0" + MainWindow.wow + Environment.NewLine +
                    "=remember= =0" +MainWindow.remember+ Environment.NewLine +
                    "=act= =0" +MainWindow.act+ Environment.NewLine +
                    "=conclusion=okay thats it, now finish your coffee, take your vitamins, drink some water, give me 50 and have a shower maggot!";
           
            File.WriteAllText("setup.txt", MainWindow.briefing);
            this.Close(); 
            Window br = new briefing();
            
        }
    }
}
