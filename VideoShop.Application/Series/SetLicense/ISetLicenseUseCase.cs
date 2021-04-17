using System.Threading.Tasks;

namespace VideoShop.Application.Series.SetLicense
{
    public interface ISetLicenseUseCase
    {
        ValueTask Handle(SetLicenseInputData inputData);
    }
}
