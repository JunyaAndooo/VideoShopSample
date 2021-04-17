namespace VideoShop.Domain.DomainModels.Series.ValueObjects
{
    public sealed record SeriesName
    {
        public string Value { get; }
        public SeriesName(string value)
        {
            this.Value = value;
        }
    }
}
