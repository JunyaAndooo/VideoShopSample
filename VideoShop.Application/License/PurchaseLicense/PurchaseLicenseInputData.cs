using System;

namespace VideoShop.Application.License.PurchaseLicense
{
    public record PurchaseLicenseInputData(Guid AudienceId, Guid SeriesId, int LicenseType) { }
}
