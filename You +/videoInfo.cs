using YoutubeExtractor;

namespace You__
{
    internal class videoInfo
    {
        internal int Resolution;
        internal string videoExtension;

        public bool RequiresDecryption { get; internal set; }
        public string Title { get; internal set; }
        public VideoType VideoType { get; internal set; }
    }
}