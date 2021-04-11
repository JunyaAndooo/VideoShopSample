using System.Threading.Tasks;

namespace VideoShop.Application.Video.Download
{
    public interface IDownloadUseCase
    {
        ValueTask<DownloadOutputData> Download(DownloadInputData inputData);
    }
}
