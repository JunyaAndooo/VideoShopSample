using System;
using System.Threading.Tasks;
using VideoShop.Domain.DomainModels.Audience.ValueObjects;
using VideoShop.Domain.DomainModels.License;
using VideoShop.Domain.DomainModels.Video.ValueObjects;

namespace VideoShop.Infrastructure.XxxSqlRepositories
{
    public class LicenseRepository : ILicenseRepository
    {
        public ValueTask<LicenseEntity> Find(AudienceId audienceId, VideoId videoId)
        {
            throw new NotImplementedException();
        }

        public ValueTask Insert(LicenseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
