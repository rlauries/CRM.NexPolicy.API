namespace CRM.NexPolicy.test
{
    using Xunit;
    using Moq;
    using System.Threading.Tasks;
    using CRM.NexPolicy.src.DataLayer.Models;
    using CRM.NexPolicy.src.DataLayer.Repository.Lead;
    using CRM.NexPolicy.src.ServiceLayer.Lead;
    using static CRM.NexPolicy.src.DataLayer.Enums.EnumExtensions;

    public class LeadServiceTests
    {
        [Fact]
        public async Task RegisterLeadAsync_ValidLead_CallsInsertAndReturnsId()
        {
            // Arrange
            var lead = new LeadModel
            {
                Name = "Carlos",
                LastName = "Perez",
                Email = "carlos@example.com",
                PhoneNumber = "555-1111",
                Source = LeadSource.Website,
                Status = "New"
            };

            var mockRepo = new Mock<ILeadRepository>();
            mockRepo.Setup(r => r.InsertAsync(It.IsAny<LeadModel>())).ReturnsAsync(42); // Simula retorno de ID

            var service = new LeadService(mockRepo.Object);

            // Act
            int result = await service.RegisterLeadAsync(lead);

            // Assert
            Assert.Equal(42, result);
            mockRepo.Verify(r => r.InsertAsync(It.Is<LeadModel>(l => l.Email == "carlos@example.com")), Times.Once);
        }

        [Fact]
        public async Task RegisterLeadAsync_InvalidSource_ThrowsArgumentException()
        {
            // Arrange
            var lead = new LeadModel
            {
                Name = "Test",
                LastName = "User",
                Email = "test@example.com",
                PhoneNumber = "123",
                Source = (LeadSource)999, // Valor inválido
                Status = "New"
            };

            var mockRepo = new Mock<ILeadRepository>();
            var service = new LeadService(mockRepo.Object);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => service.RegisterLeadAsync(lead));
        }
    }

}
