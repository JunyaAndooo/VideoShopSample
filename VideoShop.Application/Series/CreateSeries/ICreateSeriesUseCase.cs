using System.Threading.Tasks;

namespace VideoShop.Application.Series.CreateSeries
{
    public interface ICreateSeriesUseCase
    {
        ValueTask Save(CreateSeriesInputData inputData);
    }
}
