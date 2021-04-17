using System;

namespace VideoShop.Application.Series.SetLicense
{
    public sealed record SetLicenseInputData(Guid SeriesId, decimal LicensePrice);
}
