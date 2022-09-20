using MailContainerTest.Models;
using MailContainerTest.Models.Enum;
using MailContainerTest.Services.Validation.Custom;

namespace MailContainerTest.Services.Validation.Fluent
{
    public class MakeMailTransferRequestCustomValidator : IMyValidator<MakeMailTransferRequest>
    {
        public bool Validate(MakeMailTransferRequest request)
        {
            switch (request.MailType)
            {
                case MailType.StandardLetter or MailType.LargeLetter or MailType.SmallParcel : return true;
                    default: return false;
            }
        }
    }
}
