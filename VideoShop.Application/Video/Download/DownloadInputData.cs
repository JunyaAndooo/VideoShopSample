using System;

namespace VideoShop.Application.Video.Download
{
    public sealed record DownloadInputData(Guid AudienceId, Guid VideoId);
}
