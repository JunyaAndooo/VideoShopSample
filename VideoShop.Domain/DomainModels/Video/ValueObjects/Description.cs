namespace VideoShop.Domain.DomainModels.Video.ValueObjects
{
    public sealed record Description
    {
        public string Value { get; }
        public Description(string value)
        {
            this.Value = value;
        }
    }
}
