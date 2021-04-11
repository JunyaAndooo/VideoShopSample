using System;

namespace VideoShop.Domain.DomainModels.Audience.ValueObjects
{
    public record AudienceId
    {
        public Guid Value { get; }
        public AudienceId(Guid value)
        {
            this.Value = value;
        }
    }
}
