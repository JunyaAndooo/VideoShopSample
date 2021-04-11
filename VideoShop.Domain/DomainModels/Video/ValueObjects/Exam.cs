namespace VideoShop.Domain.DomainModels.Video.ValueObjects
{
    public record Exam
    {
        public string Value { get; }
        public Exam(string value)
        {
            this.Value = value;
        }
    }
}
