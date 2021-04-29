using System;
using System.Threading.Tasks;
using VideoShop.Domain.DomainModels.Audience.ValueObjects;
using VideoShop.Domain.DomainModels.License;
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
            /*
             * ライセンスをユーザの購入処理するロジックをここで行うが、今回省略
             */

            LicenseEntity license = new
                (
                    LicenseId: new LicenseId(Guid.NewGuid()),
                    SeriesId: new SeriesId(inputData.SeriesId),
                    AudienceId: new AudienceId(inputData.AudienceId),
                    LicenseType: inputData.LicenseType,
                    ExpirationTime: LicenseDomainService.GetExpirationTime()
                );

            await this.licenseRepository.Insert(license);

            PurchaseLicenseOutputData outputData = new
                (
                    LicenseId: license.LicenseId.Value
                );

            return outputData;
        }
    }
}
