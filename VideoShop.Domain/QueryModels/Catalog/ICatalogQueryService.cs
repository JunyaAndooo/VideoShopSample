using System.Threading.Tasks;
using VideoShop.Domain.DomainModels.Audience.ValueObjects;
using VideoShop.Domain.DomainModels.Buyer.ValueObjects;

namespace VideoShop.Domain.QueryModels.Catalog
{
    public interface ICatalogQueryService
    {
        ValueTask<SeriesQueryModel[]> FindList(AudienceId audienceId);
        ValueTask<SeriesQueryModel[]> FindList(BuyerId buyerId);
    }
}
