
namespace Ecommerce.Api.validator.Error
{
    public class CustomerValidatorFailure
    {
        public string PropertyName { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;

        public CustomerValidatorFailure(string propertyName, string errorMessage)
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
        }
    }
}
