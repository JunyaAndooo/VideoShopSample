using System.Linq;
using System.Threading.Tasks;
using VideoShop.Domain.DomainModels.Buyer.ValueObjects;
using VideoShop.Domain.QueryModels.Catalog;

namespace VideoShop.Application.Series.ListAllCatalog
{
    public sealed class ListAllCatalogInteractor : IListAllCatalogUseCase
    {
        private readonly ICatalogQueryService catalogQueryService;

        public ListAllCatalogInteractor(ICatalogQueryService catalogQueryService)
        {
            this.catalogQueryService = catalogQueryService;
        }

        public async ValueTask<ListAllCatalogOutputData> Handle(ListAllCatalogInputData inputData)
        {
            SeriesQueryModel[] seriesList =
                await this.catalogQueryService.FindList(new BuyerId(inputData.BuyerId));
            ListAllCatalogOutputData outputData = new
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
