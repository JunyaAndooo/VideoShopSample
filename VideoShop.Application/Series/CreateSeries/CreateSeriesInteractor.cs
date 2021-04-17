using System;
using System.Threading.Tasks;
using VideoShop.Domain.DomainModels.Series;
using VideoShop.Domain.DomainModels.Series.Exceptions;
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
            SeriesEntity entity = new
                (
                    SeriesId: new SeriesId(Guid.NewGuid()),
                    SeriesName: new SeriesName(inputData.SeriesName),
                    LicensePrice: null
                );
            bool result = await this.seriesRepository.Insert(entity);
            if (!result)
            {
                throw new SeriesRegistrationFailedException();
            }
            CreateSeriesOutputData outputData = new
                (
                    SeriesId: entity.SeriesId.Value
                );

            return outputData;
        }
    }
}
