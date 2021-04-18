using System;

namespace BookLibrary.Application.Users.Queries.GetUsersList
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Login { get; set; }
    }
}