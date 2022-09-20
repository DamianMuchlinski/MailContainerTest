using MailContainerTest.Models;

namespace MailContainerTest.Abstract
{
    public interface IContainerDataStore
    {
        MailContainer GetMailContainer(string mailContainerNumber);
        void UpdateMailContainer(MailContainer mailContainer);
    }
}