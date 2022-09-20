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
            containerDataStore.Setup(x=> x.GetMailContainer(It.IsAny<string>())).Returns(new MailContainer());
            
        }

        [Fact]
        public void MakeMailTransfer_when_request_is_proper_should_transfer()
        {
            // Arrange
            var request =  new MakeMailTransferRequest { };
            var sut = new MailTransferService(containerDataStore.Object, new NullLogger<MailTransferService>());

            // Act
            var result = sut.MakeMailTransfer(request);

            // Assert

            using (new AssertionScope())
            {
                result.Success.Should().Be(true);
            }
        }
    }
}