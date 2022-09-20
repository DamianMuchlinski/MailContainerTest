using FluentValidation;
using MailContainerTest.Models;
using MailContainerTest.Models.Enum;

namespace MailContainerTest.Services.Validation.Fluent
{
    public class StandardLetterRequestValidator : AbstractValidator<MailType>
    {
        public StandardLetterRequestValidator()
        {
            // could be expanded...
        }
    }
}
