namespace VideoShop.Domain.DomainModels.Exam.ValueObjects
{
    public sealed record Answer
    {
        public string Value { get; }
        public Answer(string value)
        {
            this.Value = value;
        }
    }
}
