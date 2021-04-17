using System;

namespace VideoShop.Domain.DomainModels.Series.ValueObjects
{
    public sealed record SeriesId
    {
        public Guid Value { get; }
        public SeriesId(Guid value)
        {
            this.Value = value;
        }
    }
}
