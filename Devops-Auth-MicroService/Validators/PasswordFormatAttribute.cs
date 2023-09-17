using System.ComponentModel.DataAnnotations;

namespace Devops_Auth_MicroService.Validators
{
    public class PasswordFormatAttribute : ValidationAttribute
    {
        private readonly int _maxChars;
        public PasswordFormatAttribute(int MaxChars) : base("Password should be greater than {0} characters") {
            _maxChars = MaxChars;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string val = (string)value;
            if(string.IsNullOrEmpty(val) || val.Length < 8)
            {
                return new ValidationResult(FormatErrorMessage(_maxChars.ToString()));
            }

            return ValidationResult.Success;
        }
    }
}
