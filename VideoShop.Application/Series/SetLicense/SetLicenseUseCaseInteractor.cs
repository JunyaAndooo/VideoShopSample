using System.Threading.Tasks;
using VideoShop.Domain.DomainModels.Series;
using VideoShop.Domain.DomainModels.Series.Exceptions;
using VideoShop.Domain.DomainModels.Series.ValueObjects;

namespace VideoShop.Application.Series.SetLicense
{
    public sealed class SetLicenseUseCaseInteractor : ISetLicenseUseCase
    {
        private readonly ISeriesRepository seriesRepository;

        public SetLicenseUseCaseInteractor(ISeriesRepository seriesRepository)
        {
            this.seriesRepository = seriesRepository;
        }

        public async ValueTask Handle(SetLicenseInputData inputData)
        {
            SeriesId seriesId = new(inputData.SeriesId);
            SeriesEntity finded = await this.seriesRepository.Find(seriesId);
            if (finded == null)
            {
                throw new SeriesNotFoundException();
            }
            SeriesEntity series = new
                (
                    SeriesId: seriesId,
                    SeriesName: finded.SeriesName,
                    LicensePrice: new LicensePrice(inputData.LicensePrice)
                );
            int updatedCount = await this.seriesRepository.Update(series);
            if (updatedCount == 0)
            {
                throw new SeriesNotUpdatedException();
            }
        }
    }
}
