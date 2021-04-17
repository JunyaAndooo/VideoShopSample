using System;

namespace VideoShop.Application.Video.RemoveVideoToSeries
{
    public sealed record RemoveVideoToSeriesInputData(Guid SeriesId, Guid VideoId);
}
