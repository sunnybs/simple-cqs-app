using System.Collections.Generic;
using System.Threading.Tasks;
using BookLibrary.Domain.Entities.Books;
using BookLibrary.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Infrastructure
{
    public class BooksContextSeed
    {
        private readonly BooksContext _context;

        public BooksContextSeed(BooksContext context)
        {
            _context = context;
        }

        public async Task SeedAllAsync()
        {
            if (await _context.Books.AnyAsync())
            {
                return;
            }

            var books = new List<Book>()
            {
                new Book()
                {
                    Author = "Тестовый автор 1",
                    Genre = "Жанр 1",
                    Name = "Имя 1"
                },
                new Book()
                {
                    Author = "Тестовый автор 2",
                    Genre = "Жанр 2",
                    Name = "Имя 2"
                },
                new Book()
                {
                    Author = "Тестовый автор 2",
                    Genre = "Жанр 2",
                    Name = "Имя 3"
                },
            };

            var users = new List<User>()
            {
                new User
                {
                    FullName = "Иван Петров",
                    Login = "petrov"
                },
                new User
                {
                    FullName = "Вася Петров",
                    Login = "vasya"
                },
            };

            await _context.Books.AddRangeAsync(books);
            await _context.Users.AddRangeAsync(users);
            await _context.SaveChangesAsync();
        }
    }
}