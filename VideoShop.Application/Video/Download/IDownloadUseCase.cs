namespace VideoShop.Application.Video.Download
{
    public interface IDownloadUseCase
    {
        DownloadOutputData Download(DownloadInputData inputData);
    }
}
