using Core.Data;

namespace Core.Domain
{
    public class AbstractProjection<T>
    {
        private IProjectionContext<T> _projectionContext;
    }
}