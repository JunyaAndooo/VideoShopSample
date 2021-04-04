using System;

namespace VideoShop.Application.Video.SeriesRemoveVideo
{
    public record SeriesRemoveVideoInputData(Guid SeriesId, Guid VideoId) { }
}
