using System.IO;

namespace VideoShop.Application.Video.Download
{
    public sealed record DownloadOutputData(string FileName, Stream Stream);
}
