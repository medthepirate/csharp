using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AST_IT_Support
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //create listener
        private void button1_Click(object sender, EventArgs e)
        {
            string d = DateTime.Today.ToString("d-M-yyyy");
            string priority = "";
            string path = Environment.CurrentDirectory;
            if (radioButton1.Checked)
            {
                priority = "low";
                path = path + "\\low\\";
            }
            else if (radioButton2.Checked)
            {
                priority = "medium";
                path = path + "\\medium\\";
            }
            else if (radioButton3.Checked)
            {
                priority = "high";
                path = path + "\\high\\";
            }
            else
            {
                priority = "no priority set";
                path = path + "\\high\\";
            }
            //build the string to write
            String str = d + "\r\nstaff member: " + sname.Text + "\r\njob title: " + jtitle.Text + "\r\npriority: " + priority + "\r\njob description: \r\n" + desc.Text + "\r\n";
            //build path
            System.IO.File.WriteAllText(path + d + "_" + jtitle.Text + ".txt", str);
            MessageBox.Show("Success", "Your ticket has been created", MessageBoxButtons.OK);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Environment.CurrentDirectory;
            DialogResult result = ofd.ShowDialog();
            String job = "";
            String path = "";
            if (result == DialogResult.OK)
            {
                path = ofd.FileName;
                job = System.IO.File.ReadAllText(path);

                Form2 jw = new Form2(job,path);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String bible = Environment.CurrentDirectory + "\\AST_it_bible.txt";
            if (System.IO.File.Exists(bible))
            {
                System.Diagnostics.Process.Start(@bible);
            }
            else
            {
                MessageBox.Show("Someone has moved the IT manual... please replace it at r:\\AST_it_bible.txt", "Woops!", MessageBoxButtons.OK);
            }
        }
    }
}
