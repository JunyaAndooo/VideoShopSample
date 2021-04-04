using VideoShop.Domain.Audience.ValueObjects;
using VideoShop.Domain.License.ValueObjects;
using VideoShop.Domain.Series.ValueObjects;

namespace VideoShop.Domain.License
{
    public record LicenseEntity(LicenseId LicenseId, SeriesId SeriesId, AudienceId AudienceId) { }
}
