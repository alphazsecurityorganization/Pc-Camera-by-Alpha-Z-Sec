namespace WebCamApp
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.cmbCameras = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.recordingTimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureOutputPathsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.telegramGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picCamera = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbResolution = new System.Windows.Forms.ComboBox();
            this.btnCapture = new System.Windows.Forms.Button();
            this.btnRecord = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbCameras
            // 
            this.cmbCameras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCameras.FormattingEnabled = true;
            this.cmbCameras.Location = new System.Drawing.Point(100, 31);
            this.cmbCameras.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCameras.Name = "cmbCameras";
            this.cmbCameras.Size = new System.Drawing.Size(175, 21);
            this.cmbCameras.TabIndex = 1;
            this.cmbCameras.SelectedIndexChanged += new System.EventHandler(this.cmbCameras_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select Camera:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 525);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(653, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(39, 17);
            this.lblStatus.Text = "Ready";
            // 
            // recordingTimer
            // 
            this.recordingTimer.Interval = 33;
            this.recordingTimer.Tick += new System.EventHandler(this.recordingTimer_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.telegramGroupToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(653, 28);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configureOutputPathsToolStripMenuItem});
            this.settingsToolStripMenuItem.Image = global::WebCamApp.Properties.Resources.Dtafalonso_Android_Lollipop_Settings_16;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // configureOutputPathsToolStripMenuItem
            // 
            this.configureOutputPathsToolStripMenuItem.Image = global::WebCamApp.Properties.Resources.Gakuseisean_Aire_Download_Folder_16;
            this.configureOutputPathsToolStripMenuItem.Name = "configureOutputPathsToolStripMenuItem";
            this.configureOutputPathsToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.configureOutputPathsToolStripMenuItem.Text = "Output Paths";
            this.configureOutputPathsToolStripMenuItem.Click += new System.EventHandler(this.configureOutputPathsToolStripMenuItem_Click);
            // 
            // telegramGroupToolStripMenuItem
            // 
            this.telegramGroupToolStripMenuItem.Image = global::WebCamApp.Properties.Resources.Telegram_icon_on_transparent_background_PNG;
            this.telegramGroupToolStripMenuItem.Name = "telegramGroupToolStripMenuItem";
            this.telegramGroupToolStripMenuItem.Size = new System.Drawing.Size(123, 24);
            this.telegramGroupToolStripMenuItem.Text = "Telegram Group";
            this.telegramGroupToolStripMenuItem.Click += new System.EventHandler(this.telegramGroupToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.picCamera);
            this.panel1.Location = new System.Drawing.Point(11, 98);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(619, 410);
            this.panel1.TabIndex = 7;
            // 
            // picCamera
            // 
            this.picCamera.BackColor = System.Drawing.Color.Black;
            this.picCamera.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCamera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCamera.Location = new System.Drawing.Point(0, 0);
            this.picCamera.Margin = new System.Windows.Forms.Padding(2);
            this.picCamera.Name = "picCamera";
            this.picCamera.Size = new System.Drawing.Size(619, 410);
            this.picCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCamera.TabIndex = 0;
            this.picCamera.TabStop = false;
            this.picCamera.DoubleClick += new System.EventHandler(this.picCamera_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 59);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Resolution:";
            // 
            // cmbResolution
            // 
            this.cmbResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResolution.FormattingEnabled = true;
            this.cmbResolution.Location = new System.Drawing.Point(100, 56);
            this.cmbResolution.Margin = new System.Windows.Forms.Padding(2);
            this.cmbResolution.Name = "cmbResolution";
            this.cmbResolution.Size = new System.Drawing.Size(175, 21);
            this.cmbResolution.TabIndex = 9;
            this.cmbResolution.SelectedIndexChanged += new System.EventHandler(this.cmbResolution_SelectedIndexChanged);
            // 
            // btnCapture
            // 
            this.btnCapture.Image = global::WebCamApp.Properties.Resources.camera;
            this.btnCapture.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCapture.Location = new System.Drawing.Point(494, 28);
            this.btnCapture.Margin = new System.Windows.Forms.Padding(2);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(121, 49);
            this.btnCapture.TabIndex = 4;
            this.btnCapture.Text = "Capture Image";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // btnRecord
            // 
            this.btnRecord.Image = global::WebCamApp.Properties.Resources.rec_button;
            this.btnRecord.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecord.Location = new System.Drawing.Point(347, 28);
            this.btnRecord.Margin = new System.Windows.Forms.Padding(2);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(115, 49);
            this.btnRecord.TabIndex = 3;
            this.btnRecord.Text = "Record Video";
            this.btnRecord.UseVisualStyleBackColor = true;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label3.Location = new System.Drawing.Point(318, 510);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(234, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Double click to start or stop the screen camera.";
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
            this.guna2Button1.Location = new System.Drawing.Point(621, 1);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(31, 27);
            this.guna2Button1.TabIndex = 11;
            this.guna2Button1.Text = "X";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 547);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbResolution);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.btnRecord);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbCameras);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(529, 495);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Camera PC by Alpha Z Security";
            this.TransparencyKey = System.Drawing.Color.Maroon;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCamera)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCamera;
        private System.Windows.Forms.ComboBox cmbCameras;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Timer recordingTimer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configureOutputPathsToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbResolution;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem telegramGroupToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}