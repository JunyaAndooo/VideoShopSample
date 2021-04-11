using System;
using VideoShop.Shared.Enumerations;

namespace VideoShop.Application.License.PurchaseLicense
{
    public record PurchaseLicenseInputData(Guid AudienceId, Guid SeriesId, LicenseTypeEnum LicenseTypeEnum) { }
}
