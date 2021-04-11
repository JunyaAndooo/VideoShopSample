using System;
using System.Threading.Tasks;
using VideoShop.Domain.DomainModels.Video;
using VideoShop.Domain.DomainModels.Video.ValueObjects;

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

        public async ValueTask Resister(ResisterDescriptionInputData inputData)
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
                    SeriesId: entity.SeriesId,
                    VideoTitle: entity.VideoTitle,
                    Exam: entity.Exam,
                    FileConnectKey: entity.FileConnectKey,
                    Description: new Description(inputData.Description)
                );
            await this.videoRepository.Update(newEntity);
        }
    }
}
