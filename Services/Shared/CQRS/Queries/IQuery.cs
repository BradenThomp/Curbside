using CQRS.Common;

namespace CQRS.Queries
{
    /// <summary>
    /// Interface for a query. Queries read system data and should not update the systems state (Read).
    /// </summary>
    public interface IQuery : IRequest
    {
    }
}
