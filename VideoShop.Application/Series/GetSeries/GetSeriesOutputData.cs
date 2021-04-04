using VideoShop.Domain.QueryModels.Catalog;

namespace VideoShop.Application.Series.GetSeries
{
    public record GetSeriesOutputData(SeriesQueryModel[] SeriesQueryModels) { }
}
