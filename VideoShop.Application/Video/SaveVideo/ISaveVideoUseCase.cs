using System.Threading.Tasks;

namespace VideoShop.Application.Video.SaveVideo
{
    public interface ISaveVideoUseCase
    {
        ValueTask Save(SaveVideoInputData inputData);
    }
}
