namespace VideoShop.Domain.Video.ValueObjects
{
    public record VideoTitle
    {
        public string Value { get; }
        public VideoTitle(string value) => this.Value = value;
    }
}
