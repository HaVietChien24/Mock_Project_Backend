
namespace Mock.Core.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int PublishedYear { get; set; }
        public string ISBN { get; set; }
        public int Amount { get; set; }
        public virtual List<BookGenre>? BookGenres { get; set; } = new List<BookGenre>();

       
     
    }
}
