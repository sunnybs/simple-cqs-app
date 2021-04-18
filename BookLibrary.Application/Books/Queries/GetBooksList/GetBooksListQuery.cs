using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BookLibrary.Application.Common.Interfaces;
using BookLibrary.Application.Users.Queries.GetUsersList;
using BookLibrary.Domain.Entities.Books;
using BookLibrary.Domain.Entities.Users;
using MediatR;

namespace BookLibrary.Application.Books.Queries.GetBooksList
{
    public class GetBooksListQuery : IRequest<BookDto[]>
    {
        public string Name { get; set; }
        
        public class Handler : IRequestHandler<GetBooksListQuery, BookDto[]>
        {
            private readonly ICrudRepository<Book> _books;

            public Handler(IUnitOfWork unitOfWork)
            {
                _books = unitOfWork.Get<Book>();
            }
            
            public async Task<BookDto[]> Handle(GetBooksListQuery request, CancellationToken cancellationToken)
            {
                var books = string.IsNullOrWhiteSpace(request.Name)
                    ? await _books.GetAllAsync()
                    : await _books.FilterAsync(b => b.Name == request.Name);

                var result = books.Select(b => new BookDto
                {
                    Id = b.Id,
                    Name = b.Name
                });

                return result.ToArray();
            }
        }
    }
}