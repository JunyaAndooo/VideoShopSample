using System.Threading.Tasks;
using VideoShop.Domain.DomainModels.Video;
using VideoShop.Domain.DomainModels.Video.Exceptions;
using VideoShop.Domain.DomainModels.Video.ValueObjects;

namespace VideoShop.Application.Video.ResiterExam
{
    public sealed class ResiterExamInteractor : IResiterExamUseCase
    {
        private readonly IVideoRepository videoRepository;

        public ResiterExamInteractor(IVideoRepository videoRepository)
        {
            this.videoRepository = videoRepository;
        }

        public async ValueTask Handle(ResiterExamInputData inputData)
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
                    SeriesId: entity.SeriesId,
                    VideoTitle: entity.VideoTitle,
                    Exam: new Exam(inputData.Exam),
                    FileConnectKey: entity.FileConnectKey,
                    Description: entity.Description
                );
            bool result = await this.videoRepository.Update(updatedEntity);
            if (!result)
            {
                throw new VideoUpdateFailedException("Exam");
            }
        }
    }
}
