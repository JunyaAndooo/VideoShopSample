using System;

namespace VideoShop.Application.Video.RemoveVideoToSeries
{
    public record RemoveVideoToSeriesInputData(Guid SeriesId, Guid VideoId) { }
}
