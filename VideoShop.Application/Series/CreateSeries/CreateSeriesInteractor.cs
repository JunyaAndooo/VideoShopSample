using System;
using System.Threading.Tasks;
using VideoShop.Domain.DomainModels.Series;
using VideoShop.Domain.DomainModels.Series.ValueObjects;

namespace VideoShop.Application.Series.CreateSeries
{
    public sealed class CreateSeriesInteractor : ICreateSeriesUseCase
    {
        private readonly ISeriesRepository seriesRepository;

        public CreateSeriesInteractor(ISeriesRepository seriesRepository)
        {
            this.seriesRepository = seriesRepository;
        }

        public async ValueTask<CreateSeriesOutputData> Handle(CreateSeriesInputData inputData)
        {
            SeriesEntity series = new
                (
                    SeriesId: new SeriesId(Guid.NewGuid()),
                    SeriesName: new SeriesName(inputData.SeriesName),
                    LicensePrice: null
                );
            await this.seriesRepository.Insert(series);
            CreateSeriesOutputData outputData = new
                (
                    SeriesId: series.SeriesId.Value
                );

            return outputData;
        }
    }
}
