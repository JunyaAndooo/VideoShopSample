using System;
using VideoShop.Domain.Series.ValueObjects;
using VideoShop.Domain.Video;
using VideoShop.Domain.Video.ValueObjects;

namespace VideoShop.Application.Video.SeriesAddVideo
{
    public class SeriesAddVideoInteractor : ISeriesAddVideoUseCase
    {
        private readonly IVideoRepository videoRepository;
        private readonly VideoDomainService videoDomainService;

        public SeriesAddVideoInteractor(
            IVideoRepository videoRepository,
            VideoDomainService videoDomainService
        )
        {
            this.videoRepository = videoRepository;
            this.videoDomainService = videoDomainService;
        }

        public void Add(SeriesAddVideoInputData inputData)
        {
            VideoId videoId = new(inputData.VideoId);
            if (!videoDomainService.Exist(videoId))
            {
                throw new ArgumentNullException("動画ID", "値が取れませんでした");
            }
            this.videoRepository.UpdateSeriesId(videoId, new SeriesId(inputData.SeriesId));
        }
    }
}
