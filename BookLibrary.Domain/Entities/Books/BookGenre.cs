using System;

namespace BookLibrary.Domain.Entities.Books
{
    public class BookGenre
    {
        public Guid GenreId { get; set; }
        public Genre Genre { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
    }
}