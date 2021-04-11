using System.Threading.Tasks;

namespace VideoShop.Application.Video.AddVideoToSeries
{
    public interface IAddVideoToSeriesUseCase
    {
        ValueTask Add(AddVideoToSeriesInputData inputData);
    }
}
