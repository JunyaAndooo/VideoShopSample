using System;

namespace VideoShop.Domain.Audience.ValueObjects
{
    public record AudienceId
    {
        public Guid Value { get; }
        public AudienceId(Guid value) => this.Value = value;
    }
}
