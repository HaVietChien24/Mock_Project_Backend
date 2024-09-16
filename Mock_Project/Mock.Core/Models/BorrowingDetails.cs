
namespace Mock.Core.Models
{
    public class BorrowingDetails
    {
        public int Id { get; set; }
        public int BorrowingId { get; set; }
        public Borrowing Borrowing { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int? Quantity { get; set; }
        public DateTime? ActualReturnDate { get; set; } //ngày trả thực tế
        public int? NumberReturnedBook { get; set; } = 0;
        public decimal? Penalty { get; set; }
        public string? Status { get; set; }
    }
}


