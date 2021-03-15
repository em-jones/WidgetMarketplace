using System;
using System.Threading.Tasks;
using Core;
using Core.Messaging;
using LanguageExt;
using static LanguageExt.Prelude;
using Microsoft.AspNetCore.Mvc;
using UserManagement.UserStore;

namespace Http.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IInMemoryBus _bus;

        public UserController(IInMemoryBus bus) => _bus = bus;
        
        [HttpGet("[action]")]
        public Task<IActionResult> Get(Option<Guid> id) =>
            id.Map(userId => new GetUser(userId))
                .MapAsync(query => _bus.Send(query))
                .Filter(o => o.id == Guid.Empty)
                .Match<IActionResult>(Ok, BadRequest);

        [HttpGet("[action]")]
        public Task<IActionResult> Create([FromBody] CreateUser command) => Optional(command).Map(c => c with
        {
            FindIfUserExists = () => _bus.Send(new GetUserByEmail(c.Email))
        }).MapAsync(c => _bus.Send(c))
            .Match<IActionResult>(Ok, BadRequest);
    }
}