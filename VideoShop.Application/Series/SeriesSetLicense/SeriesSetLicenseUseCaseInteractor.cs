using VideoShop.Domain.Series;
using VideoShop.Domain.Series.ValueObjects;

namespace VideoShop.Application.Series.SeriesSetLicense
{
    public class SeriesSetLicenseUseCaseInteractor : ISeriesSetLicenseUseCase
    {
        private readonly ISeriesRepository seriesRepository;

        public SeriesSetLicenseUseCaseInteractor(ISeriesRepository seriesRepository)
        {
            this.seriesRepository = seriesRepository;
        }

        public void SetLicense(SeriesSetLicenseInputData inputData)
        {
            this.seriesRepository.UpdateLicensePrice(
                new SeriesId(inputData.SeriesId),
                new LicensePrice(inputData.LicensePrice));
        }
    }
}
