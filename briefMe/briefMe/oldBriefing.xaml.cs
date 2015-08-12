using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace briefMe
{
    /// <summary>
    /// Interaction logic for oldBriefing.xaml
    /// </summary>
    public partial class oldBriefing : Window
    {
        private static int dailyTick, weeklyTick, monthlyTick, fixTick, excerciseTick, wowTick, rememberTick, actTick;
        int[] ticks = { dailyTick, weeklyTick, monthlyTick, fixTick, excerciseTick, wowTick, rememberTick, actTick };

        public oldBriefing(string path)
        {
            InitializeComponent();
            this.Show();
            //TODO create the GUI and 'getField's to variables etc
            test.Text = File.ReadAllText(path);
        }

        //method to get from the file
        string getField(int num, string filePath)
        {
            //read the file to the string
            string setupText = File.ReadAllText(filePath);
            setupText = setupText.Split('=')[num];
            return setupText;
        }
    }
}
