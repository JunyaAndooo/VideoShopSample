using VideoShop.Domain.Series.ValueObjects;
using VideoShop.Domain.Video.ValueObjects;

namespace VideoShop.Domain.Video
{
    public interface IVideoRepository
    {
        void Insert(VideoEntity entity);
        void UpdateSeriesId(VideoId videoId, SeriesId seriesId);
        void RemoveSeriesId(VideoId videoId);
        void UpdateExam(VideoId videoId, Exam exam);
        VideoEntity Find(VideoId value);
    }
}
