using VideoShop.Domain.Audience.ValueObjects;

namespace VideoShop.Domain.QueryModels.Catalog
{
    public interface ICatalogQueryService
    {
        SeriesQueryModel[] FindList(AudienceId audienceId);
    }
}
