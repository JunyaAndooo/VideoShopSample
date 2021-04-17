using System.Threading.Tasks;

namespace VideoShop.Application.Video.Download
{
    public interface IDownloadUseCase
    {
        ValueTask<DownloadOutputData> Handle(DownloadInputData inputData);
    }
}
