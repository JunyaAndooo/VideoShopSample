using System;
using System.Threading.Tasks;
using VideoShop.Domain.DomainModels.Audience.ValueObjects;
using VideoShop.Domain.DomainModels.License;
using VideoShop.Domain.DomainModels.Video.ValueObjects;

namespace VideoShop.Infrastructure.XxxSqlRepositories
{
    /// <summary>
    /// 今回はCleanArchitectureの勉強だから、実際のファイルアクセス処理、DBアクセス処理は省略しています
    /// </summary>
    public class LicenseRepository : ILicenseRepository
    {
        public ValueTask<LicenseEntity> Find(AudienceId audienceId, VideoId videoId)
        {
            throw new NotImplementedException();
        }

        ValueTask<bool> ILicenseRepository.Insert(LicenseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
