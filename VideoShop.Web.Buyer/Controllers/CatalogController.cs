using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VideoShop.Application.Series.ListAllCatalog;

namespace VideoShop.Web.Buyer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly IListAllCatalogUseCase listAllCatalogUseCase;

        public CatalogController(IListAllCatalogUseCase listAllCatalogUseCase)
        {
            this.listAllCatalogUseCase = listAllCatalogUseCase;
        }

        /// <summary>
        /// 視聴者としてカタログを閲覧する
        /// </summary>
        /// <param name="audienceId">視聴者ID</param>
        /// <returns>カタログ情報（シリーズのリスト）</returns>
        [HttpGet(nameof(GetSeries) + "/{audienceId}")]
        public async ValueTask<ActionResult> GetSeries([FromRoute] Guid buyerId)
        {
            ListAllCatalogInputData inputData = new
                (
                    BuyerId: buyerId
                );
            ListAllCatalogOutputData outputData = await this.listAllCatalogUseCase.Handle(inputData);

            return this.Ok(outputData);
        }
    }
}
