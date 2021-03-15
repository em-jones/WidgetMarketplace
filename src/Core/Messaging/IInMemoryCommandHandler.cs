using LanguageExt.Common;
using MediatR;

namespace Core.Messaging
{
    public interface IInMemoryCommandHandler<TIn, TOut> : ICommandHandler, IRequestHandler<TIn, TOut> 
        where TIn : ICommand<TOut>
    { }
}