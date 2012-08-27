namespace VideoPdfReader
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnRefreshPdf = new System.Windows.Forms.Button();
            this.btnRefreshVideo = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnShowVideo = new System.Windows.Forms.Button();
            this.btnShowPdf = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.axAcroPDFReader = new AxAcroPDFLib.AxAcroPDF();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDFReader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRefreshPdf
            // 
            this.btnRefreshPdf.Location = new System.Drawing.Point(26, 69);
            this.btnRefreshPdf.Name = "btnRefreshPdf";
            this.btnRefreshPdf.Size = new System.Drawing.Size(134, 23);
            this.btnRefreshPdf.TabIndex = 0;
            this.btnRefreshPdf.Text = "Refresh Pdf files";
            this.btnRefreshPdf.UseVisualStyleBackColor = true;
            this.btnRefreshPdf.Click += new System.EventHandler(this.btnRefreshPdf_Click);
            // 
            // btnRefreshVideo
            // 
            this.btnRefreshVideo.Location = new System.Drawing.Point(26, 69);
            this.btnRefreshVideo.Name = "btnRefreshVideo";
            this.btnRefreshVideo.Size = new System.Drawing.Size(134, 23);
            this.btnRefreshVideo.TabIndex = 1;
            this.btnRefreshVideo.Text = "Refresh Video Files";
            this.btnRefreshVideo.UseVisualStyleBackColor = true;
            this.btnRefreshVideo.Click += new System.EventHandler(this.btnRefreshVideo_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(560, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(82, 20);
            this.lblTitle.TabIndex = 13;
            this.lblTitle.Text = "Welcome";
            // 
            // btnShowVideo
            // 
            this.btnShowVideo.Location = new System.Drawing.Point(26, 40);
            this.btnShowVideo.Name = "btnShowVideo";
            this.btnShowVideo.Size = new System.Drawing.Size(75, 23);
            this.btnShowVideo.TabIndex = 14;
            this.btnShowVideo.Text = "Show Video";
            this.btnShowVideo.UseVisualStyleBackColor = true;
            this.btnShowVideo.Click += new System.EventHandler(this.btnShowVideo_Click_1);
            // 
            // btnShowPdf
            // 
            this.btnShowPdf.Location = new System.Drawing.Point(107, 40);
            this.btnShowPdf.Name = "btnShowPdf";
            this.btnShowPdf.Size = new System.Drawing.Size(75, 23);
            this.btnShowPdf.TabIndex = 15;
            this.btnShowPdf.Text = "show Pdf";
            this.btnShowPdf.UseVisualStyleBackColor = true;
            this.btnShowPdf.Click += new System.EventHandler(this.btnShowPdf_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(26, 107);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(274, 498);
            this.listBox1.TabIndex = 16;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // axAcroPDFReader
            // 
            this.axAcroPDFReader.Enabled = true;
            this.axAcroPDFReader.Location = new System.Drawing.Point(306, 107);
            this.axAcroPDFReader.Name = "axAcroPDFReader";
            this.axAcroPDFReader.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDFReader.OcxState")));
            this.axAcroPDFReader.Size = new System.Drawing.Size(842, 498);
            this.axAcroPDFReader.TabIndex = 12;
            this.axAcroPDFReader.OnError += new System.EventHandler(this.axAcroPDFReader_OnError);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(306, 107);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(830, 498);
            this.axWindowsMediaPlayer1.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 638);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnShowPdf);
            this.Controls.Add(this.btnShowVideo);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.axAcroPDFReader);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.btnRefreshVideo);
            this.Controls.Add(this.btnRefreshPdf);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDFReader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefreshPdf;
        private System.Windows.Forms.Button btnRefreshVideo;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private AxAcroPDFLib.AxAcroPDF axAcroPDFReader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnShowVideo;
        private System.Windows.Forms.Button btnShowPdf;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ImageList imageList1;
    }
}

