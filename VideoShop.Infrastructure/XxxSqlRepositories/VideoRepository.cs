using System;
using System.Threading.Tasks;
using VideoShop.Domain.DomainModels.Video;
using VideoShop.Domain.DomainModels.Video.ValueObjects;

namespace VideoShop.Infrastructure.XxxSqlRepositories
{
    /// <summary>
    /// 今回はCleanArchitectureの勉強だから、実際のファイルアクセス処理、DBアクセス処理は省略しています
    /// </summary>
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

        public ValueTask<int> Update(VideoEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
