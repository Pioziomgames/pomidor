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
            foreach (string file in files)
            {
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
                //convert gmo to mds
                Process cmd = new Process();
                cmd.StartInfo.FileName = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\Dependencies\\GMOTool\\GMOTool.exe";
                cmd.StartInfo.Arguments = $"\"{GMOpath}\"";
                cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                cmd.StartInfo.Arguments += " -E";
                cmd.Start();
                cmd.WaitForExit();
                //extract textures from gmo 
                ExtractTextures(GMOpath);
                //edit mds
                string MDSpath = Path.GetDirectoryName(file) + "\\" + Path.GetFileNameWithoutExtension(file) + ".mds";

                string FullFile = System.IO.File.ReadAllText(MDSpath);

                string NoMotion = FullFile.Remove(FullFile.IndexOf("\tMotion \""));
                string OnlyMotion = FullFile.Substring(FullFile.IndexOf("\tMotion \""));
                string EditedMDS = "";
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

                        if (line.StartsWith("\tBone \"") && counter > 10 && bonesAdded == false)
                        {
                            EditedMDS += NewBones + "\n";
                            bonesAdded = true;
                        }

                        if (line.StartsWith("\tPart \"") && partsAdded == false)
                        {
                            EditedMDS += NewParts + "\n";
                            partsAdded = true;
                        }

                        if (line.StartsWith("\tTexture \"") && texturesAdded == false)
                        {
                            EditedMDS += NewTextures + "\n";
                            texturesAdded = true;
                        }

                        if (line.StartsWith("\tMaterial \"") && materialsAdded == false)
                        {
                            EditedMDS += NewMaterials + "\n";
                            materialsAdded = true;
                        }

                        if (saveline)
                            EditedMDS += line + "\n" ;
                    }
                }

                //overwrite mds
                using (StreamWriter writetext = new StreamWriter(MDSpath))
                {
                    writetext.Write(EditedMDS + OnlyMotion);
                }
                //convert to gmo
                Process cmd3 = new Process();
                cmd3.StartInfo.FileName = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\Dependencies\\GMOTool\\GMOTool.exe";
                cmd3.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                cmd3.StartInfo.Arguments = $"\"{MDSpath}\"";
                cmd3.StartInfo.Arguments += " -PSV";
                cmd3.Start();
                cmd3.WaitForExit();
                System.Threading.Thread.Sleep(1000);

                // run tge's tool to fix gmo
                Process cmd4 = new Process();
                cmd4.StartInfo.FileName = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\Dependencies\\p4gpc-gmofix\\p4gpc-gmofix.exe";
                cmd4.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                cmd4.StartInfo.Arguments = $"\"{GMOpath}\"";
                cmd4.Start();
                cmd4.WaitForExit();


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
            }
            
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
    }
}
