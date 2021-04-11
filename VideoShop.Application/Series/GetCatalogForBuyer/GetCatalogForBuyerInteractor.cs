using System.Threading.Tasks;
using VideoShop.Domain.DomainModels.Buyer.ValueObjects;
using VideoShop.Domain.QueryModels.Catalog;

namespace VideoShop.Application.Series.GetCatalogForBuyer
{
    public class GetCatalogForBuyerInteractor : IGetCatalogForBuyerUseCase
    {
        private readonly ICatalogQueryService catalogQueryService;

        public GetCatalogForBuyerInteractor(ICatalogQueryService catalogQueryService)
        {
            this.catalogQueryService = catalogQueryService;
        }

        public async ValueTask<GetCatalogForBuyerOutputData> Find(GetCatalogForBuyerInputData inputData)
        {
            SeriesQueryModel[] seriesQueryModels =
                await this.catalogQueryService.FindList(new BuyerId(inputData.BuyerId));
            GetCatalogForBuyerOutputData outputData = new
                (
                    SeriesQueryModels: seriesQueryModels
                );

            return outputData;
        }
    }
}
