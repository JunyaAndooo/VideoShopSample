using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using VideoShop.Domain.Series.ValueObjects;
using VideoShop.Domain.Video.ValueObjects;

namespace VideoShop.Domain.Video
{
    public record VideoEntity(
        VideoId VideoId,
        SeriesId SeriesId,
        VideoTitle VideoTitle,
        FileConnectKey FileConnectKey,
        Exam Exam
    )
    : IEqualityComparer<VideoEntity>
    {
        public bool Equals(VideoEntity x, VideoEntity y)
        {
            return x.VideoId.Value == y.VideoId.Value;
        }

        public int GetHashCode([DisallowNull] VideoEntity obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
