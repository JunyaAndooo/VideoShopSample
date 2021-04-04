using System;

namespace VideoShop.Domain.Series.ValueObjects
{
    public record SeriesId
    {
        public Guid Value { get; }
        public SeriesId(Guid value) => this.Value = value;
    }
}
