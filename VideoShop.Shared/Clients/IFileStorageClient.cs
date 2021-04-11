using System.Threading.Tasks;

namespace VideoShop.Shared.Clients
{
    public interface IFileStorageClient
    {
        public ValueTask<string> Save(string tmpFilePath);
    }
}
