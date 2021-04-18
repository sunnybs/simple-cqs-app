using System;
using System.Threading;
using System.Threading.Tasks;
using BookLibrary.Application.Common.Interfaces;
using BookLibrary.Domain.Entities.Orders;
using MediatR;

namespace BookLibrary.Application.Books.Commands.OrderBook
{
    public class OrderBookCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public DateTime StartTime { get; set; }
        
        public class Handler : IRequestHandler<OrderBookCommand>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly ICrudRepository<Order> _orders;

            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
                _orders = unitOfWork.Get<Order>();
            }
            
            public async Task<Unit> Handle(OrderBookCommand request, CancellationToken cancellationToken)
            {
                /*
                var isAlreadyOrdered = await _orders
                    .AnyAsync(o => o.BookTakenDate <= request.StartTime && o.OrderStatus != OrderStatus.Returned);

                if (isAlreadyOrdered)
                {
                    //TODO: Нужно бы выкинуть исключение и перехватить в мидлваре, но для простоты реализации этого нет
                    return Unit.Value;
                }
                */
                var order = new Order
                {
                    BookId = request.BookId,
                    UserId = request.UserId,
                    BookTakenDate = request.StartTime,
                    OrderStatus = OrderStatus.InReading
                };

                await _orders.AddAsync(order);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}