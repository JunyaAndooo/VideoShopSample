using System.Threading.Tasks;
using VideoShop.Domain.DomainModels.Series.ValueObjects;

namespace VideoShop.Domain.DomainModels.Series
{
    public interface ISeriesRepository
    {
        ValueTask Insert(SeriesEntity series);
        ValueTask<int> Update(SeriesEntity series);
        ValueTask<SeriesEntity> Find(SeriesId seriesId);
    }
}
