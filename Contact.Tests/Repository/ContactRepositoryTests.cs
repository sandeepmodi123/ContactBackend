using Contact.DataAccess.Models;
using Contact.DataAccess.Repository;
using JsonFlatFileDataStore;
using Moq;
using System.Reflection.Metadata.Ecma335;

namespace Contact.Tests.Repository
{
    [TestClass]
    public class ContactRepositoryTests
    {
        private MockRepository mockRepository;

        private Mock<IDataStore> mockDataStore;
        private Mock<IDocumentCollection<ContactModel>> mockCollection;

        public ContactRepositoryTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockDataStore = this.mockRepository.Create<IDataStore>();
        }

        private ContactRepository CreateContactRepository()
        {
            IDocumentCollection<ContactModel> item = null;
            this.mockDataStore.Setup(x => x.GetCollection<ContactModel>(It.IsAny<string>())).Returns(item);
            return new ContactRepository(
                this.mockDataStore.Object);
        }

        [TestMethod]
        public async Task CreateContact_Success()
        {
            // Arrange
            var contactRepository = this.CreateContactRepository();
            ContactModel contact = null;

            // Act
            var result = await contactRepository.CreateContact(contact);

            // Assert
            Assert.IsTrue(false);
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task DeleteContact_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var contactRepository = this.CreateContactRepository();
            int id = 0;

            // Act
            var result = await contactRepository.DeleteContact(
                id);

            // Assert
            //Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task ReadContact_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var contactRepository = this.CreateContactRepository();
            int id = 0;

            // Act
            var result = await contactRepository.ReadContact(
                id);

            // Assert
            //Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task UpdateContact_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var contactRepository = this.CreateContactRepository();
            ContactModel contact = null;

            // Act
            var result = await contactRepository.UpdateContact(
                contact);

            // Assert
            //Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task GetAllContacts_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var contactRepository = this.CreateContactRepository();

            // Act
            var result = await contactRepository.GetAllContacts();

            // Assert
            //Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
