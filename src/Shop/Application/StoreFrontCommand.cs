using Core.Messaging;
using Store.StoreFrontStore;

namespace Store.Application
{
    public record StoreFrontCommand : Command, ICommand<StoreFrontState>;
}