using System;
using System.Threading.Tasks;
using VideoShop.Domain.DomainModels.Video;
using VideoShop.Domain.DomainModels.Video.ValueObjects;

namespace VideoShop.Application.Video.ResiterExam
{
    public class ResiterExamInteractor : IResiterExamUseCase
    {
        private readonly IVideoRepository videoRepository;

        public ResiterExamInteractor(IVideoRepository videoRepository)
        {
            this.videoRepository = videoRepository;
        }

        public async ValueTask Resister(ResiterExamInputData inputData)
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
                    Exam: new Exam(inputData.Exam),
                    FileConnectKey: entity.FileConnectKey,
                    Description: entity.Description
                );
            await this.videoRepository.Update(newEntity);
        }
    }
}
