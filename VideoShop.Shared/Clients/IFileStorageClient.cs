using System.IO;
using System.Threading.Tasks;
using VideoShop.Shared.Clients.ValueObjects;

namespace VideoShop.Shared.Clients
{
    public interface IFileStorageClient
    {
        public ValueTask<FileConnectKey> Save(string fileName, Stream stream);
        public ValueTask<(string fileName, Stream stream)> Find(FileConnectKey fileConnectKey);
    }
}
