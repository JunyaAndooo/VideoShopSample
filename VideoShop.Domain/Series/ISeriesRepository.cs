using VideoShop.Domain.Series.ValueObjects;

namespace VideoShop.Domain.Series
{
    public interface ISeriesRepository
    {
        void Insert(SeriesEntity entity);
        void UpdateLicensePrice(SeriesId series, LicensePrice licensePrice);
    }
}
