using Microsoft.AspNetCore.Mvc;
using System;
using VideoShop.Application.Series.CreateSeries;
using VideoShop.Application.Series.SeriesSetLicense;
using VideoShop.Application.Video.SeriesAddVideo;
using VideoShop.Application.Video.SeriesRemoveVideo;

namespace VideoShop.Web.Admin.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SeriesController : ControllerBase
    {
        private readonly ICreateSeriesUseCase createSeriesUseCase;
        private readonly ISeriesAddVideoUseCase seriesAddVideoUseCase;
        private readonly ISeriesRemoveVideoUseCase seriesRemoveVideoUseCase;
        private readonly ISeriesSetLicenseUseCase seriesSetLicenseUseCase;

        public SeriesController(
            ICreateSeriesUseCase createSeriesUseCase,
            ISeriesAddVideoUseCase seriesAddVideoUseCase,
            ISeriesRemoveVideoUseCase seriesRemoveVideoUseCase,
            ISeriesSetLicenseUseCase seriesSetLicenseUseCase
        )
        {
            this.createSeriesUseCase = createSeriesUseCase;
            this.seriesAddVideoUseCase = seriesAddVideoUseCase;
            this.seriesRemoveVideoUseCase = seriesRemoveVideoUseCase;
            this.seriesSetLicenseUseCase = seriesSetLicenseUseCase;
        }

        /// <summary>
        /// 新しいシリーズを追加する
        /// </summary>
        /// <param name="seriesName">シリーズ名</param>
        /// <returns>結果</returns>
        [HttpPost(nameof(CreateSeries))]
        public IActionResult CreateSeries([FromForm] string seriesName)
        {
            CreateSeriesInputData inputData = new(
                SeriesId:
                    Guid.NewGuid(),
                SeriesName:
                    seriesName);
            this.createSeriesUseCase.Save(inputData);
            return Ok();
        }

        /// <summary>
        /// シリーズに動画を公開する
        /// </summary>
        /// <param name="SeriesId">シリーズID</param>
        /// <param name="VideoId">動画ID</param>
        /// <returns>結果</returns>
        [HttpPost(nameof(SeriesAddVideo))]
        public IActionResult SeriesAddVideo([FromForm] Guid SeriesId, [FromForm] Guid VideoId)
        {
            SeriesAddVideoInputData inputData = new(
                SeriesId:
                    SeriesId,
                VideoId:
                    VideoId);
            this.seriesAddVideoUseCase.Add(inputData);
            return Ok();
        }

        /// <summary>
        /// シリーズから動画を削除する
        /// </summary>
        /// <param name="SeriesId">シリーズID</param>
        /// <param name="VideoId">動画ID</param>
        /// <returns>結果</returns>
        [HttpPost(nameof(SeriesRemoveVideo))]
        public IActionResult SeriesRemoveVideo([FromForm] Guid SeriesId, [FromForm] Guid VideoId)
        {
            SeriesRemoveVideoInputData inputData = new(
                SeriesId:
                    SeriesId,
                VideoId:
                    VideoId);
            this.seriesRemoveVideoUseCase.Remove(inputData);
            return Ok();
        }

        /// <summary>
        /// ライセンス価格を設定する
        /// </summary>
        /// <param name="SeriesId">シリーズID</param>
        /// <param name="LicensePrice">ライセンス価格</param>
        /// <returns>結果</returns>
        [HttpPost(nameof(SeriesSetLicense))]
        public IActionResult SeriesSetLicense([FromForm] Guid SeriesId, [FromForm] decimal LicensePrice)
        {
            SeriesSetLicenseInputData inputData = new(
                SeriesId:
                    SeriesId,
                LicensePrice:
                    LicensePrice);
            this.seriesSetLicenseUseCase.SetLicense(inputData);
            return Ok();
        }
    }
}
