using VideoShop.Domain.Audience.ValueObjects;
using VideoShop.Domain.QueryModels.Catalog;

namespace VideoShop.Application.Series.GetSeries
{
    public class GetSeriesInteractor : IGetSeriesUseCase
    {
        private readonly ICatalogQueryService catalogQueryService;

        public GetSeriesInteractor(ICatalogQueryService catalogQueryService)
        {
            this.catalogQueryService = catalogQueryService;
        }

        public GetSeriesOutputData Find(GetSeriesInputData inputData)
        {
            SeriesQueryModel[] seriesQueryModels = this.catalogQueryService.FindList(new AudienceId(inputData.AudienceId));
            GetSeriesOutputData outputData = new(
                SeriesQueryModels:
                    seriesQueryModels);
            return outputData;
        }
    }
}
