using System;
using System.Threading.Tasks;
using VideoShop.Domain.DomainModels.Exam;
using VideoShop.Domain.DomainModels.Exam.ValueObjects;
using VideoShop.Domain.DomainModels.Video;
using VideoShop.Domain.DomainModels.Video.Exceptions;
using VideoShop.Domain.DomainModels.Video.ValueObjects;

namespace VideoShop.Application.Video.ResiterExam
{
    public sealed class ResiterExamInteractor : IResiterExamUseCase
    {
        private readonly IVideoRepository videoRepository;
        private readonly IExamRepository examRepository;

        public ResiterExamInteractor(
            IVideoRepository videoRepository,
            IExamRepository examRepository
        )
        {
            this.videoRepository = videoRepository;
            this.examRepository = examRepository;
        }

        public async ValueTask Handle(ResiterExamInputData inputData)
        {
            VideoId videoId = new(inputData.VideoId);
            VideoEntity finded = await this.videoRepository.Find(videoId);
            if (finded == null)
            {
                throw new VideoNotFoundException();
            }

            ExamEntity exam = new
                (
                    ExamId: new ExamId(Guid.NewGuid()),
                    Question: new Question(inputData.Question),
                    Answer: new Answer(inputData.Answer)
                );
            this.examRepository.Insert(exam);

            VideoEntity video = new
                (
                    VideoId: videoId,
                    SeriesId: finded.SeriesId,
                    VideoTitle: finded.VideoTitle,
                    ExamId: exam.ExamId,
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
