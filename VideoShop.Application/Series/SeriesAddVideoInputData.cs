using System;

namespace VideoShop.Application.Series
{
    public record SeriesAddVideoInputData(Guid SeriesId, Guid VideoId) { }
}
