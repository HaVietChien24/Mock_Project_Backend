using Mock.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Bussiness.DTO
{
    public class BorrowingDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Username { get; set; }
        public DateTime? RequestDate { get; set; } //ngày gửi yêu cầu book sách
        public DateTime? ExpectedPickUpDate { get; set; } //ngày dự kiến đến lấy
        public DateTime? ActualPickUpDate { get; set; } //ngày đến lấy thực tế
        public DateTime? ExpectedReturnDate { get; set; } //ngày dự kiến trả
        public int? TotalQuantity { get; set; }
        public string? RequestStatus { get; set; }
        public string? BorrowingStatus { get; set; }
        public decimal? PenaltyFine { get; set; } = 0;
        public string? IsBookPickedUp { get; set; }
        public string? IsPickUpLate {  get; set; }

    }
}
