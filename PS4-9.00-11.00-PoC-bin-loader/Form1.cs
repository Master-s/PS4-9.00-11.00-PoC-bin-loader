using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PS4_9._00_11._00_PoC_bin_loader
{
    public partial class Form1 : Form
    {
        private string path;



        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "python files (*.py)|*.py;|All files (*.*)|*.*";
                openFileDialog1.ShowDialog();
                path = openFileDialog1.SafeFileName;
                label3.Text = path;
                label3.Text = Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
            }
            catch
            {
                MessageBox.Show("", "Error");
            }
            if (label3.Text == "poc")
            {
                try
                {
                    BinaryReader reader = new BinaryReader(new FileStream(@"poc.py", FileMode.Open));
                    button1.Enabled = true;
                    //Set the position of the reader
                    reader.BaseStream.Position = 0x83;
                    //Read the offset
                    byte[] array = reader.ReadBytes(3);
                    textBox1.Text = ASCIIEncoding.ASCII.GetString(array);
                    reader.BaseStream.Position = 0x87;
                    //Read the offset
                    byte[] array0 = reader.ReadBytes(3);
                    textBox2.Text = ASCIIEncoding.ASCII.GetString(array0);
                    reader.BaseStream.Position = 0x8B;
                    //Read the offset
                    byte[] array01 = reader.ReadBytes(3);
                    textBox3.Text = ASCIIEncoding.ASCII.GetString(array01);

                    reader.BaseStream.Position = 0x8F;
                    byte[] array02 = reader.ReadBytes(3);
                    textBox4.Text = ASCIIEncoding.ASCII.GetString(array02);

                    reader.BaseStream.Position = 0x93;
                    byte[] array03 = reader.ReadBytes(3);
                    textBox5.Text = ASCIIEncoding.ASCII.GetString(array03);

                    reader.BaseStream.Position = 0x97;
                    byte[] array04 = reader.ReadBytes(3);
                    textBox6.Text = ASCIIEncoding.ASCII.GetString(array04);

                    reader.BaseStream.Position = 0xCE;
                    byte[] array07 = reader.ReadBytes(3);
                    textBox7.Text = ASCIIEncoding.ASCII.GetString(array07);

                    reader.BaseStream.Position = 0xD2;
                    byte[] array08 = reader.ReadBytes(3);
                    textBox8.Text = ASCIIEncoding.ASCII.GetString(array08);

                    reader.BaseStream.Position = 0xD6;
                    byte[] array09 = reader.ReadBytes(3);
                    textBox9.Text = ASCIIEncoding.ASCII.GetString(array09);

                    reader.BaseStream.Position = 0xDA;
                    byte[] array10 = reader.ReadBytes(3);
                    textBox10.Text = ASCIIEncoding.ASCII.GetString(array10);

                    reader.BaseStream.Position = 0xDE;
                    byte[] array11 = reader.ReadBytes(3);
                    textBox11.Text = ASCIIEncoding.ASCII.GetString(array11);

                    reader.BaseStream.Position = 0xE2;//pkg
                    byte[] array12 = reader.ReadBytes(3);
                    textBox12.Text = ASCIIEncoding.ASCII.GetString(array12);

                    reader.Close();
                    groupBox1.Enabled = true;

                }
                catch
                {
                    MessageBox.Show("Sorry the application seems to have encountered a problem", "Error");
                }
            }
            if (label3.Text == "Mypoc")
            {
                try
                {
                    BinaryReader reader = new BinaryReader(new FileStream(@"Mypoc.py", FileMode.Open));
                    button1.Enabled = true;
                    //Set the position of the reader
                    reader.BaseStream.Position = 0x5F;
                    //Read the offset
                    byte[] array = reader.ReadBytes(3);
                    textBox1.Text = ASCIIEncoding.ASCII.GetString(array);
                    reader.BaseStream.Position = 0x63;
                    //Read the offset
                    byte[] array0 = reader.ReadBytes(3);
                    textBox2.Text = ASCIIEncoding.ASCII.GetString(array0);
                    reader.BaseStream.Position = 0x67;
                    //Read the offset
                    byte[] array01 = reader.ReadBytes(3);
                    textBox3.Text = ASCIIEncoding.ASCII.GetString(array01);

                    reader.BaseStream.Position = 0x6B;
                    byte[] array02 = reader.ReadBytes(3);
                    textBox4.Text = ASCIIEncoding.ASCII.GetString(array02);

                    reader.BaseStream.Position = 0x6F;
                    byte[] array03 = reader.ReadBytes(3);
                    textBox5.Text = ASCIIEncoding.ASCII.GetString(array03);

                    reader.BaseStream.Position = 0x73;
                    byte[] array04 = reader.ReadBytes(3);
                    textBox6.Text = ASCIIEncoding.ASCII.GetString(array04);

                    reader.BaseStream.Position = 0x89;
                    byte[] array07 = reader.ReadBytes(3);
                    textBox7.Text = ASCIIEncoding.ASCII.GetString(array07);

                    reader.BaseStream.Position = 0x8D;
                    byte[] array08 = reader.ReadBytes(3);
                    textBox8.Text = ASCIIEncoding.ASCII.GetString(array08);

                    reader.BaseStream.Position = 0x91;
                    byte[] array09 = reader.ReadBytes(3);
                    textBox9.Text = ASCIIEncoding.ASCII.GetString(array09);

                    reader.BaseStream.Position = 0x95;
                    byte[] array10 = reader.ReadBytes(3);
                    textBox10.Text = ASCIIEncoding.ASCII.GetString(array10);

                    reader.BaseStream.Position = 0x99;
                    byte[] array11 = reader.ReadBytes(3);
                    textBox11.Text = ASCIIEncoding.ASCII.GetString(array11);

                    reader.BaseStream.Position = 0x9D;//pkg
                    byte[] array12 = reader.ReadBytes(3);
                    textBox12.Text = ASCIIEncoding.ASCII.GetString(array12);

                    reader.Close();
                    groupBox1.Enabled = true;

                }
                catch
                {
                    MessageBox.Show("Sorry the application seems to have encountered a problem", "Error");
                }
            }

        }

        private void ThreadProc()
        {
            throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter sw = new StreamWriter(Application.StartupPath + "\\" + "Mypoc.py");
                sw.WriteLine(label4.Text + "\n" + label5.Text + "\n" + label6.Text + "\n\n"
                    + label7.Text + textBox1.Text + "\\" + textBox2.Text + "\\" + textBox3.Text + "\\"
                    + textBox4.Text + "\\" + textBox5.Text + "\\" + textBox6.Text + label8.Text + "\n"
                    + label9.Text + textBox7.Text + "\\" + textBox8.Text + "\\" + textBox9.Text + "\\"
                    + textBox10.Text + "\\" + textBox11.Text + "\\" + textBox12.Text + label10.Text + "\n"
                    + label11.Text + "\n" + "\n"
                    + label12.Text + "\n" + "\n"
                    + label13.Text + "\n"
                    + label14.Text + "\n" + label15.Text + "\n" + "\n"
                    + label16.Text + "\n" + label17.Text + "\n" + "\n"
                    + label18.Text + "\n" + label19.Text + "\n" + "\n"
                    + label20.Text + "\n" + "\n"
                    + label21.Text + "\n" + label22.Text + "\n" + "\n"
                    + label23.Text + "\n" + label24.Text + "\n" + "\n"
                    + label25.Text + "\n" + "\n"
                    + label26.Text + "\n" + label27.Text + "\n" + "\n"
                    + label28.Text + "\n" + label29.Text + "\n" + "\n"
                    + label30.Text + "\n" + "\n" 
                    + label31.Text + "\n" + label32.Text + "\n" + label33.Text + "\n"
                    + label34.Text + "\n" + label35.Text + "\n" + "\n"
                    + label36.Text + "\n" + label37.Text + "\n" 
                    + label38.Text + "\n" + label39.Text + "\n" + label40.Text + "\n" +label41.Text +"\n"
                    + label42.Text + "\n" + label43.Text + "\n" + "\n" 
                    + label44.Text + "\n" + label45.Text);
                sw.Close();
            }
            catch
            {
                MessageBox.Show("Error");
            }
            try
            {
                StreamWriter sw = new StreamWriter(Application.StartupPath + "\\" + "PoC.bat");
                sw.WriteLine(" python Mypoc.py\npause");
                sw.Close();
                if (File.Exists("PoC.bat"))
                {
                    labelBuild.Text = "Run...";
                    Thread thread = new Thread(new ThreadStart(ThreadProc));
                    new Process
                    {
                        StartInfo =
                            {
                                WindowStyle = ProcessWindowStyle.Hidden,
                                FileName = "PoC.bat"
                            }
                    }.Start();
                    labelBuild.Text = "complete";
                    MessageBox.Show(" successfully created!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }
                else
                {

                    MessageBox.Show("PoC", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }

            }
            catch
            {
                MessageBox.Show("Error");
            }
            MessageBox.Show("Thanks  ...", "Code!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            try
            {
                System.Diagnostics.Process.Start(@"PoC.bat");
            }
            catch
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog opendialog = new OpenFileDialog();
            opendialog.CheckFileExists = true;
            opendialog.Multiselect = false;
            opendialog.Filter = "PS4 BIN File (*.bin) | *.bin";
            if (opendialog.ShowDialog() == DialogResult.OK)
            {
                string FilePath = opendialog.FileName;
                textBox13.Text = FilePath;
                label47.Text = opendialog.SafeFileName;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_NetworkAdapter Where AdapterType='Ethernet 802.3'");

            foreach (ManagementObject mo in mos.Get())

            {

                comboBox1.Items.Add(mo["Name"].ToString());

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox14.Text = String.Empty;
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            if (nics == null || nics.Length < 1)
            {
                textBox14.Text = "No network interfaces found.";
                return;
            }

            foreach (NetworkInterface adapter in nics)
            {
                PhysicalAddress address = adapter.GetPhysicalAddress();
                byte[] bytes = address.GetAddressBytes();

                for (int i = 0; i < bytes.Length; i++)
                {
                    textBox14.Text += bytes[i].ToString("X2"); // display in HEX

                    // Insert a hyphen after each byte, unless we are at the end of the 
                    if (i != bytes.Length - 1)
                    {
                        textBox14.Text += "-";
                    }
                }
                textBox14.Text += Environment.NewLine;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process.Start(@"Rundll32.exe"," shell32.dll,Control_RunDLL ncpa.cpl");
        }

        private void button6_Click(object sender, EventArgs e)
        {
                if (comboBox1.Text == "Select Ethernet Controller" | string.IsNullOrEmpty(comboBox1.Text))
                {
                    MessageBox.Show("Select Ethernet Controller");
                }
                else
                {
                    ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_NetworkAdapter where Name='" + comboBox1.SelectedItem.ToString() + "'");

                    ManagementObjectCollection moc = mos.Get();

                    if (moc.Count > 0)

                    {

                        foreach (ManagementObject mo in moc)

                        {

                            textBox14.Text = (string)mo["MACAddress"];

                        }

                    }
                button7.Visible = true;
                }



        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter nw = new StreamWriter(Application.StartupPath + "\\" + "Mac" + ".txt");
                nw.WriteLine(textBox14.Text);
                nw.Close();


                try
                {
                        BinaryReader reader = new BinaryReader(new FileStream(@"Mac.txt", FileMode.Open));
                        //Set the position of the reader
                        reader.BaseStream.Position = 0x0;
                        //Read the offset
                        byte[] array = reader.ReadBytes(2);
                        textBox1.Text = ASCIIEncoding.ASCII.GetString(array);

                        reader.BaseStream.Position = 0x3;
                        byte[] array0 = reader.ReadBytes(2);
                        textBox2.Text = ASCIIEncoding.ASCII.GetString(array0);

                        reader.BaseStream.Position = 0x6;
                        byte[] array01 = reader.ReadBytes(2);
                        textBox3.Text = ASCIIEncoding.ASCII.GetString(array01);

                        reader.BaseStream.Position = 0x9;
                        byte[] array02 = reader.ReadBytes(2);
                        textBox4.Text = ASCIIEncoding.ASCII.GetString(array02);

                        reader.BaseStream.Position = 0xC;
                        byte[] array03 = reader.ReadBytes(2);
                        textBox5.Text = ASCIIEncoding.ASCII.GetString(array03);

                        reader.BaseStream.Position = 0xF;
                        byte[] array04 = reader.ReadBytes(2);
                        textBox6.Text = ASCIIEncoding.ASCII.GetString(array04);

                        reader.Close();



                }
                catch
                {
                  MessageBox.Show("Sorry the application seems to have encountered a problem", "Error");
                }


            }
            catch
            {
                MessageBox.Show("Error");
            }

            try
            {
                StreamWriter snw = new StreamWriter(Application.StartupPath + "\\" + "Mac" + ".txt");
                snw.WriteLine("x" + textBox1.Text + "x" + textBox2.Text + "x" + textBox3.Text + "x" + textBox4.Text + "x" + textBox5.Text + "x" + textBox6.Text);
                snw.Close();

                BinaryReader reader = new BinaryReader(new FileStream(@"Mac.txt", FileMode.Open));
                //Set the position of the reader
                reader.BaseStream.Position = 0x0;
                //Read the offset
                byte[] array = reader.ReadBytes(3);
                textBox1.Text = ASCIIEncoding.ASCII.GetString(array);

                reader.BaseStream.Position = 0x3;
                byte[] array0 = reader.ReadBytes(3);
                textBox2.Text = ASCIIEncoding.ASCII.GetString(array0);

                reader.BaseStream.Position = 0x6;
                byte[] array01 = reader.ReadBytes(3);
                textBox3.Text = ASCIIEncoding.ASCII.GetString(array01);

                reader.BaseStream.Position = 0x9;
                byte[] array02 = reader.ReadBytes(3);
                textBox4.Text = ASCIIEncoding.ASCII.GetString(array02);

                reader.BaseStream.Position = 0xC;
                byte[] array03 = reader.ReadBytes(3);
                textBox5.Text = ASCIIEncoding.ASCII.GetString(array03);

                reader.BaseStream.Position = 0xF;
                byte[] array04 = reader.ReadBytes(3);
                textBox6.Text = ASCIIEncoding.ASCII.GetString(array04);

                reader.Close();
            }
            catch
            {
                MessageBox.Show("Error");
            }


        }
    }
}


