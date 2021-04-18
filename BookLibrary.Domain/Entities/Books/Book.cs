namespace BookLibrary.Domain.Entities.Books
{
    public class Book : BaseEntity
    {
        public string Name { get; set; }
        // Для простоты реализации
        public string Author { get; set; }
        public string Genre { get; set; }
    }
}