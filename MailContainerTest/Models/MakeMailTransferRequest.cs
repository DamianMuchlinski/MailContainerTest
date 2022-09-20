using MailContainerTest.Models.Enum;

namespace MailContainerTest.Models
{
    public class MakeMailTransferRequest
    {
        public string SourceMailContainerNumber { get; set; } = null!;
        public string DestinationMailContainerNumber { get; set; } = null!;
        public int NumberOfMailItems { get; set; }
        public DateTime TransferDate { get; set; }   
        public MailType MailType { get; set; }  
    }
}
