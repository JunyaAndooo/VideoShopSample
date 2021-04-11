using System;
using System.Threading.Tasks;
using VideoShop.Domain.DomainModels.Series.ValueObjects;
using VideoShop.Domain.DomainModels.Video;
using VideoShop.Domain.DomainModels.Video.ValueObjects;

namespace VideoShop.Application.Video.RemoveVideoToSeries
{
    public class RemoveVideoToSeriesInteractor : IRemoveVideoToSeriesUseCase
    {
        private readonly IVideoRepository videoRepository;
        private readonly VideoDomainService videoDomainService;

        public RemoveVideoToSeriesInteractor(
            IVideoRepository videoRepository,
            VideoDomainService videoDomainService
        )
        {
            this.videoRepository = videoRepository;
            this.videoDomainService = videoDomainService;
        }

        public async ValueTask Remove(RemoveVideoToSeriesInputData inputData)
        {
            VideoId videoId = new(inputData.VideoId);
            VideoEntity entity = await this.videoRepository.Find(videoId);
            if (entity == null)
            {
                throw new ArgumentNullException("動画ID", "値が取れませんでした");
            }
            bool registered = await this.videoDomainService.Registered(videoId, new SeriesId(inputData.SeriesId));
            if (!registered)
            {
                throw new ArgumentException("シリーズに動画が登録されていませんでした");
            }
            VideoEntity newEntity = new
            (
                VideoId: videoId,
                SeriesId: null,
                VideoTitle: entity.VideoTitle,
                Exam: entity.Exam,
                FileConnectKey: entity.FileConnectKey,
                Description: entity.Description
            );
            await this.videoRepository.Update(newEntity);
        }
    }
}
