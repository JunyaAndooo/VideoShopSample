using System;

namespace VideoShop.Application.Series.SetLicense
{
    public record SetLicenseInputData(Guid SeriesId, decimal LicensePrice) { }
}
