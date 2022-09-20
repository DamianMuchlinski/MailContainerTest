using MailContainerTest.Abstract;
using MailContainerTest.Models;
using Microsoft.Extensions.Logging;

namespace MailContainerTest.Services
{
    public class MailTransferService : IMailTransferService
    {
        private readonly IContainerDataStore containerDataStore;
        private readonly ILogger<MailTransferService> logger;

        public MailTransferService(
            IContainerDataStore containerDataStore,
            ILogger<MailTransferService> logger)
        {
            this.containerDataStore = containerDataStore;
            this.logger = logger;
        }

        public MakeMailTransferResult MakeMailTransfer(
            MakeMailTransferRequest request)
        {
            try
            {
                MailContainer mailContainer = containerDataStore.GetMailContainer(request.SourceMailContainerNumber);
                mailContainer.Capacity -= request.NumberOfMailItems;
                containerDataStore.UpdateMailContainer(mailContainer);

                MailContainer mailContainerDest = containerDataStore.GetMailContainer(request.DestinationMailContainerNumber);
                mailContainerDest.Capacity += request.NumberOfMailItems;
                containerDataStore.UpdateMailContainer(mailContainerDest);

                return new MakeMailTransferResult { Success = true };
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Something terrible happend");
                return new MakeMailTransferResult { Success = false };
            }
        }
    }
}
