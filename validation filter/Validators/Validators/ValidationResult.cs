namespace Validators.Validators
{
    public class ValidationResult
    {      
        public List<string> Errors { get; set; } = new();
        public bool IsValid => !Errors.Any();
        
    }
}
