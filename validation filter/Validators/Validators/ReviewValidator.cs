using Validators.Model;

namespace Validators.Validators
{
    public class ReviewValidator : IValidator<Review>
    {
        public Task<ValidationResult> ValidateAsync(Review value)
        {
            var validationResults = new ValidationResult();

            if (string.IsNullOrEmpty(value.Title))
            {
                validationResults.Errors.Add("Review title can not be null or empty");
            }

            if (string.IsNullOrEmpty(value.Description))
            {
                validationResults.Errors.Add("Review description can not be null or empty");
            }

            if (!DateTime.TryParse(value.CreatedAt,out _))            
            {
                validationResults.Errors.Add("Review created is not valid date");
            }

            return  Task.FromResult(validationResults);
        }
    }
}
