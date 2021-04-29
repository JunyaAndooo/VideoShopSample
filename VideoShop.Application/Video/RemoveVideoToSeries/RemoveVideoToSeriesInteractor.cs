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
            VideoEntity finded = await this.videoRepository.Find(videoId);
            if (finded == null)
            {
                throw new VideoNotFoundException();
            }
            bool registered = await this.videoDomainService.Registered(videoId, new SeriesId(inputData.SeriesId));
            if (!registered)
            {
                throw new SeriesWasNotRegisteredException();
            }
            VideoEntity video = new
            (
                VideoId: videoId,
                SeriesId: null,
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
