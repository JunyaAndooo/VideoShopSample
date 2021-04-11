using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VideoShop.Application.Series.GetCatalogForBuyer;

namespace VideoShop.Web.Buyer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly IGetCatalogForBuyerUseCase getCatalogByBuyerUseCase;

        public CatalogController(IGetCatalogForBuyerUseCase getCatalogByBuyerUseCase)
        {
            this.getCatalogByBuyerUseCase = getCatalogByBuyerUseCase;
        }

        /// <summary>
        /// 視聴者としてカタログを閲覧する
        /// </summary>
        /// <param name="audienceId">視聴者ID</param>
        /// <returns>カタログ情報（シリーズのリスト）</returns>
        [HttpGet(nameof(GetSeries) + "/{audienceId}")]
        public async ValueTask<ActionResult> GetSeries([FromRoute] Guid buyerId)
        {
            GetCatalogForBuyerInputData inputData = new
                (
                    BuyerId: buyerId
                );
            GetCatalogForBuyerOutputData outputData = await this.getCatalogByBuyerUseCase.Find(inputData);

            return this.Ok(outputData);
        }
    }
}
