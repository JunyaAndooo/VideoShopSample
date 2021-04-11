namespace VideoShop.Domain.DomainModels.Video.ValueObjects
{
    public record FileConnectKey
    {
        public string Value { get; }
        public FileConnectKey(string value)
        {
            this.Value = value;
        }
    }
}
