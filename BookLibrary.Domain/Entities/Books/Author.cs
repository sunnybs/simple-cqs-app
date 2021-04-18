using System.Collections.Generic;

namespace BookLibrary.Domain.Entities.Books
{
    public class Author : BaseEntity
    {
        public string FullName { get; set; }
        public ICollection<BookAuthor> AuthoredBooks { get; set; }
    }
}