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
            VideoEntity finded = await this.videoRepository.Find(videoId);
            if (finded == null)
            {
                throw new VideoNotFoundException();
            }
            VideoEntity video = new
                (
                    VideoId: videoId,
                    SeriesId: new SeriesId(inputData.SeriesId),
                    VideoTitle: finded.VideoTitle,
                    ExamId: finded.ExamId,
                    FileConnectKey: finded.FileConnectKey,
                    Description: finded.Description
                );
            int updatedCount = await this.videoRepository.Update(video);
            if (updatedCount == 0)
            {
                throw new VideoNotUpdatedException();
            }
        }
    }
}
