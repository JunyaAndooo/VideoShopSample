using VideoShop.Domain.DomainModels.Exam.ValueObjects;
using VideoShop.Domain.DomainModels.Series.ValueObjects;
using VideoShop.Domain.DomainModels.Video.ValueObjects;
using VideoShop.Domain.Video.ValueObjects;
using VideoShop.Shared.Clients.ValueObjects;

namespace VideoShop.Domain.QueryModels.Catalog
{
    public sealed record VideoQueryModel(
        VideoId VideoId,
        SeriesId SeriesId,
        VideoTitle VideoTitle,
        FileConnectKey FileConnectKey,
        ExamId ExamId,
        Description Description
    );
}
