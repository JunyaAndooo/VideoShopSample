using System;
using VideoShop.Domain.Video;
using VideoShop.Domain.Video.ValueObjects;

namespace VideoShop.Application.Video.SaveVideo
{
    public class SaveVideoInteractor : ISaveVideoUseCase
    {
        private readonly IVideoFileStorageRepository videoFileStorageRepository;
        private readonly IVideoRepository videoRepository;

        public SaveVideoInteractor(
            IVideoFileStorageRepository videoFileStorageRepository,
            IVideoRepository videoRepository
        )
        {
            this.videoFileStorageRepository = videoFileStorageRepository;
            this.videoRepository = videoRepository;
        }

        public void Save(SaveVideoInputData inputData)
        {
            string fileConnectKey = this.videoFileStorageRepository.Save(inputData.TmpFilePath);
            VideoEntity entity = new(
                VideoId:
                    new VideoId(Guid.NewGuid()),
                SeriesId:
                    null,
                VideoTitle:
                    new VideoTitle(inputData.VideoTitle),
                FileConnectKey:
                    new FileConnectKey(fileConnectKey));
            this.videoRepository.Insert(entity);
        }
    }
}
