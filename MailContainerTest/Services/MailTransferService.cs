using MailContainerTest.Abstract;
using MailContainerTest.Models;
using MailContainerTest.Models.Enum;
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
                MailContainer sourceMailContainer = containerDataStore.GetMailContainer(request.SourceMailContainerNumber);

                ValidateAgainsContainer(request, sourceMailContainer);

                sourceMailContainer.Capacity -= request.NumberOfMailItems;
                containerDataStore.UpdateMailContainer(sourceMailContainer);

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

        private static void ValidateAgainsContainer(MakeMailTransferRequest request, MailContainer sourceMailContainer)
        {
            // TODO -  validate request agains sourceMailContainer -  ded dynamic validator
            // missing matching enum values
            //if (!sourceMailContainer.AllowedMailType.HasFlag(request.MailType))
            //{
            //    //    throw new ArgumentException($"Provided mail type is different for specified number: {request.SourceMailContainerNumber}");
            //}
        }
    }
}
