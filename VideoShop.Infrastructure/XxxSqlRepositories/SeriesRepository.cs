using System;
using System.Threading.Tasks;
using VideoShop.Domain.DomainModels.Series;
using VideoShop.Domain.DomainModels.Series.ValueObjects;

namespace VideoShop.Infrastructure.XxxSqlRepositories
{
    /// <summary>
    /// 今回はCleanArchitectureの勉強だから、実際のファイルアクセス処理、DBアクセス処理は省略しています
    /// </summary>
    public class SeriesRepository : ISeriesRepository
    {
        public ValueTask<SeriesEntity> Find(SeriesId seriesId)
        {
            throw new NotImplementedException();
        }

        ValueTask<bool> ISeriesRepository.Insert(SeriesEntity entity)
        {
            throw new NotImplementedException();
        }

        ValueTask<bool> ISeriesRepository.Update(SeriesEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
