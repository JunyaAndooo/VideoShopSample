namespace VideoShop.Shared.Clients.ValueObjects
{
    public sealed record FileConnectKey
    {
        public string Value { get; }
        public FileConnectKey(string value)
        {
            this.Value = value;
        }
    }
}
