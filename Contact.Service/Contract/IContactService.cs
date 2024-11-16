using Contact.DataAccess.Models;

namespace Contact.Service.Contract
{
    public interface IContactService
    {
        Task<bool> CreateContact(ContactModel contact);
        Task<ContactModel> ReadContact(int id);
        Task<bool> UpdateContact(ContactModel contact);
        Task<bool> DeleteContact(string id);
        Task<List<ContactModel>> GetAllContacts();
    }
}
