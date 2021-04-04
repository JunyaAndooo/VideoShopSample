using VideoShop.Domain.Series;
using VideoShop.Domain.Series.ValueObjects;

namespace VideoShop.Application.Series.CreateSeries
{
    public class CreateSeriesInteractor : ICreateSeriesUseCase
    {
        private readonly ISeriesRepository seriesRepository;

        public CreateSeriesInteractor(ISeriesRepository seriesRepository)
        {
            this.seriesRepository = seriesRepository;
        }

        public void Save(CreateSeriesInputData inputData)
        {
            SeriesEntity entity = new(
                SeriesId:
                    new SeriesId(inputData.SeriesId),
                SeriesName:
                    new SeriesName(inputData.SeriesName));
            this.seriesRepository.Insert(entity);
        }
    }
}
