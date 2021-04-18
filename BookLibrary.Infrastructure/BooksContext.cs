using BookLibrary.Domain.Entities.Books;
using BookLibrary.Domain.Entities.Orders;
using BookLibrary.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Infrastructure
{
    public class BooksContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }

        public BooksContext(DbContextOptions<BooksContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>()
                .HasKey(k => new {k.BookId, k.AuthorId});

            modelBuilder.Entity<BookGenre>()
                .HasKey(k => new {k.BookId, k.GenreId});

        }
    }
}