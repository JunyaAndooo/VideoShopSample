using System;

namespace VideoShop.Domain.DomainModels.Exam.ValueObjects
{
    public sealed record ExamId
    {
        public Guid Value { get; }
        public ExamId(Guid value)
        {
            this.Value = value;
        }
    }
}
