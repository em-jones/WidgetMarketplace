using System.Threading.Tasks;
using Core.Messaging;
using static LanguageExt.Prelude;
using Microsoft.AspNetCore.Mvc;
using Store.StoreFrontStore;
using UserManagement.UserStore;

namespace Http.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IInMemoryBus _bus;

        public ItemController(IInMemoryBus bus) => _bus = bus;
        
        [HttpPost("[action]")]
        public Task<IActionResult> Purchase([FromBody] PurchaseItem command) =>
            Optional(command)
                .MapAsync(c => _bus.Send(c))
                .Match<IActionResult>(Ok, BadRequest);

        [HttpPost("[action]")]
        public Task<IActionResult> Create([FromBody] CreateUser command) => Optional(command).Map(c => c with
        {
            FindIfUserExists = () => _bus.Send(new GetUserByEmail(c.Email))
        }).MapAsync(c => _bus.Send(c))
            .Match<IActionResult>(Ok, BadRequest);
    }
}