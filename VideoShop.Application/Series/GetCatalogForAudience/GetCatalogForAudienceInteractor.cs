using System.Threading.Tasks;
using VideoShop.Domain.DomainModels.Audience.ValueObjects;
using VideoShop.Domain.QueryModels.Catalog;

namespace VideoShop.Application.Series.GetCatalogForAudience
{
    public class GetCatalogForAudienceInteractor : IGetCatalogForAudienceUseCase
    {
        private readonly ICatalogQueryService catalogQueryService;

        public GetCatalogForAudienceInteractor(ICatalogQueryService catalogQueryService)
        {
            this.catalogQueryService = catalogQueryService;
        }

        public async ValueTask<GetCatalogForAudienceOutputData> Find(GetCatalogForAudienceInputData inputData)
        {
            SeriesQueryModel[] seriesQueryModels =
                await this.catalogQueryService.FindList(new AudienceId(inputData.AudienceId));
            GetCatalogForAudienceOutputData outputData = new
                (
                    SeriesQueryModels: seriesQueryModels
                );

            return outputData;
        }
    }
}
