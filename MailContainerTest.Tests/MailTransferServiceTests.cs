using FluentAssertions;
using FluentAssertions.Execution;
using MailContainerTest.Abstract;
using MailContainerTest.Models;
using MailContainerTest.Services;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Xunit;

namespace MailContainerTest.Tests
{
    public class MailTransferServiceTests 
    {
        private readonly Mock<IContainerDataStore> containerDataStore;

        public MailTransferServiceTests()
        {
            containerDataStore = new Mock<IContainerDataStore>();
        }

        [Fact]
        public void MakeMailTransfer_when_request_is_proper_should_transfer()
        {
            // Arrange
            var mailType = Models.Enum.MailType.StandardLetter;

            var sourceMailContainerNumber = "1";
            var sourceCapacity = 30;
            
            var destMailContainerNumber = "2";
            var destCapacity = 0;

            var numberOfMailsinRequest = 20;

            containerDataStore
                .Setup(x => x.GetMailContainer(sourceMailContainerNumber))
                .Returns(new MailContainer() { AllowedMailType = Models.Enum.AllowedMailType.StandardLetter,  MailContainerNumber = sourceMailContainerNumber, Capacity= sourceCapacity });
            
            containerDataStore
                .Setup(x => x.GetMailContainer(destMailContainerNumber))
                .Returns(new MailContainer() { MailContainerNumber = destMailContainerNumber, Capacity = destCapacity });

            var request = new MakeMailTransferRequest {
                MailType = mailType,
                DestinationMailContainerNumber = destMailContainerNumber, 
                SourceMailContainerNumber = sourceMailContainerNumber,
                NumberOfMailItems = numberOfMailsinRequest,
            };
            
            var sut = new MailTransferService(containerDataStore.Object, new NullLogger<MailTransferService>());

            // Act
            var result = sut.MakeMailTransfer(request);

            // Assert
            using (new AssertionScope())
            {
                result.Success.Should().Be(true);

                containerDataStore
                    .Verify(x => x.UpdateMailContainer(
                        It.Is<MailContainer>(x=> x.MailContainerNumber == sourceMailContainerNumber && x.Capacity == sourceCapacity - numberOfMailsinRequest)), Times.Once);

                containerDataStore
                    .Verify(x => x.UpdateMailContainer(
                        It.Is<MailContainer>(x => x.MailContainerNumber == destMailContainerNumber && x.Capacity == destCapacity + numberOfMailsinRequest)), Times.Once);
            }
        }
    }
}