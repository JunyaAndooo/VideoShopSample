using System.Threading.Tasks;
using VideoShop.Domain.DomainModels.Series.ValueObjects;
using VideoShop.Domain.DomainModels.Video;
using VideoShop.Domain.DomainModels.Video.Exceptions;
using VideoShop.Domain.DomainModels.Video.ValueObjects;

namespace VideoShop.Application.Video.RemoveVideoToSeries
{
    public sealed class RemoveVideoToSeriesInteractor : IRemoveVideoToSeriesUseCase
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

        public async ValueTask Handle(RemoveVideoToSeriesInputData inputData)
        {
            VideoId videoId = new(inputData.VideoId);
            VideoEntity entity = await this.videoRepository.Find(videoId);
            if (entity == null)
            {
                throw new VideoNotFoundException();
            }
            bool registered = await this.videoDomainService.Registered(videoId, new SeriesId(inputData.SeriesId));
            if (!registered)
            {
                throw new SeriesWasNotRegisteredException();
            }
            VideoEntity updatedEntity = new
            (
                VideoId: videoId,
                SeriesId: null,
                VideoTitle: entity.VideoTitle,
                Exam: entity.Exam,
                FileConnectKey: entity.FileConnectKey,
                Description: entity.Description
            );
            bool result = await this.videoRepository.Update(updatedEntity);
            if (!result)
            {
                throw new VideoUpdateFailedException("SeriesId");
            }
        }
    }
}
