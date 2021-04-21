using System.Linq;
using System.Threading.Tasks;
using VideoShop.Domain.DomainModels.Audience.ValueObjects;
using VideoShop.Domain.QueryModels.Catalog;

namespace VideoShop.Application.Series.ListPurchasedCatalog
{
    public sealed class ListPurchasedCatalogInteractor : IListPurchasedCatalogUseCase
    {
        private readonly ICatalogQueryService catalogQueryService;

        public ListPurchasedCatalogInteractor(ICatalogQueryService catalogQueryService)
        {
            this.catalogQueryService = catalogQueryService;
        }

        public async ValueTask<ListPurchasedCatalogOutputData> Handle(ListPurchasedCatalogInputData inputData)
        {
            SeriesQueryModel[] seriesList =
                await this.catalogQueryService.FindPurchasedList(new AudienceId(inputData.AudienceId));
            ListPurchasedCatalogOutputData outputData = new
                (
                    SeriesList:
                        seriesList.Select(s =>
                            new SeriesOutputData(
                                VideoOutputDatas:
                                    s.Videos.Select(v =>
                                        new VideoOutputData(
                                            VideoId: v.VideoId.Value,
                                            SeriesId: v.SeriesId.Value,
                                            VideoTitle: v.VideoTitle.Value,
                                            Exam: v.Exam.Value,
                                            Description: v.Description.Value
                                        )
                                    ).ToArray()
                                )
                        ).ToArray()
                );

            return outputData;
        }
    }
}
