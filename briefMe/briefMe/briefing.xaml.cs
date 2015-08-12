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
using System.Net.NetworkInformation;


namespace briefMe
{
    /// <summary>
    /// Interaction logic for briefing.xaml
    /// </summary>
    public partial class briefing : Window
    {
        private static int dailyTick, weeklyTick, monthlyTick, fixTick, excerciseTick, wowTick, rememberTick, actTick;
        int[] ticks = {dailyTick,weeklyTick, monthlyTick, fixTick,excerciseTick,wowTick,rememberTick,actTick};
        public string pth;
        public briefing()
        {
            InitializeComponent();
            //initialise the ticks
            for (int i = 0; i < ticks.Length; i++)
            {
                ticks[i] = 0;
            }
            //MessageBox.Show(actTick.ToString(),"debug",MessageBoxButton.OK); //place this code to 'print' variables
            //get date for new file
            DateTime d = new DateTime();
            d = DateTime.Now;
            string ds = d.ToString("yyyy-M-d");
            //create the file and write the briefing
            string fn = ds + "_briefing.txt";
            //TODO change logic (read/write can come outside of condition)
            if (!File.Exists("briefings\\" + fn))
            {
                File.Create("briefings\\" + fn).Close();
                string temp = File.ReadAllText("setup.txt");
                File.WriteAllText("briefings\\" + fn, temp);
            }
            else
            {
                string temp = File.ReadAllText("setup.txt");
                File.WriteAllText("briefings\\" + fn, temp);
            }
            pth = "briefing\\" + fn;
            //TODO checkboxes and labels (refactor when working)
            dailygoalcheck.Content = MainWindow.dailyGoal;
            weeklygoalcheck.Content = MainWindow.weeklyGoal;
            monthlygoalcheck.Content = MainWindow.monthlyGoal;
            goodcheck.Content = MainWindow.good;
            badcheck.Content = MainWindow.bad;
            fixcheck.Content = MainWindow.fix;
            gratefulcheck.Content = MainWindow.grateful;
            excitedcheck.Content = MainWindow.excited;
            forwardcheck.Content = MainWindow.lookingForward;
            exercisecheck.Content = MainWindow.exercise;
            wowcheck.Content = MainWindow.wow;
            remembercheck.Content = MainWindow.remember;
            actcheck.Content = MainWindow.act;
            //TODO string conclusion = File.ReadAllText("setup.txt").Split('=')[36];
            //num of headlines
            
            this.Show();
            //speech code goes here
           
            //create the url
            string strURL = "http://www.bbc.co.uk/news";
            //create a voice object
            SpVoice voice = new SpVoice();
           
            //check internet connection
            bool connected = checkInternet("http://www.google.com");
            /*delete to add voice
            if (connected)
            {
                //create a webclient to scrape with
                WebClient wc = new WebClient();
                //download the html as a string
                string markup = wc.DownloadString(strURL);
                // create the regex to search for paragraph text
                Regex regex = new Regex("(<p.*?>)(.*?)(?=</p>)");
                // check for matches and create a collection 
                MatchCollection hlmatches = regex.Matches(markup);
                for (int i = 0; i < MainWindow.headlines; i++)
                {
                    //check that its not a paragraph about cookies
                    Regex cookieCheck = new Regex("Cookie|cookie");
                    // build this string
                    string hl = hlmatches[i].ToString();
                    //check for cookies
                    if (!cookieCheck.IsMatch(hl))
                    {
                        voice.Speak(hl);
                    }//TODO test this with new logic
                }
                // get the weather
                strURL = "http://www.bbc.co.uk/weather";
                regex = new Regex("(?<=headline.*?>)(.*?)(?=</p>)"); 
                markup = wc.DownloadString(strURL);
                Match wMatch = regex.Match(markup);
                voice.Speak(wMatch.ToString());
            }
            else
            {
                voice.Speak("I could not connect to the news website, sorry");
            }
            voice.Speak("You're goal for the day is " + MainWindow.dailyGoal);
            Thread.Sleep(1000);
            voice.Speak("your weekly goal is " + MainWindow.weeklyGoal);
            Thread.Sleep(1000);
            voice.Speak("your monthly goal is " + MainWindow.monthlyGoal);
            Thread.Sleep(1000);
            voice.Speak("you are feeling " + MainWindow.feeling + "out of ten");
            Thread.Sleep(1000);
            voice.Speak(MainWindow.good + " was good yesterday");
            Thread.Sleep(1000);
            voice.Speak(MainWindow.bad + " was bad yesterday");
            Thread.Sleep(1000);
            voice.Speak("you will " + MainWindow.fix +" to fix this");
            Thread.Sleep(1000);
            voice.Speak("you are grateful for " + MainWindow.grateful);
            Thread.Sleep(1000);
            voice.Speak("you are excited about " + MainWindow.excited);
            Thread.Sleep(1000);
            voice.Speak("you are looking forward to " + MainWindow.lookingForward);
            Thread.Sleep(1000);
            voice.Speak("you will exercise with " + MainWindow.exercise);
            Thread.Sleep(1000);
            voice.Speak("you will wow people by "+MainWindow.wow);
            Thread.Sleep(1000);
            voice.Speak("do not forget "+MainWindow.remember);
            Thread.Sleep(1000);
            voice.Speak("you need to act " + MainWindow.act);
            Thread.Sleep(1000);
            voice.Speak("okay thats it, now finish your coffee, take your vitamins, drink some water, give me 50 and have a shower maggot!");*/
        }

