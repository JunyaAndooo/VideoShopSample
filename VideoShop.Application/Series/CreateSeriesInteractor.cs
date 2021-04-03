namespace VideoShop.Application.Series
{
    public class CreateSeriesInteractor : ICreateSeriesUseCase
    {
        private readonly ISeriesRepository seriesRepository;

        public void Save(CreateSeriesInputData inputData)
        {
            SeriesEntity entity = new(SeriesName: new Domain.Video.Series.ValueObjects.SeriesName(inputData.SeriesName), SeriesId: null);

            this.seriesRepository.Save(entity);
        }
    }
}
