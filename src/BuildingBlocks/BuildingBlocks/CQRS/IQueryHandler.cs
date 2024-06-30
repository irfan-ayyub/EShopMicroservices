using MediatR;

namespace BuildingBlocks.CQRS
{


    public interface IQueryHandler<in TQuery, Tresponse>
        : IRequestHandler<TQuery, Tresponse>
        where TQuery : IQuery<Tresponse>
        where Tresponse : notnull
    {
    }
}
