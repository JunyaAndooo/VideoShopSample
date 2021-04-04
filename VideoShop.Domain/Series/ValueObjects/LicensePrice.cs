using System;

namespace VideoShop.Domain.Series.ValueObjects
{
    public record LicensePrice
    {
        public decimal Value { get; }
        public LicensePrice(decimal value)
        {
            if (value < 0)
            {
                throw new ArgumentException("ライセンス価格には0以上の値を入れてください");
            }
            this.Value = value;
        }
    }
}
