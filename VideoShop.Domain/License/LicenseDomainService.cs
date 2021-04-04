using VideoShop.Domain.Audience.ValueObjects;
using VideoShop.Domain.Video.ValueObjects;

namespace VideoShop.Domain.License
{
    public class LicenseDomainService
    {
        private readonly ILicenseRepository licenseRepository;

        public LicenseDomainService(ILicenseRepository licenseRepository)
        {
            this.licenseRepository = licenseRepository;
        }

        public bool HasLicense(AudienceId audienceId, VideoId videoId)
        {
            return (this.licenseRepository.Find(audienceId, videoId) != null);
        }
    }
}
