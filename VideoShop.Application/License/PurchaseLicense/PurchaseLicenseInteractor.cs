using System;
using System.Threading.Tasks;
using VideoShop.Domain.DomainModels.Audience.ValueObjects;
using VideoShop.Domain.DomainModels.License;
using VideoShop.Domain.DomainModels.License.Exceptions;
using VideoShop.Domain.DomainModels.License.ValueObjects;
using VideoShop.Domain.DomainModels.Series.ValueObjects;

namespace VideoShop.Application.License.PurchaseLicense
{
    public sealed class PurchaseLicenseInteractor : IPurchaseLicenseUseCase
    {
        private readonly ILicenseRepository licenseRepository;

        public PurchaseLicenseInteractor(ILicenseRepository licenseRepository)
        {
            this.licenseRepository = licenseRepository;
        }

        public async ValueTask<PurchaseLicenseOutputData> Handle(PurchaseLicenseInputData inputData)
        {
            LicenseEntity entity = new
                (
                    LicenseId: new LicenseId(Guid.NewGuid()),
                    SeriesId: new SeriesId(inputData.SeriesId),
                    AudienceId: new AudienceId(inputData.AudienceId),
                    LicenseType: inputData.LicenseType,
                    ExpirationTime: LicenseDomainService.GetExpirationTime()
                );
            bool result = await this.licenseRepository.Insert(entity);
            if (!result)
            {
                throw new LicenseRegistrationFailedException();
            }
            PurchaseLicenseOutputData outputData = new
                (
                    LicenseId: entity.LicenseId.Value
                );

            return outputData;
        }
    }
}