        public static bool checkInternet(string sURL)
        {
            Uri url = new Uri(sURL);
            string pingurl = string.Format("{0}", url.Host);
            string host = pingurl;
            Ping p = new Ping();
            bool result = false;
            try
            {
                PingReply r = p.Send(host, 3000);
                if (r.Status == IPStatus.Success)
                {
                    return true;
                }
            }
            catch { }
            return result;

        }

        private void saveState(string briefingPath)
        {
            //TODO broken string
            MainWindow.briefing = "=initial=good morning! here are the headlines" + Environment.NewLine +
                    "=numheadlines=3" + Environment.NewLine +
                    "=dailygoal="+MainWindow.dailyGoal +"="+dailyTick.ToString()+ Environment.NewLine +
                    "=weeklygoal=" + MainWindow.weeklyGoal +"="+ weeklyTick.ToString() + Environment.NewLine +
                    "=monthlygoal=" + MainWindow.monthlyGoal+ "="+monthlyTick.ToString() +Environment.NewLine +
                    "=feeling="+MainWindow.feeling + Environment.NewLine +
                    "=good=" + MainWindow.good+ Environment.NewLine +
                    "=bad="+MainWindow.bad + Environment.NewLine +
                    "=action= ="+MainWindow.fix+"="+fixTick.ToString()+ Environment.NewLine +
                    "=grateful=" +MainWindow.grateful+ Environment.NewLine +
                    "=excited=" +MainWindow.excited+ Environment.NewLine +
                    "=forward=" +MainWindow.lookingForward+ Environment.NewLine +
                    "=exercise= =" + MainWindow.exercise +"="+ excerciseTick.ToString() + Environment.NewLine +
                    "=wow= =" + MainWindow.wow+"="+ wowTick.ToString() + Environment.NewLine +
                    "=remember= =" + MainWindow.remember +"="+ rememberTick.ToString() + Environment.NewLine +
                    "=act= =" + MainWindow.act +"="+ actTick.ToString() + Environment.NewLine +
                    "=conclusion=okay thats it, now finish your coffee, take your vitamins, drink some water, give me 50 and have a shower maggot!";
           
            File.WriteAllText(pth,MainWindow.briefing);
        }
        private void update_click(object sender, RoutedEventArgs e)
        {

        }
    }
}
