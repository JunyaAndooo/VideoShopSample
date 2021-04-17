using System.Threading.Tasks;

namespace VideoShop.Application.Video.ResisterDescription
{
    public interface IResisterDescriptionUseCase
    {
        ValueTask Handle(ResisterDescriptionInputData inputData);
    }
}
