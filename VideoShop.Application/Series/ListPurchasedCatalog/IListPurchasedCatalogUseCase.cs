using System.Threading.Tasks;

namespace VideoShop.Application.Series.ListPurchasedCatalog
{
    public interface IListPurchasedCatalogUseCase
    {
        ValueTask<ListPurchasedCatalogOutputData> Handle(ListPurchasedCatalogInputData inputData);
    }
}
