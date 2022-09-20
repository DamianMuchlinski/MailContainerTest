using MailContainerTest.Models.Enum;

namespace MailContainerTest.Models
{
    public class MailContainer
    {
        public string MailContainerNumber { get; set; } = null!;
        public int Capacity { get; set; }   
        public MailContainerStatus Status { get; set; }
        public AllowedMailType AllowedMailType { get; set; }

    }
}
