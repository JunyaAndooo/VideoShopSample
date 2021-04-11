using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VideoShop.Application.Series.GetCatalogForAudience;

namespace VideoShop.Web.Audience.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly IGetCatalogForAudienceUseCase getCatalogForAudienceUseCase;

        public CatalogController(IGetCatalogForAudienceUseCase getCatalogForAudienceUseCase)
        {
            this.getCatalogForAudienceUseCase = getCatalogForAudienceUseCase;
        }

        /// <summary>
        /// 視聴者としてカタログを閲覧する
        /// </summary>
        /// <param name="audienceId">視聴者ID</param>
        /// <returns>カタログ情報（シリーズのリスト）</returns>
        [HttpGet(nameof(GetSeries) + "/{audienceId}")]
        public async ValueTask<ActionResult> GetSeries([FromRoute] Guid audienceId)
        {
            GetCatalogForAudienceInputData inputData = new
                (
                    AudienceId: audienceId
                );
            GetCatalogForAudienceOutputData outputData = await this.getCatalogForAudienceUseCase.Find(inputData);

            return this.Ok(outputData);
        }
    }
}
