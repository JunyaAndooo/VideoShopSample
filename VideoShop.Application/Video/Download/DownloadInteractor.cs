using System;
using System.Threading.Tasks;
using VideoShop.Domain.DomainModels.Audience.ValueObjects;
using VideoShop.Domain.DomainModels.License;
using VideoShop.Domain.DomainModels.Video;
using VideoShop.Domain.DomainModels.Video.ValueObjects;

namespace VideoShop.Application.Video.Download
{
    public class DownloadInteractor : IDownloadUseCase
    {
        private readonly LicenseDomainService licenseDomainService;
        private readonly IVideoRepository videoRepository;

        public DownloadInteractor(
            LicenseDomainService licenseDomainService,
            IVideoRepository videoRepository
        )
        {
            this.licenseDomainService = licenseDomainService;
            this.videoRepository = videoRepository;
        }

        public async ValueTask<DownloadOutputData> Download(DownloadInputData inputData)
        {
            VideoId videoId = new(inputData.VideoId);
            AudienceId audienceId = new(inputData.AudienceId);
            bool hasLicense = await this.licenseDomainService.HasLicense(audienceId, videoId);
            if (hasLicense)
            {
                throw new ArgumentException("ライセンスが不正です（すでにお持ちです）");
            }
            VideoEntity entity = await this.videoRepository.Find(videoId);
            DownloadOutputData outputData = new
                (
                    FileConnectKey: entity.FileConnectKey.Value
                );

            return outputData;
        }
    }
}
