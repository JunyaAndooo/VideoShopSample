using System.Threading.Tasks;

namespace VideoShop.Application.License.PurchaseLicense
{
    public interface IPurchaseLicenseUseCase
    {
        ValueTask<PurchaseLicenseOutputData> Handle(PurchaseLicenseInputData inputData);
    }
}
