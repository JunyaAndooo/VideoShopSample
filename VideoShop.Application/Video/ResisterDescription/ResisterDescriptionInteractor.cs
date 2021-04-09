using System;
using VideoShop.Domain.Video;
using VideoShop.Domain.Video.ValueObjects;

namespace VideoShop.Application.Video.ResisterDescription
{
    public class ResisterDescriptionInteractor : IResisterDescriptionUseCase
    {
        private readonly IVideoRepository videoRepository;
        private readonly VideoDomainService videoDomainService;

        public ResisterDescriptionInteractor(
            IVideoRepository videoRepository,
            VideoDomainService videoDomainService
        )
        {
            this.videoRepository = videoRepository;
            this.videoDomainService = videoDomainService;
        }

        public void Resister(ResisterDescriptionInputData inputData)
        {
            VideoId videoId = new(inputData.VideoId);
            if (!videoDomainService.Exist(videoId))
            {
                throw new ArgumentNullException("動画ID", "値が取れませんでした");
            }
            this.videoRepository.UpdateDescription(videoId, new Description(inputData.Description));
        }
    }
}
