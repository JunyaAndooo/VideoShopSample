using System;

namespace VideoShop.Application.Video.AddVideoToSeries
{
    public record AddVideoToSeriesInputData(Guid SeriesId, Guid VideoId) { }
}
