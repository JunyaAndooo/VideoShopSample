using System;

namespace VideoShop.Domain.DomainModels.License.ValueObjects
{
    public record LicenseId
    {
        public Guid Value { get; }
        public LicenseId(Guid value)
        {
            this.Value = value;
        }
    }
}
