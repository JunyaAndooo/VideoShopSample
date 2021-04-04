using System;
using VideoShop.Domain.Series.ValueObjects;
using VideoShop.Domain.Video;
using VideoShop.Domain.Video.ValueObjects;

namespace VideoShop.Application.Video.SeriesRemoveVideo
{
    public class SeriesRemoveVideoInteractor : ISeriesRemoveVideoUseCase
    {
        private readonly IVideoRepository videoRepository;
        private readonly VideoDomainService videoDomainService;

        public SeriesRemoveVideoInteractor(
            IVideoRepository videoRepository,
            VideoDomainService videoDomainService
        )
        {
            this.videoRepository = videoRepository;
            this.videoDomainService = videoDomainService;
        }

        public void Remove(SeriesRemoveVideoInputData inputData)
        {
            VideoId videoId = new(inputData.VideoId);
            if (!videoDomainService.Exist(videoId))
            {
                throw new ArgumentNullException("動画ID", "値が取れませんでした");
            }
            if (!videoDomainService.Registered(videoId, new SeriesId(inputData.SeriesId)))
            {
                throw new ArgumentException("シリーズに動画が登録されていませんでした");
            }
            this.videoRepository.RemoveSeriesId(videoId);
        }
    }
}
