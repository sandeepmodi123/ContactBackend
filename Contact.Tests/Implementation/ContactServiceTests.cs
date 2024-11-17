using Contact.DataAccess.Models;
using Contact.DataAccess.Repository;
using Contact.Service.Implementation;
using Moq;

namespace Contact.Tests.Implementation
{
    [TestClass]
    public class ContactServiceTests
    {
        private MockRepository mockRepository;

        private Mock<IContactRepository> mockContactRepository;

        public ContactServiceTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockContactRepository = this.mockRepository.Create<IContactRepository>();
        }

        private ContactService CreateService()
        {
            return new ContactService(
                this.mockContactRepository.Object);
        }

        [TestMethod]
        public async Task CreateContact_Success()
        {
            // Arrange
            var service = this.CreateService();
            ContactModel contact = new ContactModel();
            //Setup
            this.mockContactRepository.Setup(x=>x.CreateContact(It.IsAny<ContactModel>())).ReturnsAsync(true);
            // Act
            var result = await service.CreateContact(contact);

            // Assert
            Assert.IsTrue(result);
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task DeleteContact_Success()
        {
            // Arrange
            var service = this.CreateService();
            int id = 0;
            //Setup
            this.mockContactRepository.Setup(x => x.DeleteContact(It.IsAny<int>())).ReturnsAsync(true);
            // Act
            var result = await service.DeleteContact(id);

            // Assert
            Assert.IsTrue(result);
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task GetAllContacts_Success_3ResultTest()
        {
            // Arrange
            var service = this.CreateService();
            var mockResult = new List<ContactModel>() { 
            new ContactModel(),
            new ContactModel(),
            new ContactModel()
            };
            //Setup
            this.mockContactRepository.Setup(x => x.GetAllContacts()).ReturnsAsync(mockResult);
            // Act
            var result = await service.GetAllContacts();

            // Assert
            Assert.IsTrue(result.Count > 0);
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task ReadContact_Success()
        {
            // Arrange
            var service = this.CreateService();
            int id = 0;
            //Setup

            this.mockContactRepository.Setup(x => x.ReadContact(It.IsAny<int>())).ReturnsAsync(new ContactModel() { Id=3 });
            // Act
            var result = await service.ReadContact(id);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Id > 0);
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task UpdateContact_Success()
        {
            // Arrange
            var service = this.CreateService();
            ContactModel contact = new ContactModel() { Id=2, FirstName="TEST" };

            //Setup 
            this.mockContactRepository.Setup(x => x.UpdateContact(It.IsAny<ContactModel>())).ReturnsAsync(true);

            // Act
            var result = await service.UpdateContact(contact);

            // Assert
            Assert.IsTrue(result);
            this.mockRepository.VerifyAll();
        }
    }
}
