using System;
using VideoShop.Domain.Series.ValueObjects;
using VideoShop.Domain.Video;
using VideoShop.Domain.Video.ValueObjects;

namespace VideoShop.Infrastructure.XxxSqlRepositories
{
    public class VideoRepository : IVideoRepository
    {
        public VideoEntity Find(VideoId value)
        {
            throw new NotImplementedException();
        }

        public void Insert(VideoEntity entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveSeriesId(VideoId videoId)
        {
            throw new NotImplementedException();
        }

        public void UpdateDescription(VideoId videoId, Description description)
        {
            throw new NotImplementedException();
        }

        public void UpdateExam(VideoId videoId, Exam exam)
        {
            throw new NotImplementedException();
        }

        public void UpdateSeriesId(VideoId videoId, SeriesId seriesId)
        {
            throw new NotImplementedException();
        }
    }
}
