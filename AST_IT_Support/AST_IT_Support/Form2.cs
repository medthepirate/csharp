using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AST_IT_Support
{
    public partial class Form2 : Form
    {
        String ojob, opath;

        public Form2(String job, String path)
        {
            this.ojob = job;
            this.opath = path;
            InitializeComponent();
            textBox1.Text = job;
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //sign off functionality
        private void button2_Click(object sender, EventArgs e)
        {
            String fn = Path.GetFileName(opath);
            System.IO.File.Move(opath, Environment.CurrentDirectory+ "\\closed\\" + fn);
            DialogResult result = MessageBox.Show("Ticket marked as closed", "sign off", MessageBoxButtons.OK);
            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }
        //amend button functionality
        private void button1_Click(object sender, EventArgs e)
        {
            System.IO.File.WriteAllText(opath, textBox1.Text);
            DialogResult dr = MessageBox.Show("Your ticket has been amended", "updated", MessageBoxButtons.OK);
            if (dr == DialogResult.OK)
            {
                this.Close();
            }
        }


    }
}
