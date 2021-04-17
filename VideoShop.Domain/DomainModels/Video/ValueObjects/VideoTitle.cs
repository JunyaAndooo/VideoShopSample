namespace VideoShop.Domain.Video.ValueObjects
{
    public sealed record VideoTitle
    {
        public string Value { get; }
        public VideoTitle(string value)
        {
            this.Value = value;
        }
    }
}
