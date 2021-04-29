using System.Threading.Tasks;
using VideoShop.Domain.DomainModels.Video;
using VideoShop.Domain.DomainModels.Video.Exceptions;
using VideoShop.Domain.DomainModels.Video.ValueObjects;

namespace VideoShop.Application.Video.ResisterDescription
{
    public sealed class ResisterDescriptionInteractor : IResisterDescriptionUseCase
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

        public async ValueTask Handle(ResisterDescriptionInputData inputData)
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
                    SeriesId: finded.SeriesId,
                    VideoTitle: finded.VideoTitle,
                    ExamId: finded.ExamId,
                    FileConnectKey: finded.FileConnectKey,
                    Description: new Description(inputData.Description)
                );
            int updatedCount = await this.videoRepository.Update(video);
            if (updatedCount == 0)
            {
                throw new VideoNotUpdatedException();
            }
        }
    }
}
