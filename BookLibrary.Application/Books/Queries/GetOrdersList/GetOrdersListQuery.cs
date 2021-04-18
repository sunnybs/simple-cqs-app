using MediatR;

namespace BookLibrary.Application.Books.Queries.GetOrdersList
{
    public class GetOrdersListQuery : IRequest<OrderDto[]>
    {
    }
}