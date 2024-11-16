using Contact.DataAccess.Models;
using JsonFlatFileDataStore;

namespace Contact.DataAccess.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly IDataStore _jsonDataStore;
        private readonly IDocumentCollection<ContactModel> _contactCollection;
        public ContactRepository(IDataStore jsonDataStore)
        {
            _jsonDataStore = jsonDataStore;
            _contactCollection=_jsonDataStore.GetCollection<ContactModel>();
        }

        public async Task<bool> CreateContact(ContactModel contact)
        {
            var nextId = _contactCollection.GetNextIdValue();
            if (nextId != null && nextId == 0)
            {
                contact.Id = 1;
            }
            else { 
                contact.Id = nextId;
            }
            var result = await _contactCollection.InsertOneAsync(contact);
            return result;
        }

        public async Task<bool> DeleteContact(int id)
        {
            return await _contactCollection.DeleteOneAsync(id);
        }

        public async Task<ContactModel> ReadContact(int id)
        {
            return _contactCollection.AsQueryable().Where(x => x.Id.Equals(id)).FirstOrDefault();
        }

        public async Task<bool> UpdateContact(ContactModel contact)
        {
            return await _contactCollection.UpdateOneAsync(contact.Id, contact);
        }

        public async Task<List<ContactModel>> GetAllContacts()
        {
            return _contactCollection.AsQueryable().ToList();
        }
    }
}
