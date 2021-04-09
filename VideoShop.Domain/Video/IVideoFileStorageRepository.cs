namespace VideoShop.Domain.Video
{
    public interface IVideoFileStorageRepository
    {
        public string Save(string tmpFilePath);
    }
}
