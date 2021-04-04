namespace VideoShop.Domain.Video
{
    public interface IFileStorageRepository
    {
        public string Save(string tmpFilePath);
    }
}
