namespace Domain.Validation
{
    public interface IValidator<T>
    {
        ValidationResult Validate(T entity);
    }

    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public List<string> Errors { get; set; }

        public ValidationResult()
        {
            IsValid = true;
            Errors = new List<string>();
        }
    }
}