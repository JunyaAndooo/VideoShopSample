using System.Threading.Tasks;
using VideoShop.Domain.DomainModels.Video.ValueObjects;

namespace VideoShop.Domain.DomainModels.Video
{
    public interface IVideoRepository
    {
        ValueTask<bool> Insert(VideoEntity entity);
        ValueTask<bool> Update(VideoEntity entity);
        ValueTask<VideoEntity> Find(VideoId value);
    }
}
