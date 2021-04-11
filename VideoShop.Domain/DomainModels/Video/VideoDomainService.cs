using System.Threading.Tasks;
using VideoShop.Domain.DomainModels.Series.ValueObjects;
using VideoShop.Domain.DomainModels.Video.ValueObjects;

namespace VideoShop.Domain.DomainModels.Video
{
    public class VideoDomainService
    {
        private readonly IVideoRepository videoRepository;

        public VideoDomainService(IVideoRepository videoRepository)
        {
            this.videoRepository = videoRepository;
        }

        public async ValueTask<bool> Registered(VideoId videoId, SeriesId seriesId)
        {
            VideoEntity entity = await this.videoRepository.Find(videoId);
            return (entity != null && entity.SeriesId == seriesId);
        }
    }
}
