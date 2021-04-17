using VideoShop.Domain.DomainModels.Series.ValueObjects;

namespace VideoShop.Domain.DomainModels.Series
{
    public sealed record SeriesEntity(
        SeriesId SeriesId,
        SeriesName SeriesName,
        LicensePrice LicensePrice
    );
}
