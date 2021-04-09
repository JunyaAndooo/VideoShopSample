using Microsoft.AspNetCore.Mvc;
using System;
using VideoShop.Application.Series.GetSeries;

namespace VideoShop.Web.Audience.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly IGetSeriesUseCase getSeriesUseCase;

        public CatalogController(IGetSeriesUseCase getSeriesUseCase)
        {
            this.getSeriesUseCase = getSeriesUseCase;
        }

        /// <summary>
        /// 視聴者としてカタログを閲覧する
        /// </summary>
        /// <param name="audienceId">視聴者ID</param>
        /// <returns>カタログ情報（シリーズのリスト）</returns>
        [HttpGet(nameof(GetSeries) + "/{audienceId}")]
        public IActionResult GetSeries([FromRoute] Guid audienceId)
        {
            GetSeriesInputData inputData = new(
                AudienceId:
                    audienceId);
            GetSeriesOutputData outputData = this.getSeriesUseCase.Find(inputData);
            return this.Ok(outputData);
        }
    }
}
