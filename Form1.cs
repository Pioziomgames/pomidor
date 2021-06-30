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
using AtlusFileSystemLibrary;
using AtlusFileSystemLibrary.FileSystems.PAK;
using AtlusFileSystemLibrary.Common.IO;
using AmicitiaLibrary.FileSystems.AMD;
using System.Diagnostics;
using System.Reflection;
using Microsoft.WindowsAPICodePack.Dialogs;


namespace Pomidor
{
    public partial class Form1 : DarkForm
    {
        public Form1()
        {
            InitializeComponent();
            this.FormClosed += Form1_Closed;
        }
        string PathToAmd = "";
        string PathToMds = "";
        string ThingsToDelete = "";
        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)+ "\\config.pain"))
            {
                string line;
                System.IO.StreamReader file =
                    new System.IO.StreamReader(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\config.pain");
                string bigTextBox = "";
                bool savetoBig = false;
                while ((line = file.ReadLine()) != null)
                {
                    if (line.StartsWith("PathToAmd: "))
                        PathToAmd = line.Replace("PathToAmd: ", "");
                    if (line.StartsWith("PathToMds: "))
                        PathToMds = line.Replace("PathToMds: ", "");
                    if (line.StartsWith("ThingsToDelete: "))
                    {
                        bigTextBox = line.Replace("ThingsToDelete: ", "");
                        savetoBig = true;
                    }
                    if (line.StartsWith("ThingsToDelete_end"))
                    {
                        savetoBig = false;
                    }
                    if (!line.StartsWith("ThingsToDelete: ") && savetoBig == true)
                    {
                        bigTextBox += "\n" +line;
                    }

                }
                ThingsToDelete = bigTextBox;
                Debug.WriteLine("Path to Amd" + PathToAmd);
                pathTextBox.Text = PathToAmd;
                newmdstextbox.Text = PathToMds;
                Debug.WriteLine("Path to mds" + PathToMds);
                ParttoDeleteTextBox.Text = ThingsToDelete;
                Debug.WriteLine("to delte" + ThingsToDelete);
                file.Close();
            }
            
        }
        protected void Form1_Closed(object sender, EventArgs e)
        {
            PathToAmd = pathTextBox.Text;
            PathToMds = newmdstextbox.Text;
            ThingsToDelete = ParttoDeleteTextBox.Text;
            string config;
            config = "PathToAmd: " + PathToAmd;
            config += "\nPathToMds: " + PathToMds;
            config += "\nThingsToDelete: " + ThingsToDelete;
            config += "\nThingsToDelete_end";

            using (StreamWriter writetext = new StreamWriter(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\config.pain"))
            {
                writetext.WriteLine(config);
            }
        }
        private void darkButton1_Click(object sender, EventArgs e)
        {
            string[] files;
            try
            {
                files = Directory.GetFiles(pathTextBox.Text, "*.amd", SearchOption.AllDirectories);
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
            string NewParts = "";
            string NewBones = "";
            string NewMaterials = "";
            string NewTextures = "";
            if (File.Exists(newmdstextbox.Text))
            {
                
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
                                NewParts += line + "\n";
                            if (savebone)
                                NewBones += line + "\n";
                            if (savetexture)
                                NewTextures += line + "\n";
                            if (savematerial)
                                NewMaterials += line + "\n";
                        }
                        streamReader.Close();
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
            List<string> bones = new List<string>();
            List<string> parts = new List<string>();
            List<string> textures = new List<string>();
            List<string> materials = new List<string>();
            //Read the textbox with parts to delete
            if (ParttoDeleteTextBox.Text != "")
            {
                using (System.IO.StringReader reader = new System.IO.StringReader(ParttoDeleteTextBox.Text))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    { 
                        if (line.StartsWith("Bone") )
                        {
                            bones.Add( "\t" +line + " {");
                        }
                        if (line.StartsWith("Part"))
                        {
                            parts.Add("\t" + line + " {");
                        }
                        if (line.StartsWith("Texture"))
                        {
                            textures.Add("\t" + line + " {");
                        }
                        if (line.StartsWith("Material"))
                        {
                            materials.Add("\t" + line + " {");
                        }
                        
                    }

                }


            }

            //do needed things for each file
            foreach (string file in files)
            {
                LabelProgressBar.Text = "Converting to mds...";
                CurrentFileProgressBar.Value = 0;
                CurrentFileProgressBar.Maximum = 4;
                //extract gmo data from amd files
                bool extracted = false;
                AmdFile amdfile = new AmdFile(file);
                string GMOpath = "";
                foreach (var chunk in amdfile.Chunks)
                {
                    if (chunk.Tag.ToUpper().Equals("MODEL_DATA"))
                    {
                        GMOpath = Path.GetDirectoryName(file) + "\\" + Path.GetFileNameWithoutExtension(file) + ".gmo";
                        File.WriteAllBytes(GMOpath, chunk.Data);
                        
                    }
                    if (File.Exists(GMOpath))
                        extracted = true;
                }
                if (!extracted)
                {
                    Debug.WriteLine("Couldn't find model data");
                    //hopefully never happends
                }
                CurrentFileProgressBar.Value++;
                //convert gmo to mds
                Process cmd = new Process();
                cmd.StartInfo.FileName = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\Dependencies\\GMOTool\\GMOTool.exe";
                cmd.StartInfo.Arguments = $"\"{GMOpath}\"";
                cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                cmd.StartInfo.Arguments += " -E";
                cmd.Start();
                cmd.WaitForExit();
                CurrentFileProgressBar.Value++;
                //extract textures from gmo
                ExtractTextures(GMOpath);
                CurrentFileProgressBar.Value++;
                string MDSpath = Path.GetDirectoryName(file) + "\\" + Path.GetFileNameWithoutExtension(file) + ".mds";
                //split motion to a different string to modify the mds faster
                string FullFile = System.IO.File.ReadAllText(MDSpath);

                string NoMotion = FullFile.Remove(FullFile.IndexOf("\tMotion \""));
                string OnlyMotion = FullFile.Substring(FullFile.IndexOf("\tMotion \""));
                CurrentFileProgressBar.Value++;
                //edit mds
                string EditedMDS = "";
                LabelProgressBar.Text = "Editing the mds file...";
                CurrentFileProgressBar.Value = 0;
                CurrentFileProgressBar.Maximum = NoMotion.Length;
                using (System.IO.StringReader reader = new System.IO.StringReader(NoMotion))
                {
                    string line;
                    bool saveline = true;
                    int counter = 0;
                    bool bonesAdded = false;
                    bool partsAdded = false;
                    bool materialsAdded = false;
                    bool texturesAdded = false;
                    while ((line = reader.ReadLine()) != null)
                    {
                        counter++;

                        if (line.StartsWith("\tBone \""))
                        {
                            if (counter > 10 && bonesAdded == false)
                            {
                                EditedMDS += NewBones + "\n";
                                bonesAdded = true;
                            }
                            saveline = true;
                            if (string.Concat(bones).Contains(line))
                            {
                                saveline = false;
                            }
                        }
                        if (line.StartsWith("\tPart \"") )
                        {
                            if (partsAdded == false)
                            {
                                EditedMDS += NewParts + "\n";
                                partsAdded = true;
                            }
                            saveline = true;
                            if (string.Concat(parts).Contains(line))
                            {
                                saveline = false;
                            }
                        }

                        if (line.StartsWith("\tTexture \""))
                        {
                            if (texturesAdded == false)
                            {
                                EditedMDS += NewTextures + "\n";
                                texturesAdded = true;
                            }
                            saveline = true;
                            if (string.Concat(textures).Contains(line))
                            {
                                saveline = false;
                            }
                        }

                        if (line.StartsWith("\tMaterial \""))
                        {
                            if (materialsAdded == false)
                            {
                                EditedMDS += NewMaterials + "\n";
                                materialsAdded = true;
                            }
                            saveline = true;
                            if (string.Concat(materials).Contains(line))
                            {
                                saveline = false;
                            }
                        }

                        if (saveline)
                            EditedMDS += line + "\n" ;

                        CurrentFileProgressBar.Value++;
                    }
                }

                LabelProgressBar.Text = "Converting back to amd...";
                CurrentFileProgressBar.Value = 0;
                CurrentFileProgressBar.Maximum = 4;
                //overwrite mds
                using (StreamWriter writetext = new StreamWriter(MDSpath))
                {
                    writetext.Write(EditedMDS + OnlyMotion);
                }
                CurrentFileProgressBar.Value++;
                //convert to gmo
                Process cmd3 = new Process();
                cmd3.StartInfo.FileName = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\Dependencies\\GMOTool\\GMOTool.exe";
                cmd3.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                cmd3.StartInfo.Arguments = $"\"{MDSpath}\"";
                cmd3.StartInfo.Arguments += " -PSV";
                cmd3.Start();
                cmd3.WaitForExit();
                System.Threading.Thread.Sleep(1000);
                CurrentFileProgressBar.Value++;
                // run tge's tool to fix gmo
                Process cmd4 = new Process();
                cmd4.StartInfo.FileName = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\Dependencies\\p4gpc-gmofix\\p4gpc-gmofix.exe";
                cmd4.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                cmd4.StartInfo.Arguments = $"\"{GMOpath}\"";
                cmd4.Start();
                cmd4.WaitForExit();
                CurrentFileProgressBar.Value++;

                //convert gmo back to amd
                string AMDpath = Path.GetDirectoryName(file) + "\\" + Path.GetFileNameWithoutExtension(file) + ".amd";
                if (File.Exists(AMDpath))
                {
                    AmdFile amd = new AmdFile(AMDpath);
                    foreach (var chunk in amd.Chunks)
                    {
                        if (chunk.Tag.ToUpper().Equals("MODEL_DATA"))
                        {
                            chunk.Data = File.ReadAllBytes(GMOpath);
                        }
                    }
                    amd.Save(AMDpath);
                }
                else
                {
                    AmdFile amd = new AmdFile();
                    AmdChunk chunk = new AmdChunk() { Data = File.ReadAllBytes(GMOpath), Flags = 257, Tag = "MODEL_DATA" };
                    amd.Chunks.Add(chunk);
                    amd.Save(AMDpath);
                }
                CurrentFileProgressBar.Value++;
                AllFIlesProgressBar.Value++;
            }
            LabelProgressBar.Text = "Finished converting";
            MessageBox.Show("Your files have been modified");
            
        }


        //stolen code from shirnefox's converter
        private void ExtractTextures(string path)
        {
            //Get texture names
            List<string> textureNames = new List<string>();
            byte[] fileBytes = File.ReadAllBytes(path);
            int offset = 0;

            for (int i = 0; i < fileBytes.Count(); i++)
            {
                try
                {
                    offset = FindSequence(File.ReadAllBytes(path), i, Encoding.ASCII.GetBytes(".tm2"));
                    i = offset;
                    using (EndianBinaryReader reader = new EndianBinaryReader(File.OpenRead(path), Endianness.BigEndian))
                    {
                        int dim = 40;
                        if (i <= dim) dim = 20;
                        reader.BaseStream.Position = i - dim;
                        byte[] nameBytes = reader.ReadBytes(dim + 4);
                        string name = Encoding.UTF8.GetString(nameBytes);
                        textureNames.Add(name.Substring(name.LastIndexOf('\0') + 1));
                    }
                }
                catch
                {
                    break;
                }
            }

            if (textureNames.Count > 0)
            {
                if (File.Exists($"{Path.GetDirectoryName(path)}\\textures\\{textureNames[0]}"))
                    return;

                //Get textures and write files
                offset = 0;
                for (int i = 0; i < textureNames.Count(); i++)
                {
                    try
                    {
                        offset = FindSequence(File.ReadAllBytes(path), offset, Encoding.ASCII.GetBytes("TIM2"));
                        if (!Directory.Exists($"{Path.GetDirectoryName(path)}\\textures"))
                            Directory.CreateDirectory($"{Path.GetDirectoryName(path)}\\textures");
                        if (File.Exists($"{Path.GetDirectoryName(path)}\\textures\\{textureNames[i]}"))
                            File.Delete($"{Path.GetDirectoryName(path)}\\textures\\{textureNames[i]}");
                        string newFile = $"{Path.GetDirectoryName(path)}\\textures\\{textureNames[i]}";
                        using (EndianBinaryReader reader = new EndianBinaryReader(File.OpenRead(path), Endianness.BigEndian))
                        {
                            reader.BaseStream.Position = offset;
                            reader.ReadBytes(16);
                            int size = reader.ReadInt32() + 16;

                            reader.BaseStream.Position = offset;
                            File.WriteAllBytes(newFile, reader.ReadBytes(size));
                            offset++;
                        }
                    }
                    catch
                    {
                        break;
                    }
                }
            }
        }
        //shrinefox's code again
        private static int FindSequence(byte[] array, int start, byte[] sequence)
        {
            int end = array.Length - sequence.Length; // past here no match is possible
            byte firstByte = sequence[0]; // cached to tell compiler there's no aliasing

            while (start < end)
            {
                // scan for first byte only. compiler-friendly.
                if (array[start] == firstByte)
                {
                    // scan for rest of sequence
                    for (int offset = 1; offset < sequence.Length; ++offset)
                    {
                        if (array[start + offset] != sequence[offset])
                        {
                            break; // mismatch? continue scanning with next byte
                        }
                        else if (offset == sequence.Length - 1)
                        {
                            return start; // all bytes matched!
                        }
                    }
                }
                ++start;
            }

            // end of array reached without match
            return -1;
        }
        private void darkLabel4_Click(object sender, EventArgs e)
        {

        }

        private void AllFIlesProgressBar_Click(object sender, EventArgs e)
        {
        }

        private void darkLabel5_Click(object sender, EventArgs e)
        {

        }

        private void darkButton1_Click_1(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.Filters.Add(new CommonFileDialogFilter("Mds file", "*.mds"));
            dialog.Title = "Select a mds file with things you want to add..";
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                newmdstextbox.Text = dialog.FileName;

            }
        }

        private void darkButton2_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            dialog.Title = "Select a folder with your amd files...";
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                pathTextBox.Text = dialog.FileName;

            }
        }

        private void newmdstextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Tab))
            {
                e.Handled = e.SuppressKeyPress = true;
            }
        }

        private void pathTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Tab))
            {
                e.Handled = e.SuppressKeyPress = true;
            }
        }
    }
}
