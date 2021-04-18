namespace BookLibrary.Domain.Entities.Users
{
    public class User : BaseEntity
    {
        public string FullName { get; set; }
        public string Login { get; set; }
    }
}