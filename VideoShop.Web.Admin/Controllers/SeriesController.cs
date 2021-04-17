using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VideoShop.Application.Series.CreateSeries;
using VideoShop.Application.Series.SetLicense;
using VideoShop.Domain.DomainModels.Series.Exceptions;

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
                    SeriesName: seriesName
                );

            try
            {
                CreateSeriesOutputData outputData = await this.createSeriesUseCase.Handle(inputData);
                return this.Ok(outputData);
            }
            catch (SeriesRegistrationFailedException)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "予期しないエラーが発生しました");
            }
        }

        /// <summary>
        /// ライセンス価格を設定する
        /// </summary>
        /// <param name="SeriesId">シリーズID</param>
        /// <param name="LicensePrice">ライセンス価格</param>
        /// <returns>結果</returns>
        [HttpPut(nameof(SetLicense))]
        public async ValueTask<ActionResult> SetLicense([FromForm] Guid seriesId, [FromForm] decimal licensePrice)
        {
            SetLicenseInputData inputData = new
                (
                    SeriesId: seriesId,
                    LicensePrice: licensePrice
                );

            try
            {
                await this.setLicenseUseCase.Handle(inputData);
                return this.Ok();
            }
            catch (SeriesNotFoundException)
            {
                return this.NotFound();
            }
            catch (SeriesUpdateFailedException)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "予期しないエラーが発生しました");
            }
        }
    }
}
