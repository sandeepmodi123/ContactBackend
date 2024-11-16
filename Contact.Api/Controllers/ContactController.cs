using Contact.DataAccess.Models;
using Contact.Service.Contract;
using Microsoft.AspNetCore.Mvc;

namespace Contact.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly ILogger<ContactController> _logger;
        private readonly IContactService _contactService;

        public ContactController(ILogger<ContactController> logger, IContactService contactService)
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
        public async Task<bool> GetContactById(string id)
        {
            return true;
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
        public async Task<bool> DeleteContact(string id)
        {
            return await _contactService.DeleteContact(id);
        }
    }
}
