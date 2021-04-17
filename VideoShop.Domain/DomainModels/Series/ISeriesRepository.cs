using System.Threading.Tasks;
using VideoShop.Domain.DomainModels.Series.ValueObjects;

namespace VideoShop.Domain.DomainModels.Series
{
    public interface ISeriesRepository
    {
        ValueTask<bool> Insert(SeriesEntity entity);
        ValueTask<bool> Update(SeriesEntity entity);
        ValueTask<SeriesEntity> Find(SeriesId seriesId);
    }
}
