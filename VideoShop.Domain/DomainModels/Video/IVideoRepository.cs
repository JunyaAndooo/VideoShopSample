using System.Threading.Tasks;
using VideoShop.Domain.DomainModels.Video.ValueObjects;

namespace VideoShop.Domain.DomainModels.Video
{
    public interface IVideoRepository
    {
        ValueTask Insert(VideoEntity entity);
        ValueTask Update(VideoEntity entity);
        ValueTask<VideoEntity> Find(VideoId value);
    }
}
