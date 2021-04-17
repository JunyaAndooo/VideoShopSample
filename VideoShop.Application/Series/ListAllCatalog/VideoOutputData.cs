using System;

namespace VideoShop.Application.Series.ListAllCatalog
{
    public sealed record VideoOutputData(
        Guid VideoId,
        Guid SeriesId,
        string VideoTitle,
        string Exam,
        string Description
    );
}
