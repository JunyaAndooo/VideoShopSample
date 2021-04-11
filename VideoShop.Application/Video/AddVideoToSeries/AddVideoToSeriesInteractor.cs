using System;
using System.Threading.Tasks;
using VideoShop.Domain.DomainModels.Series.ValueObjects;
using VideoShop.Domain.DomainModels.Video;
using VideoShop.Domain.DomainModels.Video.ValueObjects;

namespace VideoShop.Application.Video.AddVideoToSeries
{
    public class AddVideoToSeriesInteractor : IAddVideoToSeriesUseCase
    {
        private readonly IVideoRepository videoRepository;

        public AddVideoToSeriesInteractor(IVideoRepository videoRepository)
        {
            this.videoRepository = videoRepository;
        }

        public async ValueTask Add(AddVideoToSeriesInputData inputData)
        {
            VideoId videoId = new(inputData.VideoId);
            VideoEntity entity = await this.videoRepository.Find(videoId);
            if (entity == null)
            {
                throw new ArgumentNullException("動画ID", "値が取れませんでした");
            }
            VideoEntity newEntity = new
                (
                    VideoId: videoId,
                    SeriesId: new SeriesId(inputData.SeriesId),
                    VideoTitle: entity.VideoTitle,
                    Exam: entity.Exam,
                    FileConnectKey: entity.FileConnectKey,
                    Description: entity.Description
                );
            await this.videoRepository.Update(newEntity);
        }
    }
}
