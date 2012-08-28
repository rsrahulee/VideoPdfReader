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
using System.Resources;
using System.Security.AccessControl;

namespace VideoPdfReader
{
    
    public partial class Form1 : Form
    {

       List<String> video_items = new List<String>();
       List<String> pdf_items = new List<String>();

        private Boolean is_video_click = false;
        private Boolean is_pdf_click = false;

        private string mydirectory;
        private string myDocspath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public Form1()
        {
            InitializeComponent();

            InitializeListBox();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Form1_Load------------");

            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.Text = "VideoPdfReader";
            this.MaximizeBox = false;

            btnRefreshVideo.Hide();
            btnRefreshPdf.Hide();

            fileInitialization();
            //lockFolder();
        }

        private void loadPdf()
        {
            string[] filePaths = null;          
            pdf_items.Clear();
         
            try
            {
                filePaths = Directory.GetFiles(mydirectory, "*.pdf", SearchOption.AllDirectories);
                if (filePaths.Length > 0)
                {
                    foreach (string name in filePaths)
                    {
                        String preName = name.Substring(37);
                        pdf_items.Add(preName);
                    }
                    listBox1.DataSource = pdf_items;
                }
            }
            catch (FileNotFoundException exception)
            {
                MessageBox.Show("Sorry! no supported pdf files available");
            }
            catch (UnauthorizedAccessException exception)
            {
                MessageBox.Show("Sorry! Access Denied\nYou dont have access to the file specified.");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Sorry! Error in loading pdf files");
            }
        }

        private void loadVideo()
        {
            video_items.Clear();

            try
            {
                string supportedExtensions = "*.mpg,*.avi,*.mp4";
                foreach (string videoFile in Directory.GetFiles(mydirectory, "*.*", SearchOption.AllDirectories).Where(s => supportedExtensions.Contains(Path.GetExtension(s).ToLower())))
                {
                    String preName = videoFile.Substring(37);
                    video_items.Add(preName);
                }
                listBox1.DataSource = video_items;
            }
            catch (FileNotFoundException exception)
            {
                MessageBox.Show("Sorry! no supported Video files available");
            }
            catch (UnauthorizedAccessException exception)
            {
                MessageBox.Show("Sorry! Access Denied\nYou dont have access to the file specified.");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Sorry! Error in loading video files");
            }
        } 

        private void axAcroPDFReader_OnError(object sender, EventArgs e)
        {
            MessageBox.Show("Sorry! Error in loading pdf");
        }

        private void btnRefreshPdf_Click(object sender, EventArgs e)
        {
            loadPdf();
        }

        private void btnRefreshVideo_Click(object sender, EventArgs e)
        {
            loadVideo();           
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
                    String absPAth = pdf_items.ElementAt(listBox1.SelectedIndex);
                    String file_name = mydirectory + absPAth;

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
                        MessageBox.Show("Sorry! file not exsist");
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Sorry! Error in loading files");
                    }
                }
                else
                {
                    loadPdf();

                    String absPAth = pdf_items.ElementAt(listBox1.SelectedIndex);
                    String file_name = mydirectory + absPAth;

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
                        MessageBox.Show("Sorry! file not exsist");
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Sorry! Error in loading files");
                    }
                }
            }
            else if(is_video_click == true)
            {
                if (video_items.Count > 0)
                {
                    String absPAth = video_items.ElementAt(listBox1.SelectedIndex);
                    String file_name = mydirectory + absPAth;
                    try
                    {
                        if (System.IO.File.Exists(file_name) == true)
                        {
                            if (axWindowsMediaPlayer1 != null)
                            {

                            }
                            byte[] localString = VideoPdfReader.Properties.Resources.Takeoff;
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
                    loadVideo();

                    String absPAth = video_items.ElementAt(listBox1.SelectedIndex);
                    String file_name = mydirectory + absPAth;
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

            loadVideo();
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

            loadPdf();
        }

        private void lockFolder()
        {
            try
             {
              string adminUserName = Environment.UserName;
              DirectorySecurity ds = Directory.GetAccessControl(mydirectory);
              FileSystemAccessRule fsa = new FileSystemAccessRule(adminUserName, FileSystemRights.FullControl, AccessControlType.Deny);

              ds.AddAccessRule(fsa);
              Directory.SetAccessControl(mydirectory, ds);
             }
             catch (Exception ex)
             {
                MessageBox.Show(ex.Message);
             } 
        }

        private void unLockFolder()
        {
            try
            {
                string adminUserName = Environment.UserName;
                DirectorySecurity ds = Directory.GetAccessControl(mydirectory);
                FileSystemAccessRule fsa = new FileSystemAccessRule(adminUserName, FileSystemRights.FullControl, AccessControlType.Deny);
              
                ds.RemoveAccessRule(fsa);
                Directory.SetAccessControl(mydirectory, ds);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fileInitialization()
        {            
           mydirectory = myDocspath + "\\" + "WeboniseLab\\";

           if (!Directory.Exists(mydirectory))
           {
               Directory.CreateDirectory(mydirectory);
           }

           byte[] byteArrayVideo = new byte[VideoPdfReader.Properties.Resources.Takeoff.Length];
           VideoPdfReader.Properties.Resources.Takeoff.CopyTo(byteArrayVideo, 0);
           File.WriteAllBytes(mydirectory + "MyVideo.mpg", byteArrayVideo);

           byte[] byteArrayPdf = new byte[VideoPdfReader.Properties.Resources.HuMongo.Length];
           VideoPdfReader.Properties.Resources.HuMongo.CopyTo(byteArrayPdf, 0);
           File.WriteAllBytes(mydirectory + "MyBook.pdf", byteArrayPdf);    
        }
    }
}
