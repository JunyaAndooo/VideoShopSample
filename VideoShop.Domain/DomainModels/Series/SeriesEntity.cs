using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using VideoShop.Domain.DomainModels.Series.ValueObjects;

namespace VideoShop.Domain.DomainModels.Series
{
    public record SeriesEntity(SeriesId SeriesId, SeriesName SeriesName, LicensePrice LicensePrice) : IEqualityComparer<SeriesEntity>
    {
        public bool Equals(SeriesEntity x, SeriesEntity y)
        {
            return x.SeriesId.Value == y.SeriesId.Value;
        }

        public int GetHashCode([DisallowNull] SeriesEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
