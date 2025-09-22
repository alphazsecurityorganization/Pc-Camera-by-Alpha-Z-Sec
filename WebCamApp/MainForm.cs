using DirectShowLib;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebCamApp.Properties;

namespace WebCamApp
{

    public partial class MainForm : Form
    {
        private bool isCameraRunning = false;
        private VideoCapture capture;
        private VideoWriter outputVideo;
        private Mat frame;
        private Bitmap imageAlternate;
        private Bitmap image;
        private bool isUsingImageAlternate = false;

        private string videoOutputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Videos");
        private string imageOutputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");


        private string tempPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "WebCamApp", "Temp");

        private string videoNamePattern = "video_{datetime}";
        private string imageNamePattern = "image_{datetime}";

        private DateTime recordStartTime;
        private Timer recordTimer;
        private string recordTimeText = "";


        private bool isRecording = false;
        private List<OpenCvSharp.Size> resolutions = new List<OpenCvSharp.Size>
        {
            new OpenCvSharp.Size(640, 480),
            new OpenCvSharp.Size(800, 600),
            new OpenCvSharp.Size(1024, 768),
            new OpenCvSharp.Size(1280, 720),
            new OpenCvSharp.Size(1920, 1080)
        };
        private OpenCvSharp.Size currentResolution;

        public MainForm()
        {
            InitializeComponent();

            Directory.CreateDirectory(videoOutputPath);
            Directory.CreateDirectory(imageOutputPath);
            Directory.CreateDirectory(tempPath);

            LoadSettings();

            InitializeCounters();
            recordTimer = new Timer();
            recordTimer.Interval = 1000;
            recordTimer.Tick += RecordTimer_Tick;

            picCamera.Paint += pictureBox1_Paint;
        }

