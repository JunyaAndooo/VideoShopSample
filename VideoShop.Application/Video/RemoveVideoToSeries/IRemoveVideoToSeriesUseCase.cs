using System.Threading.Tasks;

namespace VideoShop.Application.Video.RemoveVideoToSeries
{
    public interface IRemoveVideoToSeriesUseCase
    {
        ValueTask Handle(RemoveVideoToSeriesInputData inputData);
    }
}
