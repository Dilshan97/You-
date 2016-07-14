using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeExtractor;
using System.IO;
using System.Diagnostics;

namespace You__
{
    public partial class Form1 : Form
    {
        private object videoDownloader;
        private object path;
        private object downloader;
        private object thread;
        private object video;
        

        public object Downloader_ { get; private set; }
        public Action<object, ProgressEventArgs> DownloadProgressChanged { get; private set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboResolution.SelectedIndex = 0;
        }

        private void btnDonloader_Click(object sender, EventArgs e)
        {
            progressBar.Minimum = 0;
            progressBar.Minimum = 100;
            IEnumerable<VideoInfo> videos = DownloadUrlResolver.GetDownloadUrls(txtUrl.Text);
            VideoInfo video = videos.First(p => p.VideoType == VideoType.Mp4 && p.Resolution == Convert.ToUInt32(cboResolution));
            if (video.RequiresDecryption)
                DownloadUrlResolver.DecryptDownloadUrl(video);
            VideoDownloader downloader = new VideoDownloader(video, Path.Combine(Application.StartupPath + "\\", video.Title + video.VideoExtension));
            downloader.DownloadProgressChanged += Downloader_DownloadProgressChanged;
            Thread Thread = new Thread(() => { downloader .Execute(); }) { IsBackground = true };
            Thread.Start();
        }
        private void Downloader_DownloadProgressChanged(object sender, ProgressEventArgs e)
        {
            Invoke(new MethodInvoker(delegate ()
            {
                progressBar.Value = (int)e.ProgressPercentage;
                lblPercentage.Text = $"{string.Format("{0:0.##}", e.ProgressPercentage)}%";
                progressBar.Update();

            }
            )
            );
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://technologhy01.blogspot.com");
        }
    }
}
