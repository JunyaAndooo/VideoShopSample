using System;

namespace VideoShop.Domain.Video.ValueObjects
{
    public record VideoId
    {
        public Guid Value { get; }
        public VideoId(Guid value) => this.Value = value;
    }
}
