using System.Threading.Tasks;
using VideoShop.Domain.DomainModels.Series;
using VideoShop.Domain.DomainModels.Series.ValueObjects;

namespace VideoShop.Application.Series.CreateSeries
{
    public class CreateSeriesInteractor : ICreateSeriesUseCase
    {
        private readonly ISeriesRepository seriesRepository;

        public CreateSeriesInteractor(ISeriesRepository seriesRepository)
        {
            this.seriesRepository = seriesRepository;
        }

        public async ValueTask Save(CreateSeriesInputData inputData)
        {
            SeriesEntity entity = new
                (
                    SeriesId: new SeriesId(inputData.SeriesId),
                    SeriesName: new SeriesName(inputData.SeriesName),
                    LicensePrice: null
                );
            await this.seriesRepository.Insert(entity);
        }
    }
}
