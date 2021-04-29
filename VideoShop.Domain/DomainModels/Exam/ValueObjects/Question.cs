namespace VideoShop.Domain.DomainModels.Exam.ValueObjects
{
    public sealed record Question
    {
        public string Value { get; }
        public Question(string value)
        {
            this.Value = value;
        }
    }
}
