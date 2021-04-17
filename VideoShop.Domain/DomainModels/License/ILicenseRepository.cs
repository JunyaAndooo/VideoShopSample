using System.Threading.Tasks;
using VideoShop.Domain.DomainModels.Audience.ValueObjects;
using VideoShop.Domain.DomainModels.Video.ValueObjects;

namespace VideoShop.Domain.DomainModels.License
{
    public interface ILicenseRepository
    {
        ValueTask<LicenseEntity> Find(AudienceId audienceId, VideoId videoId);
        ValueTask<bool> Insert(LicenseEntity entity);
    }
}
