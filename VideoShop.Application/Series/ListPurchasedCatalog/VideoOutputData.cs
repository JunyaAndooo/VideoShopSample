using System;

namespace VideoShop.Application.Series.ListPurchasedCatalog
{
    public sealed record VideoOutputData(
        Guid VideoId,
        Guid SeriesId,
        string VideoTitle,
        Guid ExamId,
        string Description
    );
}
