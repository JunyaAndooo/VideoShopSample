using System;

namespace VideoShop.Domain.DomainModels.Video.Exceptions
{
    public sealed class VideoUpdateFailedException : Exception
    {
        public VideoUpdateFailedException(string message) : base(message) { }
    }
}
