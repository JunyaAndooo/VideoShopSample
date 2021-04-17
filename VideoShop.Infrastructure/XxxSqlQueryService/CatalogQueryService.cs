using System;
using System.Threading.Tasks;
using VideoShop.Domain.DomainModels.Audience.ValueObjects;
using VideoShop.Domain.DomainModels.Buyer.ValueObjects;
using VideoShop.Domain.QueryModels.Catalog;

namespace VideoShop.Infrastructure.XxxSqlQueryService
{
    /// <summary>
    /// 今回はCleanArchitectureの勉強だから、実際のファイルアクセス処理、DBアクセス処理は省略しています
    /// </summary>
    public class CatalogQueryService : ICatalogQueryService
    {
        public ValueTask<SeriesQueryModel[]> FindPurchasedList(AudienceId audienceId)
        {
            throw new NotImplementedException();
        }

        public ValueTask<SeriesQueryModel[]> FindList(BuyerId buyerId)
        {
            throw new NotImplementedException();
        }
    }
}
