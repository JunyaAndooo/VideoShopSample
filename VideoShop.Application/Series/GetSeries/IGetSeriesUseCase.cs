namespace VideoShop.Application.Series.GetSeries
{
    public interface IGetSeriesUseCase
    {
        GetSeriesOutputData Find(GetSeriesInputData inputData);
    }
}
