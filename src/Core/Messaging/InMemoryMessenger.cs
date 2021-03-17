using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Core.Messaging
{
    public class InMemoryMessenger : IInMemoryBus
    {
        private readonly IMediator _mediator;

        public InMemoryMessenger(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<TResponse> Send<TResponse>(IRequest<TResponse> request,
            CancellationToken cancellationToken = new())
            => _mediator.Send(request, cancellationToken);

        public Task<object?> Send(object request, CancellationToken cancellationToken = new())
            => _mediator.Send(request, cancellationToken);

        public Task Publish(object notification, CancellationToken cancellationToken = new()) =>
            _mediator.Publish(notification, cancellationToken);

        public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = new())
            where TNotification : IEvent
            => _mediator.Publish(notification, cancellationToken);
    }
}