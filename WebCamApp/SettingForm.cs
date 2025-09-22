using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FolderBrowserEx;
using System.Windows.Forms;

namespace WebCamApp
{
    public partial class SettingsForm : Form
    {
        private TextBox txtVideoPath;
        private TextBox txtImagePath;
        private TextBox txtVideoPattern;
        private TextBox txtImagePattern;
        private Button btnBrowseVideo;
        private Button btnBrowseImage;
        private Button btnOK;
        private Button btnCancel;
        private Label lblVideoPatternHelp;
        private Label lblVideoPath;
        private Label lblVideoPattern;
        private Label lblImagePath;
        private Label lblImagePattern;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private System.ComponentModel.IContainer components;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Label lblImagePatternHelp;

        public string VideoOutputPath { get; private set; }
        public string ImageOutputPath { get; private set; }
        public string VideoNamePattern { get; private set; }
        public string ImageNamePattern { get; private set; }

        public SettingsForm(string initialVideoPath, string initialImagePath, string initialVideoPattern = "video_{datetime}", string initialImagePattern = "image_{datetime}")
        {
            VideoOutputPath = initialVideoPath;
            ImageOutputPath = initialImagePath;
            VideoNamePattern = initialVideoPattern;
            ImageNamePattern = initialImagePattern;

            InitializeComponent();

            txtVideoPath.Text = initialVideoPath;
            txtImagePath.Text = initialImagePath;
            txtVideoPattern.Text = initialVideoPattern;
            txtImagePattern.Text = initialImagePattern;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.txtVideoPath = new System.Windows.Forms.TextBox();
            this.txtImagePath = new System.Windows.Forms.TextBox();
            this.txtVideoPattern = new System.Windows.Forms.TextBox();
            this.txtImagePattern = new System.Windows.Forms.TextBox();
            this.btnBrowseVideo = new System.Windows.Forms.Button();
            this.btnBrowseImage = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblVideoPath = new System.Windows.Forms.Label();
            this.lblVideoPattern = new System.Windows.Forms.Label();
            this.lblVideoPatternHelp = new System.Windows.Forms.Label();
            this.lblImagePath = new System.Windows.Forms.Label();
            this.lblImagePattern = new System.Windows.Forms.Label();
            this.lblImagePatternHelp = new System.Windows.Forms.Label();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // txtVideoPath
            // 
            this.txtVideoPath.Location = new System.Drawing.Point(9, 30);
            this.txtVideoPath.Margin = new System.Windows.Forms.Padding(2);
            this.txtVideoPath.Name = "txtVideoPath";
            this.txtVideoPath.Size = new System.Drawing.Size(312, 20);
            this.txtVideoPath.TabIndex = 0;
            // 
            // txtImagePath
            // 
            this.txtImagePath.Location = new System.Drawing.Point(9, 136);
            this.txtImagePath.Margin = new System.Windows.Forms.Padding(2);
            this.txtImagePath.Name = "txtImagePath";
            this.txtImagePath.Size = new System.Drawing.Size(312, 20);
            this.txtImagePath.TabIndex = 3;
            // 
            // txtVideoPattern
            // 
            this.txtVideoPattern.Location = new System.Drawing.Point(9, 76);
            this.txtVideoPattern.Margin = new System.Windows.Forms.Padding(2);
            this.txtVideoPattern.Name = "txtVideoPattern";
            this.txtVideoPattern.Size = new System.Drawing.Size(312, 20);
            this.txtVideoPattern.TabIndex = 1;
            // 
            // txtImagePattern
            // 
            this.txtImagePattern.Location = new System.Drawing.Point(9, 180);
            this.txtImagePattern.Margin = new System.Windows.Forms.Padding(2);
            this.txtImagePattern.Name = "txtImagePattern";
            this.txtImagePattern.Size = new System.Drawing.Size(312, 20);
            this.txtImagePattern.TabIndex = 5;
            // 
            // btnBrowseVideo
            // 
            this.btnBrowseVideo.Location = new System.Drawing.Point(332, 29);
            this.btnBrowseVideo.Margin = new System.Windows.Forms.Padding(2);
            this.btnBrowseVideo.Name = "btnBrowseVideo";
            this.btnBrowseVideo.Size = new System.Drawing.Size(56, 19);
            this.btnBrowseVideo.TabIndex = 2;
            this.btnBrowseVideo.Text = "Browse...";
            this.btnBrowseVideo.UseVisualStyleBackColor = true;
            this.btnBrowseVideo.Click += new System.EventHandler(this.btnBrowseVideo_Click);
            // 
            // btnBrowseImage
            // 
            this.btnBrowseImage.Location = new System.Drawing.Point(332, 135);
            this.btnBrowseImage.Margin = new System.Windows.Forms.Padding(2);
            this.btnBrowseImage.Name = "btnBrowseImage";
            this.btnBrowseImage.Size = new System.Drawing.Size(56, 19);
            this.btnBrowseImage.TabIndex = 4;
            this.btnBrowseImage.Text = "Browse...";
            this.btnBrowseImage.UseVisualStyleBackColor = true;
            this.btnBrowseImage.Click += new System.EventHandler(this.btnBrowseImage_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(263, 223);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(56, 24);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(332, 223);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 24);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblVideoPath
            // 
            this.lblVideoPath.AutoSize = true;
            this.lblVideoPath.Location = new System.Drawing.Point(9, 12);
            this.lblVideoPath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVideoPath.Name = "lblVideoPath";
            this.lblVideoPath.Size = new System.Drawing.Size(90, 13);
            this.lblVideoPath.TabIndex = 0;
            this.lblVideoPath.Text = "Video Save Path:";
            // 
            // lblVideoPattern
            // 
            this.lblVideoPattern.AutoSize = true;
            this.lblVideoPattern.Location = new System.Drawing.Point(9, 60);
            this.lblVideoPattern.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVideoPattern.Name = "lblVideoPattern";
            this.lblVideoPattern.Size = new System.Drawing.Size(105, 13);
            this.lblVideoPattern.TabIndex = 1;
            this.lblVideoPattern.Text = "Video Name Pattern:";
            // 
            // lblVideoPatternHelp
            // 
            this.lblVideoPatternHelp.AutoSize = true;
            this.lblVideoPatternHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic);
            this.lblVideoPatternHelp.ForeColor = System.Drawing.Color.Gray;
            this.lblVideoPatternHelp.Location = new System.Drawing.Point(9, 97);
            this.lblVideoPatternHelp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVideoPatternHelp.Name = "lblVideoPatternHelp";
            this.lblVideoPatternHelp.Size = new System.Drawing.Size(218, 13);
            this.lblVideoPatternHelp.TabIndex = 2;
            this.lblVideoPatternHelp.Text = "Patterns: {datetime}, {counter}, {date}, {time}";
            // 
            // lblImagePath
            // 
            this.lblImagePath.AutoSize = true;
            this.lblImagePath.Location = new System.Drawing.Point(9, 118);
            this.lblImagePath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblImagePath.Name = "lblImagePath";
            this.lblImagePath.Size = new System.Drawing.Size(92, 13);
            this.lblImagePath.TabIndex = 3;
            this.lblImagePath.Text = "Image Save Path:";
            // 
            // lblImagePattern
            // 
            this.lblImagePattern.AutoSize = true;
            this.lblImagePattern.Location = new System.Drawing.Point(9, 164);
            this.lblImagePattern.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblImagePattern.Name = "lblImagePattern";
            this.lblImagePattern.Size = new System.Drawing.Size(107, 13);
            this.lblImagePattern.TabIndex = 4;
            this.lblImagePattern.Text = "Image Name Pattern:";
            // 
            // lblImagePatternHelp
            // 
            this.lblImagePatternHelp.AutoSize = true;
            this.lblImagePatternHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic);
            this.lblImagePatternHelp.ForeColor = System.Drawing.Color.Gray;
            this.lblImagePatternHelp.Location = new System.Drawing.Point(9, 201);
            this.lblImagePatternHelp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblImagePatternHelp.Name = "lblImagePatternHelp";
            this.lblImagePatternHelp.Size = new System.Drawing.Size(218, 13);
            this.lblImagePatternHelp.TabIndex = 5;
            this.lblImagePatternHelp.Text = "Patterns: {datetime}, {counter}, {date}, {time}";
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2Button1
            // 
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(368, 0);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(31, 27);
            this.guna2Button1.TabIndex = 12;
            this.guna2Button1.Text = "X";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(399, 260);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.lblVideoPath);
            this.Controls.Add(this.lblVideoPattern);
            this.Controls.Add(this.lblVideoPatternHelp);
            this.Controls.Add(this.lblImagePath);
            this.Controls.Add(this.lblImagePattern);
            this.Controls.Add(this.lblImagePatternHelp);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnBrowseImage);
            this.Controls.Add(this.btnBrowseVideo);
            this.Controls.Add(this.txtImagePath);
            this.Controls.Add(this.txtVideoPath);
            this.Controls.Add(this.txtVideoPattern);
            this.Controls.Add(this.txtImagePattern);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Output Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnBrowseVideo_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserEx.FolderBrowserDialog();

            dialog.Title = "Select video output folder";
            dialog.InitialFolder = txtVideoPath.Text;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtVideoPath.Text = dialog.SelectedFolder;
            }

        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserEx.FolderBrowserDialog();
            dialog.Title = "Select image output folder";
            dialog.InitialFolder = txtImagePath.Text;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtImagePath.Text = dialog.SelectedFolder;
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            VideoOutputPath = txtVideoPath.Text;
            ImageOutputPath = txtImagePath.Text;
            VideoNamePattern = txtVideoPattern.Text;
            ImageNamePattern = txtImagePattern.Text;

            // Add validation for patterns if needed
            if (string.IsNullOrWhiteSpace(VideoNamePattern))
            {
                MessageBox.Show("Video name pattern cannot be empty", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVideoPattern.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(ImageNamePattern))
            {
                MessageBox.Show("Image name pattern cannot be empty", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtImagePattern.Focus();
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {

        }
    }
}