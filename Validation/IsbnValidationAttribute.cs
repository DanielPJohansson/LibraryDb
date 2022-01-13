using System.Text.RegularExpressions;

namespace LibraryDbWebApi.Validation
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class IsbnValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string isbn = (string)value;

            Regex regex = new Regex(@"^((?:-13)?:?\ )?(?=[0-9]{13}$|(?=(?:[0-9]+[-\ ]){4})[-\ 0-9]{17}$)97[89][-\ ]?[0-9]{1,5}[-\ ]?[0-9]+[-\ ]?[0-9]+[-\ ]?[0-9]$");

            if (!regex.IsMatch(isbn))
            {
                return new ValidationResult("String is not a valid ISBN number");
            }

            return ValidationResult.Success;
        }
    }
}
