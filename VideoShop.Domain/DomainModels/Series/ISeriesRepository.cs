using System.Threading.Tasks;
using VideoShop.Domain.DomainModels.Series.ValueObjects;

namespace VideoShop.Domain.DomainModels.Series
{
    public interface ISeriesRepository
    {
        ValueTask Insert(SeriesEntity entity);
        ValueTask Update(SeriesEntity entity);
        ValueTask<SeriesEntity> Find(SeriesId seriesId);
    }
}
