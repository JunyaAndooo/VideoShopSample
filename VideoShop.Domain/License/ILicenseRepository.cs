using VideoShop.Domain.Audience.ValueObjects;
using VideoShop.Domain.Video.ValueObjects;

namespace VideoShop.Domain.License
{
    public interface ILicenseRepository
    {
        LicenseEntity Find(AudienceId audienceId, VideoId videoId);
    }
}
