using System.IO;
using System.Threading.Tasks;
using VideoShop.Domain.DomainModels.Audience.ValueObjects;
using VideoShop.Domain.DomainModels.License;
using VideoShop.Domain.DomainModels.License.Exceptions;
using VideoShop.Domain.DomainModels.Video;
using VideoShop.Domain.DomainModels.Video.Exceptions;
using VideoShop.Domain.DomainModels.Video.ValueObjects;
using VideoShop.Shared.Clients;

namespace VideoShop.Application.Video.Download
{
    public sealed class DownloadInteractor : IDownloadUseCase
    {
        private readonly LicenseDomainService licenseDomainService;
        private readonly IVideoRepository videoRepository;
        private readonly IFileStorageClient fileStorageClient;

        public DownloadInteractor(
            LicenseDomainService licenseDomainService,
            IVideoRepository videoRepository,
            IFileStorageClient fileStorageClient
        )
        {
            this.licenseDomainService = licenseDomainService;
            this.videoRepository = videoRepository;
            this.fileStorageClient = fileStorageClient;
        }

        public async ValueTask<DownloadOutputData> Handle(DownloadInputData inputData)
        {
            VideoId videoId = new(inputData.VideoId);
            AudienceId audienceId = new(inputData.AudienceId);
            bool hasLicense = await this.licenseDomainService.HasLicense(audienceId, videoId);
            if (!hasLicense)
            {
                throw new LicenseIsNotValidException();
            }
            VideoEntity finded = await this.videoRepository.Find(videoId);
            if (finded == null)
            {
                throw new VideoNotFoundException();
            }
            (string fileName, MemoryStream stream) = await this.fileStorageClient.Find(finded.FileConnectKey);

            DownloadOutputData outputData = new
                (
                    FileName: fileName,
                    Stream: stream
                );

            return outputData;
        }
    }
}
