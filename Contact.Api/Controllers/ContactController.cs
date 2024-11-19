using Contact.Api.Logger;
using Contact.DataAccess.Models;
using Contact.Service.Contract;
using Microsoft.AspNetCore.Mvc;

namespace Contact.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IContactService _contactService;

        public ContactController(ILoggerManager logger, IContactService contactService)
        {
            _logger = logger;
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<IEnumerable<ContactModel>> GetAllContacts()
        {
            return await _contactService.GetAllContacts();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ContactModel> GetContactById(int id)
        {
            return await _contactService.ReadContact(id);
        }

        [HttpPost]
        public async Task<bool> CreateContact(ContactModel contactModel)
        {
            return await _contactService.CreateContact(contactModel);
        }

        [HttpPut]
        public async Task<bool> UpdateContact(ContactModel contactModel)
        {
            return await _contactService.UpdateContact(contactModel);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<bool> DeleteContact(int id)
        {
            return await _contactService.DeleteContact(id);
        }

        [HttpPost]
        [Route("Search")]
        public async Task<IEnumerable<ContactModel>> SearchContacts(QueryModel query)
        {
            return await _contactService.SearchContacts(query);
        }
    }
}
