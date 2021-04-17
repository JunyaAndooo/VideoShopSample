using System;

namespace VideoShop.Domain.DomainModels.Video.ValueObjects
{
    public sealed record VideoId
    {
        public Guid Value { get; }
        public VideoId(Guid value)
        {
            this.Value = value;
        }
    }
}