        private void RecordTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsed = DateTime.Now - recordStartTime;
            recordTimeText = $"{elapsed:hh\\:mm\\:ss}";
            picCamera.Invalidate(); 
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (isRecording)
            {
                Color recordColor = Color.FromArgb(255, 64, 64);
                using (Font font = new Font("Consolas", 18, FontStyle.Bold))
                using (SolidBrush brush = new SolidBrush(recordColor))
                {
                    e.Graphics.DrawString(recordTimeText, font, brush, new PointF(picCamera.Width - 120, 10));
                }
            }
        }



        private void LoadSettings()
        {
            
            try
            {
                if (Settings.Default.VideoOutputPath != string.Empty)
                    videoOutputPath = Properties.Settings.Default.VideoOutputPath;

                if (Properties.Settings.Default.ImageOutputPath != string.Empty)
                    imageOutputPath = Properties.Settings.Default.ImageOutputPath;

                if (Properties.Settings.Default.VideoNamePattern != string.Empty)
                    videoNamePattern = Properties.Settings.Default.VideoNamePattern;
                else
                    videoNamePattern = "video_{datetime}";

                if (Properties.Settings.Default.ImageNamePattern != string.Empty)
                    imageNamePattern = Properties.Settings.Default.ImageNamePattern;
                else
                    imageNamePattern = "image_{datetime}";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading settings: {ex.Message}");
                videoNamePattern = "video_{datetime}";
                imageNamePattern = "image_{datetime}";
            }
        }

        private void InitializeCounters()
        {
            try
            {
                FileNameGenerator.FindNextCounterFromDirectory(videoOutputPath, videoNamePattern, ".mp4", "video");
                FileNameGenerator.FindNextCounterFromDirectory(imageOutputPath, imageNamePattern, ".jpg", "image");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error initializing counters: {ex.Message}");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "Ready";

            LoadVideoDevices();
            LoadResolutions();

            if (cmbCameras.Items.Count > 0)
            {
                cmbCameras.SelectedIndex = 0;
                cmbResolution.SelectedIndex = 0;
                StartCamera();
            }
            else
            {
                MessageBox.Show("No camera devices found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lblStatus.Text = "No camera devices found";
            }
        }

        private void LoadVideoDevices()
        {
            cmbCameras.Items.Clear();
            var videoDevices = new List<DsDevice>(DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice));
            foreach (var device in videoDevices)
            {
                cmbCameras.Items.Add(device.Name);
            }
        }

        private void LoadResolutions()
        {
            cmbResolution.Items.Clear();
            foreach (var resolution in resolutions)
            {
                cmbResolution.Items.Add($"{resolution.Width}x{resolution.Height}");
            }
        }

        private void cmbCameras_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isCameraRunning)
            {
                StopCamera();
                StartCamera();
            }
        }

        private void cmbResolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isCameraRunning)
            {
                StopCamera();
                StartCamera();
            }
        }

        private void StartCamera()
        {
            try
            {
                DisposeCameraResources();

                int deviceIndex = cmbCameras.SelectedIndex;
                if (deviceIndex < 0) return;

                capture = new VideoCapture(deviceIndex);

                if (!capture.IsOpened())
                {
                    MessageBox.Show($"Failed to open camera {cmbCameras.Text}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int resolutionIndex = cmbResolution.SelectedIndex;
                currentResolution = resolutions[resolutionIndex];

                capture.Set(VideoCaptureProperties.FrameWidth, currentResolution.Width);
                capture.Set(VideoCaptureProperties.FrameHeight, currentResolution.Height);

                recordingTimer.Start();
                isCameraRunning = true;

                lblStatus.Text = $"Camera running at {currentResolution.Width}x{currentResolution.Height}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error starting camera: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "Camera error";
            }
        }

        private void StopCamera()
        {
            recordingTimer.Stop();
            isCameraRunning = false;
            isRecording = false;

            DisposeCaptureResources();
            DisposeCameraResources();

            btnRecord.Text = "Record Video";
            lblStatus.Text = "Camera stopped";
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            if (!isCameraRunning)
            {
                MessageBox.Show("Camera is not running.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!isRecording)
            {
                StartRecording();
            }
            else
            {
                //var dlg = MessageBox.Show("Are you sure you want to stop recording?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //if (dlg == DialogResult.Yes)
                    StopRecording();
            }
        }

        private void StartRecording()
        {
            try
            {
                if (!Directory.Exists(tempPath))
                {
                    Directory.CreateDirectory(tempPath);
                }

                string tempVideoFile = Path.Combine(tempPath, "temp_video.mp4");

                outputVideo = new VideoWriter(tempVideoFile, FourCC.MP4V, 30, currentResolution);

                if (!outputVideo.IsOpened())
                {
                    MessageBox.Show("Failed to create video file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                isRecording = true;
                btnRecord.Text = "Stop Recording";
                lblStatus.Text = "Recording...";

                recordStartTime = DateTime.Now;
                recordTimer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error starting recording: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void StopRecording()
        {
            if (isRecording)
            {
                isRecording = false;
                btnRecord.Text = "Record Video";
                lblStatus.Text = "Processing recording...";
                recordTimer.Stop();
                recordTimeText = "";
                picCamera.Invalidate();

                if (outputVideo != null)
                {
                    outputVideo.Release();
                    outputVideo.Dispose();
                    outputVideo = null;
                }

                await SaveRecordingAsync();
            }
        }

        private async Task SaveRecordingAsync()
        {
            try
            {
                string tempVideoFile = Path.Combine(tempPath, "temp_video.mp4");

                if (!File.Exists(tempVideoFile))
                {
                    throw new FileNotFoundException("Temporary video file not found.");
                }

                string outputFileName = FileNameGenerator.GenerateFileName(videoNamePattern, ".mp4", "video");
                string finalOutputPath = Path.Combine(videoOutputPath, outputFileName);

                Directory.CreateDirectory(videoOutputPath);

                File.Copy(tempVideoFile, finalOutputPath, true);

                try
                {
                    File.Delete(tempVideoFile);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Failed to delete temporary file: {ex.Message}");
                }

                lblStatus.Text = $"Video saved to: {finalOutputPath}";

                string argument = $"/select,\"{finalOutputPath}\"";
                System.Diagnostics.Process.Start("explorer.exe", argument);
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Failed to save video";
                MessageBox.Show($"Error saving video: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            await Task.CompletedTask;
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            if (!isCameraRunning)
            {
                MessageBox.Show("Camera is not running.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CaptureImage();
        }

        private async void CaptureImage()
        {
            try
            {
                Mat captureFrame = new Mat();
                capture.Read(captureFrame);

                if (captureFrame.Empty())
                {
                    MessageBox.Show("Failed to capture image.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string outputFileName = FileNameGenerator.GenerateFileName(imageNamePattern, ".jpg", "image");
                string outputPath = Path.Combine(imageOutputPath, outputFileName);

                Directory.CreateDirectory(imageOutputPath);

                captureFrame.SaveImage(outputPath);
                captureFrame.Dispose();

                lblStatus.Text = $"Image saved to: {outputPath}";

                await FlashCaptureEffectAsync();

                string argument = $"/select,\"{outputPath}\"";
                System.Diagnostics.Process.Start("explorer.exe", argument);
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Failed to save image";
                MessageBox.Show($"Error capturing image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task FlashCaptureEffectAsync()
        {
            Panel flashPanel = new Panel
            {
                BackColor = Color.White,
                Dock = DockStyle.Fill
            };

            panel1.Controls.Add(flashPanel);
            flashPanel.BringToFront();

            await Task.Delay(100);

            panel1.Controls.Remove(flashPanel);
            flashPanel.Dispose();
        }

        private void configureOutputPathsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new SettingsForm(videoOutputPath, imageOutputPath, videoNamePattern, imageNamePattern))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    videoOutputPath = form.VideoOutputPath;
                    imageOutputPath = form.ImageOutputPath;
                    videoNamePattern = form.VideoNamePattern;
                    imageNamePattern = form.ImageNamePattern;

                    SaveSettings();

                    FileNameGenerator.FindNextCounterFromDirectory(videoOutputPath, videoNamePattern, ".mp4", "video");
                    FileNameGenerator.FindNextCounterFromDirectory(imageOutputPath, imageNamePattern, ".jpg", "image");

                    Directory.CreateDirectory(videoOutputPath);
                    Directory.CreateDirectory(imageOutputPath);
                }
            }
        }

        private void SaveSettings()
        {
            try
            {
                Properties.Settings.Default.VideoOutputPath = videoOutputPath;
                Properties.Settings.Default.ImageOutputPath = imageOutputPath;
                Properties.Settings.Default.VideoNamePattern = videoNamePattern;
                Properties.Settings.Default.ImageNamePattern = imageNamePattern;
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error saving settings: {ex.Message}");
            }
        }

        private void DisposeCameraResources()
        {
            if (frame != null)
            {
                frame.Dispose();
                frame = null;
            }

            if (image != null)
            {
                image.Dispose();
                image = null;
            }

            if (imageAlternate != null)
            {
                imageAlternate.Dispose();
                imageAlternate = null;
            }
        }

        private void DisposeCaptureResources()
        {
            if (capture != null)
            {
                capture.Release();
                capture.Dispose();
                capture = null;
            }

            if (outputVideo != null)
            {
                outputVideo.Release();
                outputVideo.Dispose();
                outputVideo = null;
            }
        }

        private void recordingTimer_Tick(object sender, EventArgs e)
        {
            if (capture != null && capture.IsOpened())
            {
                try
                {
                    frame = new Mat();
                    capture.Read(frame);

                    if (!frame.Empty())
                    {
                        if (imageAlternate == null)
                        {
                            isUsingImageAlternate = true;
                            imageAlternate = BitmapConverter.ToBitmap(frame);
                        }
                        else if (image == null)
                        {
                            isUsingImageAlternate = false;
                            image = BitmapConverter.ToBitmap(frame);
                        }

                        picCamera.Image = isUsingImageAlternate ? imageAlternate : image;

                        if (isRecording && outputVideo != null && outputVideo.IsOpened())
                        {
                            outputVideo.Write(frame);
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Camera frame error: {ex.Message}");
                    picCamera.Image = null;
                }
                finally
                {
                    if (frame != null)
                    {
                        frame.Dispose();
                        frame = null;
                    }

                    if (isUsingImageAlternate && image != null)
                    {
                        image.Dispose();
                        image = null;
                    }
                    else if (!isUsingImageAlternate && imageAlternate != null)
                    {
                        imageAlternate.Dispose();
                        imageAlternate = null;
                    }
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopCamera();

            try
            {
                string tempVideoFile = Path.Combine(tempPath, "temp_video.mp4");
                if (File.Exists(tempVideoFile))
                {
                    File.Delete(tempVideoFile);
                }
            }
            catch { }
        }

        private void picCamera_DoubleClick(object sender, EventArgs e)
        {
            if(isCameraRunning)
            {
                StopCamera();
                picCamera.Image = null;
            }
            else
            {
                StartCamera();
            }   
        }

        private void telegramGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = "https://t.me/grayhatbangladeshofficial";

            try
            {
                
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("লিংক ওপেন করা যাচ্ছে না: " + ex.Message);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}