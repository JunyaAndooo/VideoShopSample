using System.IO;

namespace VideoShop.Application.Video.SaveVideo
{
    public sealed record SaveVideoInputData(MemoryStream UploadedMemoryStream, string UploadedFileName, string VideoTitle);
}
