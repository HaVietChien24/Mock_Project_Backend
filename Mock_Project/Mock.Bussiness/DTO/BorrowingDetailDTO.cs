using Mock.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Bussiness.DTO
{
    public class BorrowingDetailDTO
    {
        public int Id { get; set; }
        public int BorrowingId { get; set; }
       
        public int BookId { get; set; }
        public string? BookName { get; set; }
        public int? Quantity { get; set; }
        public DateTime? ActualReturnDate { get; set; } //ngày trả thực tế
        public int? NumberReturnedBook { get; set; } = 0;
        public decimal? Penalty { get; set; }
        public string? Status { get; set; }
        
        public bool? IsPickUpLate { get; set; }
        public string? ImageUrl { get; set; }

    }
}
