using System;
using VideoShop.Domain.Audience.ValueObjects;
using VideoShop.Domain.License;
using VideoShop.Domain.Video;
using VideoShop.Domain.Video.ValueObjects;

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

        public DownloadOutputData Download(DownloadInputData inputData)
        {
            VideoId videoId = new(inputData.VideoId);
            AudienceId audienceId = new(inputData.AudienceId);
            if (this.licenseDomainService.HasLicense(audienceId, videoId))
            {
                throw new ArgumentException("ライセンスが不正です");
            }
            VideoEntity entity = this.videoRepository.Find(videoId);
            DownloadOutputData outputData = new(
                FileConnectKey:
                    entity.FileConnectKey.Value);
            return outputData;
        }
    }
}
