using System;
using System.Threading.Tasks;
using VideoShop.Domain.DomainModels.Video;
using VideoShop.Domain.DomainModels.Video.ValueObjects;
using VideoShop.Domain.Video.ValueObjects;
using VideoShop.Shared.Clients;
using VideoShop.Shared.Clients.ValueObjects;

namespace VideoShop.Application.Video.SaveVideo
{
    public sealed class SaveVideoInteractor : ISaveVideoUseCase
    {
        private readonly IFileStorageClient fileStorageClient;
        private readonly IVideoRepository videoRepository;

        public SaveVideoInteractor(
            IFileStorageClient fileStorageClient,
            IVideoRepository videoRepository
        )
        {
            this.fileStorageClient = fileStorageClient;
            this.videoRepository = videoRepository;
        }

        public async ValueTask<SaveVideoOutputData> Handle(SaveVideoInputData inputData)
        {
            FileConnectKey fileConnectKey =
                await this.fileStorageClient.Save(inputData.UploadedFileName, inputData.UploadedMemoryStream);
            VideoEntity video = new
                (
                    VideoId: new VideoId(Guid.NewGuid()),
                    SeriesId: null,
                    VideoTitle: new VideoTitle(inputData.VideoTitle),
                    ExamId: null,
                    FileConnectKey: fileConnectKey,
                    Description: null
                );
            await this.videoRepository.Insert(video);
            SaveVideoOutputData outputData = new
                (
                    VideoId: video.VideoId.Value
                );

            return outputData;
        }
    }
}
