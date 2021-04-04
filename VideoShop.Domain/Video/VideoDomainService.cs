using VideoShop.Domain.Series.ValueObjects;
using VideoShop.Domain.Video.ValueObjects;

namespace VideoShop.Domain.Video
{
    public class VideoDomainService
    {
        private readonly IVideoRepository videoRepository;

        public VideoDomainService(IVideoRepository videoRepository)
        {
            this.videoRepository = videoRepository;
        }

        public bool Exist(VideoId videoId)
        {
            return (this.videoRepository.Find(videoId) == null);
        }

        public bool Registered(VideoId videoId, SeriesId seriesId)
        {
            VideoEntity entity = this.videoRepository.Find(videoId);
            return (entity != null && entity.SeriesId == seriesId);
        }
    }
}
