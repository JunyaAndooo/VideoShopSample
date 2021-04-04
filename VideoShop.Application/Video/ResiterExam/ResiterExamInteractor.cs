using System;
using VideoShop.Domain.Video;
using VideoShop.Domain.Video.ValueObjects;

namespace VideoShop.Application.Video.ResiterExam
{
    public class ResiterExamInteractor : IResiterExamUseCase
    {
        private readonly IVideoRepository videoRepository;
        private readonly VideoDomainService videoDomainService;

        public ResiterExamInteractor(
            IVideoRepository videoRepository,
            VideoDomainService videoDomainService
        )
        {
            this.videoRepository = videoRepository;
            this.videoDomainService = videoDomainService;
        }

        public void Resister(ResiterExamInputData inputData)
        {
            VideoId videoId = new(inputData.VideoId);
            if (!videoDomainService.Exist(videoId))
            {
                throw new ArgumentNullException("動画ID", "値が取れませんでした");
            }
            this.videoRepository.UpdateExam(videoId, new Exam(inputData.Exam));
        }
    }
}
