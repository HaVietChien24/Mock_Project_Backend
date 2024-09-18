
using System.ComponentModel.DataAnnotations;

namespace Mock.Core.Models
{
    public class User
    {
        public int Id { get; set; }

        [StringLength(20, ErrorMessage = "First Name can't surpass 20 characters")]
        [Required]
        public string FirstName { get; set; }

        [StringLength(20, ErrorMessage = "Last Name can't surpass 20 characters")]
        [Required]
        public string LastName { get; set; }
        public string? ImageUrl { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Invalid Phone Number")]
        public string? Phone { get; set; }

        [StringLength(30, ErrorMessage = "Username can't surpass 30 characters")]
        [Required]
        public string Username { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "Password must be at least 8 characters long, contain at least 1 uppercase letter, 1 lowercase letter, " +
            "1 number, and 1 special character.")]
        public string Password { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public bool IsAdmin { get; set; }
        public List<Borrowing> Borrowings { get; set; } = new List<Borrowing>();
        public List<WishList> WishLists { get; set; } = new List<WishList>();
    }
}
