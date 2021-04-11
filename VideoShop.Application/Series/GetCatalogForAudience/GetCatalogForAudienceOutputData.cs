using VideoShop.Domain.QueryModels.Catalog;

namespace VideoShop.Application.Series.GetCatalogForAudience
{
    public record GetCatalogForAudienceOutputData(SeriesQueryModel[] SeriesQueryModels) { }
}
