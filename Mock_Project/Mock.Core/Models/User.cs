
namespace Mock.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ImageUrl { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
        public List<Borrowing> Borrowings { get; set; } = new List<Borrowing>();
        public List<WishList> WishLists { get; set; } = new List<WishList>();
    }
}
