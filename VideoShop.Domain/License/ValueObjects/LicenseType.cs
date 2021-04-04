namespace VideoShop.Domain.License.ValueObjects
{
    public record LicenseType
    {
        public int Value { get; }
        public LicenseType(int value) => this.Value = value;
    }
}
