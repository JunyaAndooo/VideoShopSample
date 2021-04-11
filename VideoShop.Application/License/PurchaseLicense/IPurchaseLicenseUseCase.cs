using System.Threading.Tasks;

namespace VideoShop.Application.License.PurchaseLicense
{
    public interface IPurchaseLicenseUseCase
    {
        ValueTask Purchase(PurchaseLicenseInputData inputData);
    }
}
