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

        private string directory = "D:\\Rahul";

        public Form1()
        {
            InitializeComponent();

            InitializeListBox();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Form1_Load------------");

            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.Text = "VideoPdfReader";

            btnRefreshVideo.Hide();
            btnRefreshPdf.Hide();
        }

        private void loadPdfCombo()
        {
            string[] filePaths = null;          
            pdf_items.Clear();
         
            try
            {
                filePaths = Directory.GetFiles(directory, "*.pdf", SearchOption.AllDirectories);
                if (filePaths.Length > 0)
                {
                    foreach (string name in filePaths)
                    {
                        pdf_items.Add(name);
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
            video_items.Clear();

            try
            {
                string supportedExtensions = "*.mpg,*.avi,*.mp4";
                foreach (string videoFile in Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories).Where(s => supportedExtensions.Contains(Path.GetExtension(s).ToLower())))
                {
                    video_items.Add(videoFile);
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

        private void axAcroPDFReader_OnError(object sender, EventArgs e)
        {
            MessageBox.Show("Sorry! Error in loading pdf");
        }

        private void btnRefreshPdf_Click(object sender, EventArgs e)
        {
            loadPdfCombo();
        }

        private void btnRefreshVideo_Click(object sender, EventArgs e)
        {
            loadVideoCombo();
        }

       private void InitializeListBox(){
           listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(listBox1_DoubleClick);
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
                            axAcroPDFReader.setShowToolbar(false);
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
                            axAcroPDFReader.setShowToolbar(false);
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
            
            btnRefreshVideo.Hide();
            btnRefreshPdf.Show();

            this.Controls.Remove(axWindowsMediaPlayer1);
            this.Controls.Add(axAcroPDFReader);

            loadPdfCombo();
        }
    }
}
