using System;
using BookLibrary.Domain.Entities.Orders;

namespace BookLibrary.Application.Books.Queries.GetOrdersList
{
    public class OrderDto
    {
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public DateTime BookTakenDate { get; set; }
        public DateTime? Returned { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}