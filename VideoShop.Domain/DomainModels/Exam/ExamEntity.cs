using VideoShop.Domain.DomainModels.Exam.ValueObjects;

namespace VideoShop.Domain.DomainModels.Exam
{
    public sealed record ExamEntity(
        ExamId ExamId,
        Question Question,
        Answer Answer
    );
}
