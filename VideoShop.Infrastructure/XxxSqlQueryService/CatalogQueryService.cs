using System;
using VideoShop.Domain.Audience.ValueObjects;
using VideoShop.Domain.QueryModels.Catalog;

namespace VideoShop.Infrastructure.XxxSqlQueryService
{
    public class CatalogQueryService : ICatalogQueryService
    {
        public SeriesQueryModel[] FindList(AudienceId audienceId)
        {
            throw new NotImplementedException();
        }
    }
}
