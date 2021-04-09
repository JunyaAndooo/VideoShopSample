using System;

namespace VideoShop.Application.Series.SeriesSetLicense
{
    public record SeriesSetLicenseInputData(Guid SeriesId, decimal LicensePrice) { }
}
