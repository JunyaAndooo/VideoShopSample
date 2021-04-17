using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VideoShop.Application.Series.ListPurchasedCatalog;

namespace VideoShop.Web.Audience.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly IListPurchasedCatalogUseCase listPurchasedCatalogUseCase;

        public CatalogController(IListPurchasedCatalogUseCase listPurchasedCatalogUseCase)
        {
            this.listPurchasedCatalogUseCase = listPurchasedCatalogUseCase;
        }

        /// <summary>
        /// 視聴者としてカタログを閲覧する（購入済みのカタログを取得すると解釈）
        /// </summary>
        /// <param name="audienceId">視聴者ID</param>
        /// <returns>カタログ情報（シリーズのリスト）</returns>
        [HttpGet(nameof(GetSeries) + "/{audienceId}")]
        public async ValueTask<ActionResult> GetSeries([FromRoute] Guid audienceId)
        {
            ListPurchasedCatalogInputData inputData = new
                (
                    AudienceId: audienceId
                );
            ListPurchasedCatalogOutputData outputData = await this.listPurchasedCatalogUseCase.Handle(inputData);

            return this.Ok(outputData);
        }
    }
}
