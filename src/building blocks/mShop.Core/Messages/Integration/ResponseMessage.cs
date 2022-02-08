using FluentValidation.Results;

namespace mShop.Core.Messages.Integration
{
    public class ResponseMessage : Message
    {
        public ValidationResult ValidationResult { get; set; }
        public ResponseMessage(ValidationResult validationResult)
        {
            ValidationResult = validationResult;    
        }
    }
}
