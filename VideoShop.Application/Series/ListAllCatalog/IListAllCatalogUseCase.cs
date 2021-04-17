using System.Threading.Tasks;

namespace VideoShop.Application.Series.ListAllCatalog
{
    public interface IListAllCatalogUseCase
    {
        ValueTask<ListAllCatalogOutputData> Handle(ListAllCatalogInputData inputData);
    }
}
