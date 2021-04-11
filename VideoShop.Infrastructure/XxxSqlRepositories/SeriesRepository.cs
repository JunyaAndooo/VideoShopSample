using System;
using System.Threading.Tasks;
using VideoShop.Domain.DomainModels.Series;
using VideoShop.Domain.DomainModels.Series.ValueObjects;

namespace VideoShop.Infrastructure.XxxSqlRepositories
{
    public class SeriesRepository : ISeriesRepository
    {
        public ValueTask<SeriesEntity> Find(SeriesId seriesId)
        {
            throw new NotImplementedException();
        }

        public ValueTask Insert(SeriesEntity entity)
        {
            throw new NotImplementedException();
        }

        public ValueTask Update(SeriesEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
