using FluentValidation;
using MailContainerTest.Models;

namespace MailContainerTest.Services.Validation.Fluent
{
    public class MakeMailTransferRequestValidator : AbstractValidator<MakeMailTransferRequest>
    {
        public MakeMailTransferRequestValidator()
        {
            // could be expanded...
            RuleFor(x => x.SourceMailContainerNumber).NotEmpty();

            RuleFor(x => x.MailType).SetValidator(new StandardLetterRequestValidator());
        }
    }
}
