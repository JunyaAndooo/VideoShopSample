using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using VideoShop.Domain.Audience.ValueObjects;
using VideoShop.Domain.License.ValueObjects;
using VideoShop.Domain.Series.ValueObjects;

namespace VideoShop.Domain.License
{
    public record LicenseEntity(
        LicenseId LicenseId,
        SeriesId SeriesId,
        AudienceId AudienceId,
        LicenseType LicenseType,
        DateTime ExpirationTime
    )
    : IEqualityComparer<LicenseEntity>
    {
        public bool Equals(LicenseEntity x, LicenseEntity y)
        {
            return x.LicenseId.Value == y.LicenseId.Value;
        }

        public int GetHashCode([DisallowNull] LicenseEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
