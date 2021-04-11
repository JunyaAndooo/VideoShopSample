using System;
using System.Threading.Tasks;
using VideoShop.Domain.DomainModels.Audience.ValueObjects;
using VideoShop.Domain.DomainModels.Buyer.ValueObjects;
using VideoShop.Domain.QueryModels.Catalog;

namespace VideoShop.Infrastructure.XxxSqlQueryService
{
    public class CatalogQueryService : ICatalogQueryService
    {
        public ValueTask<SeriesQueryModel[]> FindList(AudienceId audienceId)
        {
            throw new NotImplementedException();
        }

        public ValueTask<SeriesQueryModel[]> FindList(BuyerId buyerId)
        {
            throw new NotImplementedException();
        }
    }
}
