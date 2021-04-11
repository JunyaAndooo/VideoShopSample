using System;

namespace VideoShop.Domain.DomainModels.Buyer.ValueObjects
{
    public record BuyerId
    {
        public Guid Value { get; }
        public BuyerId(Guid value)
        {
            this.Value = value;
        }
    }
}
