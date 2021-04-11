using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VideoShop.Application.Series.CreateSeries;
using VideoShop.Application.Series.SetLicense;

namespace VideoShop.Web.Admin.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SeriesController : ControllerBase
    {
        private readonly ICreateSeriesUseCase createSeriesUseCase;
        private readonly ISetLicenseUseCase setLicenseUseCase;

        public SeriesController(
            ICreateSeriesUseCase createSeriesUseCase,
            ISetLicenseUseCase setLicenseUseCase
        )
        {
            this.createSeriesUseCase = createSeriesUseCase;
            this.setLicenseUseCase = setLicenseUseCase;
        }

        /// <summary>
        /// 新しいシリーズを追加する
        /// </summary>
        /// <param name="seriesName">シリーズ名</param>
        /// <returns>結果</returns>
        [HttpPost(nameof(CreateSeries))]
        public async ValueTask<ActionResult> CreateSeries([FromForm] string seriesName)
        {
            CreateSeriesInputData inputData = new
                (
                    SeriesId: Guid.NewGuid(),
                    SeriesName: seriesName
                );
            await this.createSeriesUseCase.Save(inputData);

            return this.Ok();
        }

        /// <summary>
        /// ライセンス価格を設定する
        /// </summary>
        /// <param name="SeriesId">シリーズID</param>
        /// <param name="LicensePrice">ライセンス価格</param>
        /// <returns>結果</returns>
        [HttpPost(nameof(SetLicense))]
        public async ValueTask<ActionResult> SetLicense([FromForm] Guid seriesId, [FromForm] decimal licensePrice)
        {
            SetLicenseInputData inputData = new
                (
                    SeriesId: seriesId,
                    LicensePrice: licensePrice
                );
            await this.setLicenseUseCase.SetLicense(inputData);

            return this.Ok();
        }
    }
}
