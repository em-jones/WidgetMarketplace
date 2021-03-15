using LanguageExt;

namespace Core.Domain.Types
{
    public delegate TryAsync<T> CommandStrategy<T>(T context);
}