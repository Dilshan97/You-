using System;

namespace You__
{
    internal class videoDownloader
    {
        internal int DownloadProgressChanged;
        private string v;
        private videoInfo video;

        public videoDownloader(videoInfo video, string v)
        {
            this.video = video;
            this.v = v;
        }

        internal void Execute()
        {
            throw new NotImplementedException();
        }
    }
}