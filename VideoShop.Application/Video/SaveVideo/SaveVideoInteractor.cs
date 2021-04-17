using System;
using System.Threading.Tasks;
using VideoShop.Domain.DomainModels.Video;
using VideoShop.Domain.DomainModels.Video.Exceptions;
using VideoShop.Domain.DomainModels.Video.ValueObjects;
using VideoShop.Domain.Video.ValueObjects;
using VideoShop.Shared.Clients;
using VideoShop.Shared.Clients.Exceptions;
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
            if (fileConnectKey == null)
            {
                throw new FileUploadFailedException();
            }
            VideoEntity entity = new
                (
                    VideoId: new VideoId(Guid.NewGuid()),
                    SeriesId: null,
                    VideoTitle: new VideoTitle(inputData.VideoTitle),
                    Exam: null,
                    FileConnectKey: fileConnectKey,
                    Description: null
                );
            bool result = await this.videoRepository.Insert(entity);
            if (!result)
            {
                throw new VideoRegistrationFailedException();
            }
            SaveVideoOutputData outputData = new
                (
                    VideoId: entity.VideoId.Value
                );

            return outputData;
        }
    }
}
