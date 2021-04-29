using System;
using System.IO;
using System.Threading.Tasks;
using VideoShop.Shared.Clients;
using VideoShop.Shared.Clients.ValueObjects;

namespace VideoShop.Infrastructure.FileStorageClients
{
    /// <summary>
    /// 今回はCleanArchitectureの勉強だから、実際のファイルアクセス処理、DBアクセス処理は省略しています
    /// </summary>
    public class FileStorageClient : IFileStorageClient
    {
        public ValueTask<(string fileName, MemoryStream stream)> Find(FileConnectKey fileConnectKey)
        {
            throw new NotImplementedException();
        }

        public ValueTask<FileConnectKey> Save(string fileName, Stream stream)
        {
            throw new NotImplementedException();
        }
    }
}
