using System;
using System.Threading.Tasks;
using Core.Messaging;
using LanguageExt;
using static LanguageExt.Prelude;
using Microsoft.AspNetCore.Mvc;
using Orleans;
using UserManagement.UserStore;

namespace Http.Controllers
{
    delegate int DoesMyThing(bool input);
    
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IInMemoryBus _bus;
        private readonly IGrainFactory _grainFactory;
        private readonly DoesMyThing DoesMyThingImpl = (input) => 1;

        public UserController(IInMemoryBus bus, IGrainFactory grainFactory)
        {
            _bus = bus;
            _grainFactory = grainFactory;
        }

        TryOptionAsync<UserState> GetUserFromUserId(Guid userId) =>
            async () => await _grainFactory.GetGrain<IDistributedUserEventStore>(userId).Get();

        [HttpGet("[action]")]
        public Task<IActionResult> GetDist(Guid id) =>
            TryOptionAsync(id)
                .Bind(GetUserFromUserId)
                .Match<UserState, IActionResult>
                    (Ok, BadRequest,  BadRequest);

        [HttpGet("[action]")]
        public Task<IActionResult> Get(Option<Guid> id) =>
            id.Map(userId => new GetUser(userId))
                .MapAsync(query => _bus.Send(query))
                .Filter(o => o.Id == Guid.Empty)
                .Match<IActionResult>(Ok, BadRequest);

        [HttpGet("[action]")]
        public Task<IActionResult> Create([FromBody] CreateUser command) => Optional(command).Map(c => c with
        {
            FindIfUserExists = () => _bus.Send(new GetUserByEmail(c.Email))
        }).MapAsync(c => _bus.Send(c))
            .Match<IActionResult>(Ok, BadRequest);
    }
}