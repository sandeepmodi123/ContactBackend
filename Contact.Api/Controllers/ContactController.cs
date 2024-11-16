using Microsoft.AspNetCore.Mvc;

namespace Contact.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly ILogger<ContactController> _logger;

        public ContactController(ILogger<ContactController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetContacts")]
        public IEnumerable<ContactModel> Get()
        {
            return Enumerable.Range(1, 5).Distinct().Select(index => new ContactModel
            {
                Email = "abc@xyz.com",
                Id = Random.Shared.Next(1, 5),
                FirstName = "ABC",
                LastName = "XYZ"
            }).ToArray();
        }
    }
}
