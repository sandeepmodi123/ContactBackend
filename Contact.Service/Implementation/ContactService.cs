using Contact.DataAccess.Models;
using Contact.DataAccess.Repository;
using Contact.Service.Contract;

namespace Contact.Service.Implementation
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        public ContactService(IContactRepository contactRepository) 
        {
            _contactRepository = contactRepository;
        } 
        public async Task<bool> CreateContact(ContactModel contact)
        {
            return await _contactRepository.CreateContact(contact);
        }

        public async Task<bool> DeleteContact(string id)
        {
            return await _contactRepository.DeleteContact(id);
        }

        public async Task<List<ContactModel>> GetAllContacts()
        {
            return await _contactRepository.GetAllContacts();
        }

        public async Task<ContactModel> ReadContact(int id)
        {
            return await _contactRepository.ReadContact(id);
        }

        public async Task<bool> UpdateContact(ContactModel contact)
        {
            return await _contactRepository.UpdateContact(contact);
        }
    }
}
