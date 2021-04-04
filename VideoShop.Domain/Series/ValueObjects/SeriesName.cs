namespace VideoShop.Domain.Series.ValueObjects
{
    public record SeriesName
    {
        public string Value { get; }
        public SeriesName(string value) => this.Value = value;
    }
}
