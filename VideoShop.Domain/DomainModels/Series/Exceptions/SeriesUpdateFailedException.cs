using System;

namespace VideoShop.Domain.DomainModels.Series.Exceptions
{
    public class SeriesUpdateFailedException : Exception
    {
        public SeriesUpdateFailedException(string message) : base(message) { }
    }
}
