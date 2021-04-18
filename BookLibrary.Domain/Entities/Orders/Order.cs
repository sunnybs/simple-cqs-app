using System;
using BookLibrary.Domain.Entities.Books;
using BookLibrary.Domain.Entities.Users;

namespace BookLibrary.Domain.Entities.Orders
{
    public class Order : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        
        public Guid BookId { get; set; }
        public Book Book { get; set; }
        
        public DateTime BookTakenDate { get; set; }
        public DateTime? Returned { get; set; }
        
        public OrderStatus OrderStatus { get; set; }
    }
}