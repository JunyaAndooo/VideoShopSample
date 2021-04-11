using VideoShop.Domain.QueryModels.Catalog;

namespace VideoShop.Application.Series.GetCatalogForBuyer
{
    public record GetCatalogForBuyerOutputData(SeriesQueryModel[] SeriesQueryModels) { }
}
