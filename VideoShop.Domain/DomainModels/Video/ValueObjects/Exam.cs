namespace VideoShop.Domain.DomainModels.Video.ValueObjects
{
    public sealed record Exam
    {
        public string Value { get; }
        public Exam(string value)
        {
            this.Value = value;
        }
    }
}
