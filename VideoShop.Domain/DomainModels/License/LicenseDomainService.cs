using System;
using System.Threading.Tasks;
using VideoShop.Domain.DomainModels.Audience.ValueObjects;
using VideoShop.Domain.DomainModels.Video.ValueObjects;

namespace VideoShop.Domain.DomainModels.License
{
    public class LicenseDomainService
    {
        private readonly ILicenseRepository licenseRepository;

        public LicenseDomainService(ILicenseRepository licenseRepository)
        {
            this.licenseRepository = licenseRepository;
        }

        public async ValueTask<bool> HasLicense(AudienceId audienceId, VideoId videoId)
        {
            return (await this.licenseRepository.Find(audienceId, videoId) != null);
        }

        public static DateTime GetExpirationTime()
        {
            return DateTime.Now.AddDays(180);
        }
    }
}
