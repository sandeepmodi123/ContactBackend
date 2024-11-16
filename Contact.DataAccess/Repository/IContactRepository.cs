using Contact.DataAccess.Models;

namespace Contact.DataAccess.Repository
{
    public interface IContactRepository
    {
        Task<bool> CreateContact(ContactModel contact);
        Task<ContactModel> ReadContact(int id);
        Task<bool> UpdateContact(ContactModel contact);
        Task<bool> DeleteContact(int id);
        Task<List<ContactModel>> GetAllContacts();
    }
}
