using MediatR;

namespace Core.Messaging
{
    public interface ICommand<out TResult> : IRequest<TResult> { }
}