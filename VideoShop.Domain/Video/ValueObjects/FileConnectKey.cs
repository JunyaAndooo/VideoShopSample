namespace VideoShop.Domain.Video.ValueObjects
{
    public record FileConnectKey
    {
        public string Value { get; }
        public FileConnectKey(string value) => this.Value = value;
    }
}
