using System.Threading.Tasks;

namespace VideoShop.Application.Series.GetCatalogForBuyer
{
    public interface IGetCatalogForBuyerUseCase
    {
        ValueTask<GetCatalogForBuyerOutputData> Find(GetCatalogForBuyerInputData inputData);
    }
}
