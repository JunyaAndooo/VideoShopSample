using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VideoShop.Application.License.PurchaseLicense;
using VideoShop.Domain.DomainModels.License.Enumerations;

namespace VideoShop.Web.Buyer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LicenseController : ControllerBase
    {
        private readonly IPurchaseLicenseUseCase purchaseLicenseUseCase;

        public LicenseController(IPurchaseLicenseUseCase purchaseLicenseUseCase)
        {
            this.purchaseLicenseUseCase = purchaseLicenseUseCase;
        }

        /// <summary>
        /// ライセンスを購入する
        /// </summary>
        /// <param name="audienceId">視聴者ID</param>
        /// <param name="SeriesId">シリーズID</param>
        /// <param name="licenseType">ライセンスタイプ</param>
        /// <returns>結果</returns>
        [HttpPost(nameof(PurchaseLicense) + "/{audienceId}")]
        public async ValueTask<ActionResult> PurchaseLicense([FromRoute] Guid audienceId, [FromForm] Guid seriesId, [FromForm] LicenseType licenseType)
        {
            PurchaseLicenseInputData inputData = new
                (
                    AudienceId: audienceId,
                    SeriesId: seriesId,
                    LicenseType: licenseType
                );

            await this.purchaseLicenseUseCase.Handle(inputData);

            return this.Ok();
        }
    }
}
