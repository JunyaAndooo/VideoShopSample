using System.Threading.Tasks;
using VideoShop.Domain.DomainModels.Video.ValueObjects;

namespace VideoShop.Domain.DomainModels.Video
{
    public interface IVideoRepository
    {
        ValueTask Insert(VideoEntity video);
        ValueTask<int> Update(VideoEntity video);
        ValueTask<VideoEntity> Find(VideoId value);
    }
}
