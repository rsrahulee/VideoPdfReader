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
       Video video;

        public Form1()
        {
            InitializeComponent();

            btnPlay.Enabled = false;
            btnPause.Enabled = false;
            btnStop.Enabled = false;
            btnLoad.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

           btnLoad.Enabled = false;

           string[] filePaths = null;           

           filePaths = Directory.GetFiles(@"D:\Rahul\", "*.txt", SearchOption.AllDirectories);

            comboBoxPdf.MaxDropDownItems = filePaths.Length;

            foreach (string name in filePaths)
            {
                comboBoxPdf.Items.Add(name);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            btnLoad.Enabled = true;

            string[] filePaths = null;

            filePaths = Directory.GetFiles(@"D:\Rahul\", "*.mpg", SearchOption.AllDirectories);

            foreach (string name in filePaths)
            {
                comboBoxVideo.Items.Add(name);
            }

            //String file_name2 = "D:\\Rahul\\Land 1.mpg";

            //try
            //{
            //    if (System.IO.File.Exists(file_name2) == true)
            //    {
            //        System.Diagnostics.Process.Start(file_name2);
            //    }
            //    else
            //    {
            //        MessageBox.Show("Sorry! file not exsist");
            //    }
            //}
            //catch (FileNotFoundException notFountException)
            //{
            //    MessageBox.Show("Sorry! file not exsist " + notFountException);
            //}catch(Exception exception){
            //    MessageBox.Show("Sorry! file not exsist "+exception);
            //}
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {

            openFileDialog1.Filter = "(mp3,wav,mp4,mov,wmv,mpg)|*.mp3;*.wav;*.mp4;*.mov;*.wmv;*.mpg|all files|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            axWindowsMediaPlayer1.URL = openFileDialog1.FileName;
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            // try
            //{
            
            //openFileDialog.ShowDialog();

            //openFileDialog1.InitialDirectory = Application.StartupPath;
            //openFileDialog1.Title = "Select video file..";

            //openFileDialog.Filter = "Media Files|*.mpg;*.avi;*.wma;*.mov;*.wav;";

            //video = new Video(openFileDialog.FileName,true);

            //video.Owner = videoWindow;

            //// stop the video
            //video.Stop();

            //int width = videoWindow.Width;
            //int height = videoWindow.Height;

            //// resize the video to the size original size of the panel
            //videoWindow.Size = new Size(width, height);

            //}
            // catch (Exception err)
            // {
            //     Console.WriteLine("error------------" + err.Message);
            // }

            //try
            //{

            //    if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //    {
            //        // store the original size of the panel
            //        int width = videoWindow.Width;
            //        int height = videoWindow.Height;

            //        if (video != null)
            //        {
            //            video.Dispose();
            //        }

            //        // load the selected video file
            //        video = new Video(openFileDialog1.FileName);

            //        // set the panel as the video object’s owner
            //        video.Owner = videoWindow;

            //        // stop the video
            //        video.Stop();

            //        // resize the video to the size original size of the panel
            //        videoWindow.Size = new Size(width, height);
            //    }
            //}catch(Exception err){
            //    Console.WriteLine("error------------"+err.Message);
            //}
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (video.State != StateFlags.Running)
            {
                video.Play();
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (video.State == StateFlags.Running)
            {
                video.Pause();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (video.State != StateFlags.Stopped)
            {
                video.Stop();
            }
        }

        private void comboBoxPdf_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("combo selected------------");

           

            String file_name = comboBoxPdf.Text;

            try
            {
                if (System.IO.File.Exists(file_name) == true)
                {
                    string contents = File.ReadAllText(file_name);
                    //MessageBox.Show("" + contents);

                    if (txtDesc.Text!=null)
                    {
                        txtDesc.Text = "";
                        txtDesc.Text = contents;
                    }
                   

                    //foreach (string file in filePaths)
                    //{

                    //    string contents = File.ReadAllText(file);
                    //    Console.WriteLine("--------text is------" + contents);
                    //    //MessageBox.Show("this is the text\n" + contents);
                    //    System.Diagnostics.Process.Start(file_name);
                    //}
                }

                else
                {
                    MessageBox.Show("Sorry! file not exsist");
                }

            }
            catch (FileNotFoundException notFountException)
            {
                MessageBox.Show("Sorry! file not exsist " + notFountException);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Sorry! file not exsist " + exception);
            }
        }

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {

        }       
    }
}
