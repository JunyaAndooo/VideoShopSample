using System;

namespace VideoShop.Application.Video.AddVideoToSeries
{
    public sealed record AddVideoToSeriesInputData(Guid SeriesId, Guid VideoId);
}
