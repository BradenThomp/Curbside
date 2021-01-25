using CQRS.Common;

namespace CQRS.Queries
{
    /// <summary>
    /// Handler for queries that read system data.
    /// </summary>
    /// <typeparam name="TQuery">The query to be executed.</typeparam>
    /// <typeparam name="TResponse">The response.</typeparam>
    public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse> where TQuery : IQuery
    {

    }
}
