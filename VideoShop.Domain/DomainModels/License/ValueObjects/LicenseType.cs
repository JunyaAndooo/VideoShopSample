using VideoShop.Shared.Enumerations;

namespace VideoShop.Domain.DomainModels.License.ValueObjects
{
    public record LicenseType
    {
        public LicenseTypeEnum Value { get; }
        public LicenseType(LicenseTypeEnum value)
        {
            this.Value = value;
        }
    }
}
