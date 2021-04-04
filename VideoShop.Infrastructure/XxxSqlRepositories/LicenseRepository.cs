using System;
using VideoShop.Domain.Audience.ValueObjects;
using VideoShop.Domain.License;
using VideoShop.Domain.Video.ValueObjects;

namespace VideoShop.Infrastructure.XxxSqlRepositories
{
    public class LicenseRepository : ILicenseRepository
    {
        public LicenseEntity Find(AudienceId audienceId, VideoId videoId)
        {
            throw new NotImplementedException();
        }

        public void Insert(LicenseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
