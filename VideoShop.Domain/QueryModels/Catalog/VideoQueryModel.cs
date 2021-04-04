using VideoShop.Domain.Series.ValueObjects;
using VideoShop.Domain.Video.ValueObjects;

namespace VideoShop.Domain.QueryModels.Catalog
{
    public record VideoQueryModel(
        VideoId VideoId,
        SeriesId SeriesId,
        VideoTitle VideoTitle,
        FileConnectKey FileConnectKey,
        Exam Exam
    )
    {
    }
}
