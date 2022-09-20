using MailContainerTest.Models;

namespace MailContainerTest.Abstract
{
    public interface IMailTransferService
    {
        MakeMailTransferResult MakeMailTransfer(MakeMailTransferRequest request);
    }
}