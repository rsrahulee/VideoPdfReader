using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.DirectX;
using Microsoft.DirectX.AudioVideoPlayback;

namespace VideoPdfReader
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            InitializeComboBox();
        }

        private void loadPdfCombo()
        {
            string[] filePaths = null;
            comboBoxPdf.Items.Clear();
            try
            {
                filePaths = Directory.GetFiles(@"D:\Rahul\", "*.pdf", SearchOption.AllDirectories);
                if (filePaths.Length > 0)
                {
                    comboBoxPdf.MaxDropDownItems = filePaths.Length;

                    foreach (string name in filePaths)
                    {
                        comboBoxPdf.Items.Add(name);
                    }
                }
            }
            catch (FileNotFoundException exception)
            {
                MessageBox.Show("Sorry! no supported pdf files available\n" + exception);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Sorry! Error in loading pdf files\n" + exception);
            }
        }

        private void loadVideoCombo()
        {
            string directory = "D:\\Rahul";
            comboBoxVideo.Items.Clear();
            try
            {
                string supportedExtensions = "*.mpg,*.avi,*.mp4";
                foreach (string videoFile in Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories).Where(s => supportedExtensions.Contains(Path.GetExtension(s).ToLower())))
                {                    
                    comboBoxVideo.Items.Add(videoFile);
                }
            }
            catch (FileNotFoundException exception)
            {
                MessageBox.Show("Sorry! no supported Video files available\n" + exception);
            }            
            catch (Exception exception)
            {
                MessageBox.Show("Sorry! Error in loading video files\n" + exception);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Form1_Load------------");

            comboBoxVideo.Hide();
            comboBoxPdf.Hide();
            btnRefreshVideo.Hide();
            btnRefreshPdf.Hide();

            //this.Controls.Remove(axAcroPDFReader);
            //this.Controls.Remove(axWindowsMediaPlayer1);

            comboBoxVideo.Text = "select video to play";
            comboBoxPdf.Text = "select pdf file to read";           

            loadPdfCombo();

            loadVideoCombo();
        }

        private void comboBoxPdf_SelectedIndexChanged(object sender, EventArgs e)
        {
            String file_name = comboBoxPdf.Text;

            try
            {
                if (System.IO.File.Exists(file_name) == true)
                {
                   if(axAcroPDFReader!=null){
                      // Dispose();
                   }
                   axAcroPDFReader.LoadFile(file_name);                   
                }
                else
                {
                    MessageBox.Show("Sorry! file not exsist");
                }
            }
            catch (FileNotFoundException notFountException)
            {
                MessageBox.Show("Sorry! file not exsist\n" + notFountException);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Sorry! Error in loading files\n" + exception);
            }
        }

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxVideo_SelectedIndexChanged(object sender, EventArgs e)
        {
            String file_name = comboBoxVideo.Text;
            try
            {
                if (System.IO.File.Exists(file_name) == true)
                {
                    if (axWindowsMediaPlayer1!=null)
                    {
                       
                    }
                    axWindowsMediaPlayer1.URL = file_name;
                }
                else
                {
                    MessageBox.Show("Sorry! file not exsist");
                }
            }
            catch (FileNotFoundException notFountException)
            {
                MessageBox.Show("Sorry! file not exsist\n" + notFountException);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Sorry! Error in loading files\n" + exception);
            }
        }

        private void axAcroPDFReader_OnError(object sender, EventArgs e)
        {
            MessageBox.Show("Sorry! Error in reading pdf");
        }

        private void btnRefreshPdf_Click(object sender, EventArgs e)
        {            
            if (comboBoxPdf!=null)
            {
                comboBoxPdf.Items.Clear();               
                comboBoxPdf.Text = "select pdf file to read";   
            }
            loadPdfCombo();
        }

        private void btnRefreshVideo_Click(object sender, EventArgs e)
        {
            if (comboBoxVideo != null)
            {
                comboBoxVideo.Items.Clear();
                comboBoxVideo.Text = "select video to play";
            }
            loadVideoCombo();
        }

        private void InitializeComboBox()
        {
           comboBoxPdf.KeyDown +=
              new System.Windows.Forms.KeyEventHandler(comboBoxPdf_keyPress);

           comboBoxVideo.KeyDown +=
            new System.Windows.Forms.KeyEventHandler(comboBoxVideo_keyPress);
        }

        private void comboBoxPdf_keyPress(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            e.SuppressKeyPress = true;

            MessageBox.Show("Cannot edit the field",
            "Information", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void comboBoxVideo_keyPress(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            e.SuppressKeyPress = true;

            MessageBox.Show("Cannot edit the field",
            "Information", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBoxVideo.Show();
            comboBoxPdf.Hide();

            btnRefreshVideo.Show();
            btnRefreshPdf.Hide();

            this.Controls.Remove(axAcroPDFReader);
            this.Controls.Add(axWindowsMediaPlayer1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBoxVideo.Hide();
            comboBoxPdf.Show();

            btnRefreshVideo.Hide();
            btnRefreshPdf.Show();

            this.Controls.Remove(axWindowsMediaPlayer1);
            this.Controls.Add(axAcroPDFReader);
        }
    }
}
