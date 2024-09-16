namespace Mock.Core.Models
{
    public class Borrowing
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public DateTime? RequestDate { get; set; } //ngày gửi yêu cầu book sách
        public DateTime? ExpectedPickUpDate { get; set; } //ngày dự kiến đến lấy
        public DateTime? ActualPickUpDate { get; set; } //ngày đến lấy thực tế
        public DateTime? ExpectedReturnDate { get; set; } //ngày dự kiến trả
        public int? TotalQuantity { get; set; }
        public string? RequestStatus { get; set; }
        public string? BorrowingStatus { get; set; } // đã trả, chưa trả, chưa trả đủ
        public decimal? PenaltyFine { get; set; } = 0;
        public virtual List<BorrowingDetails> BorrowingDetails { get; set; } = new List<BorrowingDetails>();

    }
}
