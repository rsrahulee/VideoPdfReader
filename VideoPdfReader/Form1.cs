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

       List<String> video_items = new List<String>();
       List<String> pdf_items = new List<String>();

        private Boolean is_video_click = false;
        private Boolean is_pdf_click = false;

        public Form1()
        {
            InitializeComponent();

            //InitializeComboBox();

            InitializeListBox();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Form1_Load------------");

            comboBoxVideo.Hide();
            comboBoxPdf.Hide();
            btnRefreshVideo.Hide();
            btnRefreshPdf.Hide();

            //comboBoxVideo.Text = "select video to play";
            //comboBoxPdf.Text = "select pdf file to read";

            //loadPdfCombo();

            //loadVideoCombo();
        }

        private void loadPdfCombo()
        {
            string[] filePaths = null;
           // listBox1.Items.Clear();
            pdf_items.Clear();
           //comboBoxPdf.Items.Clear();
            try
            {
                filePaths = Directory.GetFiles(@"D:\Rahul\", "*.pdf", SearchOption.AllDirectories);
                if (filePaths.Length > 0)
                {
                    //comboBoxPdf.MaxDropDownItems = filePaths.Length;

                    foreach (string name in filePaths)
                    {
                        pdf_items.Add(name);
                        //comboBoxPdf.Items.Add(name);
                    }
                    listBox1.DataSource = pdf_items;
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
            //comboBoxVideo.Items.Clear();

            //listBox1.Items.Clear();
            video_items.Clear();

            try
            {
                string supportedExtensions = "*.mpg,*.avi,*.mp4";
                foreach (string videoFile in Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories).Where(s => supportedExtensions.Contains(Path.GetExtension(s).ToLower())))
                {
                    video_items.Add(videoFile);
                    //comboBoxVideo.Items.Add(videoFile);
                }
                listBox1.DataSource = video_items;
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
            MessageBox.Show("Sorry! Error in loading pdf");
        }

        private void btnRefreshPdf_Click(object sender, EventArgs e)
        {            
            //if (comboBoxPdf!=null)
            //{
            //    comboBoxPdf.Items.Clear();               
            //    comboBoxPdf.Text = "select pdf file to read";   
            //}
            loadPdfCombo();
        }

        private void btnRefreshVideo_Click(object sender, EventArgs e)
        {
            //if (comboBoxVideo != null)
            //{
            //    comboBoxVideo.Items.Clear();
            //    comboBoxVideo.Text = "select video to play";
            //}
            loadVideoCombo();
        }

        private void InitializeComboBox()
        {
           comboBoxPdf.KeyDown +=
              new System.Windows.Forms.KeyEventHandler(comboBoxPdf_keyPress);

           comboBoxVideo.KeyDown +=
            new System.Windows.Forms.KeyEventHandler(comboBoxVideo_keyPress);
        }

       private void InitializeListBox(){
           listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(listBox1_DoubleClick);
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

        private void listBox1_DoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Console.WriteLine("listBox1_DoubleClick---------------");
            if (is_pdf_click == true)
            {
                if (pdf_items.Count > 0)
                {
                    String file_name = pdf_items.ElementAt(listBox1.SelectedIndex);

                    try
                    {
                        if (System.IO.File.Exists(file_name) == true)
                        {
                            if (axAcroPDFReader != null)
                            {
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
                else
                {
                    loadPdfCombo();

                    String file_name = pdf_items.ElementAt(listBox1.SelectedIndex);

                    try
                    {
                        if (System.IO.File.Exists(file_name) == true)
                        {
                            if (axAcroPDFReader != null)
                            {
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
            }
            else if(is_video_click == true)
            {
                if (video_items.Count > 0)
                {
                    String file_name = video_items.ElementAt(listBox1.SelectedIndex);
                    try
                    {
                        if (System.IO.File.Exists(file_name) == true)
                        {
                            if (axWindowsMediaPlayer1 != null)
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
                else
                {
                    loadVideoCombo();

                    String file_name = video_items.ElementAt(listBox1.SelectedIndex);
                    try
                    {
                        if (System.IO.File.Exists(file_name) == true)
                        {
                            if (axWindowsMediaPlayer1 != null)
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
            }
        }

        private void btnShowVideo_Click_1(object sender, EventArgs e)
        {
            is_pdf_click = false;
            is_video_click = true;

            //comboBoxVideo.Show();
            //comboBoxPdf.Hide();

            btnRefreshVideo.Show();
            btnRefreshPdf.Hide();

            this.Controls.Remove(axAcroPDFReader);
            this.Controls.Add(axWindowsMediaPlayer1);

            loadVideoCombo();
        }

        private void btnShowPdf_Click(object sender, EventArgs e)
        {
            is_pdf_click = true;
            is_video_click = false;

            if (axWindowsMediaPlayer1!=null)
            {
                axWindowsMediaPlayer1.close();
            }

            //comboBoxVideo.Hide();
            //comboBoxPdf.Show();

            btnRefreshVideo.Hide();
            btnRefreshPdf.Show();

            this.Controls.Remove(axWindowsMediaPlayer1);
            this.Controls.Add(axAcroPDFReader);

            loadPdfCombo();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("listBox1 Hi!--------------");           
        }
    }
}
