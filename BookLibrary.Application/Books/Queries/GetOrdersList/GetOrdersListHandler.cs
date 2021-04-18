using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BookLibrary.Application.Common.Interfaces;
using BookLibrary.Domain.Entities.Orders;
using MediatR;

namespace BookLibrary.Application.Books.Queries.GetOrdersList
{
    public class GetOrdersListHandler : IRequestHandler<GetOrdersListQuery, OrderDto[]>
    {
        private readonly ICrudRepository<Order> _orders;
        
        public GetOrdersListHandler(IUnitOfWork unitOfWork)
        {
            _orders = unitOfWork.Get<Order>();
        }
        
        public async Task<OrderDto[]> Handle(GetOrdersListQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orders.GetAllAsync();

            var result = orders.Select(o => new OrderDto
            {
                UserId = o.UserId,
                BookId = o.BookId,
                BookTakenDate = o.BookTakenDate,
                OrderStatus = o.OrderStatus,
                Returned = o.Returned
            }).ToArray();

            return result;
        }
    }
}