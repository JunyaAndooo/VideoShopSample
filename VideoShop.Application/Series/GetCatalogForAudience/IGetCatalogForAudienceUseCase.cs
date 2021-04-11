using System.Threading.Tasks;

namespace VideoShop.Application.Series.GetCatalogForAudience
{
    public interface IGetCatalogForAudienceUseCase
    {
        ValueTask<GetCatalogForAudienceOutputData> Find(GetCatalogForAudienceInputData inputData);
    }
}
