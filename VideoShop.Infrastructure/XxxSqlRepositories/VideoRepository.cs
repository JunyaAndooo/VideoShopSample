using System;
using System.Threading.Tasks;
using VideoShop.Domain.DomainModels.Video;
using VideoShop.Domain.DomainModels.Video.ValueObjects;

namespace VideoShop.Infrastructure.XxxSqlRepositories
{
    public class VideoRepository : IVideoRepository
    {
        public ValueTask<VideoEntity> Find(VideoId value)
        {
            throw new NotImplementedException();
        }

        public ValueTask Insert(VideoEntity entity)
        {
            throw new NotImplementedException();
        }

        public ValueTask Update(VideoEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
