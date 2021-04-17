using System.Threading.Tasks;

namespace VideoShop.Application.Video.ResiterExam
{
    public interface IResiterExamUseCase
    {
        ValueTask Handle(ResiterExamInputData inputData);
    }
}
