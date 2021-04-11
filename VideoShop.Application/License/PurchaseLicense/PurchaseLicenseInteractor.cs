using System;
using System.Threading.Tasks;
using VideoShop.Domain.DomainModels.Audience.ValueObjects;
using VideoShop.Domain.DomainModels.License;
using VideoShop.Domain.DomainModels.License.ValueObjects;
using VideoShop.Domain.DomainModels.Series.ValueObjects;

namespace VideoShop.Application.License.PurchaseLicense
{
    public class PurchaseLicenseInteractor : IPurchaseLicenseUseCase
    {
        private readonly ILicenseRepository licenseRepository;

        public PurchaseLicenseInteractor(ILicenseRepository licenseRepository)
        {
            this.licenseRepository = licenseRepository;
        }

        public async ValueTask Purchase(PurchaseLicenseInputData inputData)
        {
            LicenseEntity entity = new
                (
                    LicenseId: new LicenseId(Guid.NewGuid()),
                    SeriesId: new SeriesId(inputData.SeriesId),
                    AudienceId: new AudienceId(inputData.AudienceId),
                    LicenseType: new LicenseType(inputData.LicenseTypeEnum),
                    ExpirationTime: LicenseDomainService.GetExpirationTime()
                );
            await this.licenseRepository.Insert(entity);
        }
    }
}
