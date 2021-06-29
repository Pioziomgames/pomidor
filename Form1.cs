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
                if (files.Length < 1)
                {
                    MessageBox.Show("No Amd files found");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Error while searching for amd files");
                return;
            }
            if (File.Exists(newmdstextbox.Text))
            {
                string NewParts = "";
                string NewBones = "";
                string NewMaterials = "";
                string NewTextures = "";
                try
                {
                    string line;
                    using (StreamReader streamReader = new StreamReader(newmdstextbox.Text, Encoding.UTF8))
                    {
                        bool savepart = false;
                        bool savebone = false;
                        bool savetexture = false;
                        bool savematerial = false;
                        while ((line = streamReader.ReadLine()) != null)
                        {
                            if (line.StartsWith("\tMotion \""))
                            {
                                savematerial = false;
                                savepart = false;
                                savetexture = false;
                                savebone = false;
                            }
                            if (line.StartsWith("\tBone \""))
                            {
                                savematerial = false;
                                savepart = false;
                                savetexture = false;
                                savebone = true;
                            }
                            if (line.StartsWith("\tPart \""))
                            {
                                savematerial = false;
                                savebone = false;
                                savetexture = false;
                                savepart = true;
                            }
                            if (line.StartsWith("\tMaterial \""))
                            {
                                savepart = false;
                                savebone = false;
                                savetexture = false;
                                savematerial = true;
                            }
                            if (line.StartsWith("\tTexture \""))
                            {
                                savepart = false;
                                savematerial = false;
                                savebone = false;
                                savetexture = true;
                            }
                            if (savepart)
                                NewParts += line;
                            if (savebone)
                                NewBones += line;
                            if (savetexture)
                                NewTextures += line;
                            if (savematerial)
                                NewMaterials += line;
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Error while reading mds file");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Mds file doesn't exists");
                return;
            }
            //Here is where the pain begins
        }

        private void darkLabel4_Click(object sender, EventArgs e)
        {

        }
    }
}
