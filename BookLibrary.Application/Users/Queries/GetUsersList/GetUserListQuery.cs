using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BookLibrary.Application.Common.Interfaces;
using BookLibrary.Domain.Entities.Users;
using MediatR;

namespace BookLibrary.Application.Users.Queries.GetUsersList
{
    public class GetUserListQuery : IRequest<UserDto[]>
    {
        public string Login { get; set; }
        
        public class Handler : IRequestHandler<GetUserListQuery, UserDto[]>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly ICrudRepository<User> _users;

            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
                _users = unitOfWork.Get<User>();
            }
            
            public async Task<UserDto[]> Handle(GetUserListQuery request, CancellationToken cancellationToken)
            {
                var users = string.IsNullOrWhiteSpace(request.Login)
                    ? await _users.GetAllAsync()
                    : await _users.FilterAsync(u => u.Login == request.Login);

                var result = users.Select(u => new UserDto
                {
                    Login = u.Login,
                    FullName = u.FullName,
                    Id = u.Id
                });

                return result.ToArray();
            }
        }
    }
}