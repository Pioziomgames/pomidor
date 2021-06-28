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
using DarkUI.Forms;




namespace Pomidor
{
    public partial class Form1 : DarkForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void darkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string[] files = Directory.GetFiles(pathTextBox.Text, "*.amd", SearchOption.AllDirectories);
                AllFIlesProgressBar.Value = 0;
                CurrentFileProgressBar.Value = 0;
                AllFIlesProgressBar.Maximum = files.Length;
            }
            catch
            {
                MessageBox.Show("Error while searching for amd files");
            
            }

            //Here is where the pain begins
        }

        private void darkLabel4_Click(object sender, EventArgs e)
        {

        }
    }
}
