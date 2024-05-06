namespace Validators.Validators
{
    public interface IValidator<T>
    {
        public Task<ValidationResult> ValidateAsync(T value);
    }
}
