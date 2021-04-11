using System;
using System.Threading.Tasks;
using VideoShop.Domain.DomainModels.Series;
using VideoShop.Domain.DomainModels.Series.ValueObjects;

namespace VideoShop.Application.Series.SetLicense
{
    public class SetLicenseUseCaseInteractor : ISetLicenseUseCase
    {
        private readonly ISeriesRepository seriesRepository;

        public SetLicenseUseCaseInteractor(ISeriesRepository seriesRepository)
        {
            this.seriesRepository = seriesRepository;
        }

        public async ValueTask SetLicense(SetLicenseInputData inputData)
        {
            SeriesId seriesId = new(inputData.SeriesId);
            SeriesEntity entity = await this.seriesRepository.Find(seriesId);
            if (entity == null)
            {
                throw new ArgumentNullException("シリーズID", "値が取れませんでした");
            }
            SeriesEntity newEntity = new
                (
                    seriesId,
                    SeriesName: entity.SeriesName,
                    LicensePrice: new LicensePrice(inputData.LicensePrice)
                );
            await this.seriesRepository.Update(newEntity);
        }
    }
}
