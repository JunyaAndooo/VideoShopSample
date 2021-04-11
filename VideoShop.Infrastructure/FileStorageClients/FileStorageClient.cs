using System;
using System.Threading.Tasks;
using VideoShop.Shared.Clients;

namespace VideoShop.Infrastructure.FileStorageClients
{
    public class FileStorageClient : IFileStorageClient
    {
        public ValueTask<string> Save(string tmpFilePath)
        {
            throw new NotImplementedException();
        }
    }
}
