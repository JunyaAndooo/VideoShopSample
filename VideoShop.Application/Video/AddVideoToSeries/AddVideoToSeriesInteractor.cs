using System.Threading.Tasks;
using VideoShop.Domain.DomainModels.Series.ValueObjects;
using VideoShop.Domain.DomainModels.Video;
using VideoShop.Domain.DomainModels.Video.Exceptions;
using VideoShop.Domain.DomainModels.Video.ValueObjects;

namespace VideoShop.Application.Video.AddVideoToSeries
{
    public sealed class AddVideoToSeriesInteractor : IAddVideoToSeriesUseCase
    {
        private readonly IVideoRepository videoRepository;

        public AddVideoToSeriesInteractor(IVideoRepository videoRepository)
        {
            this.videoRepository = videoRepository;
        }

        public async ValueTask Handle(AddVideoToSeriesInputData inputData)
        {
            VideoId videoId = new(inputData.VideoId);
            VideoEntity entity = await this.videoRepository.Find(videoId);
            if (entity == null)
            {
                throw new VideoNotFoundException();
            }
            VideoEntity updatedEntity = new
                (
                    VideoId: videoId,
                    SeriesId: new SeriesId(inputData.SeriesId),
                    VideoTitle: entity.VideoTitle,
                    Exam: entity.Exam,
                    FileConnectKey: entity.FileConnectKey,
                    Description: entity.Description
                );
            int updatedCount = await this.videoRepository.Update(updatedEntity);
            if (updatedCount == 0)
            {
                throw new VideoNotUpdatedException();
            }
        }
    }
}
