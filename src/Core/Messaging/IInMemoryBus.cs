using MediatR;

namespace Core.Messaging
{
    public interface IInMemoryBus : IBus, IMediator { }
}