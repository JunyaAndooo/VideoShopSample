using System;
using System.Threading.Tasks;
using VideoShop.Domain.DomainModels.Video;
using VideoShop.Domain.DomainModels.Video.ValueObjects;
using VideoShop.Domain.Video.ValueObjects;
using VideoShop.Shared.Clients;

namespace VideoShop.Application.Video.SaveVideo
{
    public class SaveVideoInteractor : ISaveVideoUseCase
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

        public async ValueTask Save(SaveVideoInputData inputData)
        {
            string fileConnectKey = await this.fileStorageClient.Save(inputData.TmpFilePath);
            VideoEntity entity = new
                (
                    VideoId: new VideoId(Guid.NewGuid()),
                    SeriesId: null,
                    VideoTitle: new VideoTitle(inputData.VideoTitle),
                    Exam: null,
                    FileConnectKey: new FileConnectKey(fileConnectKey),
                    Description: null
                );
            await this.videoRepository.Insert(entity);
        }
    }
}
