using Contact.DataAccess.Models;
using JsonFlatFileDataStore;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;

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
            return _contactCollection.AsQueryable().OrderBy(x=>x.FirstName).ToList();
        }

        public async Task<List<ContactModel>> SearchContacts(QueryModel query)
        {
            List<ContactModel> result = new List<ContactModel>();
            if (!string.IsNullOrEmpty(query.SearchItem))
            {
                result = _contactCollection.AsQueryable().Where(p => p.FirstName.Contains(query.SearchItem, StringComparison.OrdinalIgnoreCase)
                                       || p.LastName.Contains(query.SearchItem, StringComparison.OrdinalIgnoreCase)
                                       || p.Email.Contains(query.SearchItem, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else
            {
                result = _contactCollection.AsQueryable().ToList();
            }

            switch (query.SortBy)
            {
                case "LastName":
                    return (query.IsSortAscending)? result.OrderBy(p => p.LastName).ToList() : result.OrderByDescending(p => p.LastName).ToList();
                case "Email":
                    return (query.IsSortAscending) ? result.OrderBy(p => p.Email).ToList() : result.OrderByDescending(p => p.Email).ToList();
                default:
                    return (query.IsSortAscending) ? result.OrderBy(p => p.FirstName).ToList() : result.OrderByDescending(p => p.FirstName).ToList();
            }
        }
    }
}
