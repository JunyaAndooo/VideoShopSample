namespace VideoShop.Domain.Video.ValueObjects
{
    public record Description
    {
        public string Value { get; }
        public Description(string value) => this.Value = value;
    }
}
