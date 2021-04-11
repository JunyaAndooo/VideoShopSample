using System;

namespace VideoShop.Domain.DomainModels.Video.ValueObjects
{
    public record VideoId
    {
        public Guid Value { get; }
        public VideoId(Guid value)
        {
            this.Value = value;
        }
    }
}
