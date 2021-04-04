using System;
using VideoShop.Domain.Audience.ValueObjects;
using VideoShop.Domain.License;
using VideoShop.Domain.License.ValueObjects;
using VideoShop.Domain.Series.ValueObjects;

namespace VideoShop.Application.License.PurchaseLicense
{
    public class PurchaseLicenseInteractor : IPurchaseLicenseUseCase
    {
        private readonly ILicenseRepository licenseRepository;
        private readonly LicenseDomainService licenseDomainService;

        public PurchaseLicenseInteractor(
            ILicenseRepository licenseRepository,
            LicenseDomainService licenseDomainService
        )
        {
            this.licenseRepository = licenseRepository;
            this.licenseDomainService = licenseDomainService;
        }

        public void Purchase(PurchaseLicenseInputData inputData)
        {
            LicenseEntity entity = new(
                LicenseId:
                    new LicenseId(Guid.NewGuid()),
                SeriesId:
                    new SeriesId(inputData.SeriesId),
                AudienceId:
                    new AudienceId(inputData.AudienceId),
                LicenseType:
                    new LicenseType(inputData.LicenseType),
                ExpirationTime:
                    this.licenseDomainService.GetExpirationTime());
            this.licenseRepository.Insert(entity);
        }
    }
}
