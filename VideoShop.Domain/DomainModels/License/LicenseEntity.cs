using System;
using VideoShop.Domain.DomainModels.Audience.ValueObjects;
using VideoShop.Domain.DomainModels.License.Enumerations;
using VideoShop.Domain.DomainModels.License.ValueObjects;
using VideoShop.Domain.DomainModels.Series.ValueObjects;

namespace VideoShop.Domain.DomainModels.License
{
    public sealed record LicenseEntity(
        LicenseId LicenseId,
        SeriesId SeriesId,
        AudienceId AudienceId,
        LicenseType LicenseType,
        DateTime ExpirationTime
    );
}
