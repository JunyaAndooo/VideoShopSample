using System;
using VideoShop.Domain.DomainModels.License.Enumerations;

namespace VideoShop.Application.License.PurchaseLicense
{
    public sealed record PurchaseLicenseInputData(Guid AudienceId, Guid SeriesId, LicenseType LicenseType);
}
