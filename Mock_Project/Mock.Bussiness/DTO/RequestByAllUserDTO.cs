using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Bussiness.DTO
{
    public class RequestByAllUserDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public DateTime? RequestDate { get; set; } //ngày gửi yêu cầu book sách
        public DateTime? ExpectedPickUpDate { get; set; } //ngày dự kiến đến lấy
        public DateTime? ExpectedReturnDate { get; set; } //ngày dự kiến trả
        public int? TotalQuantity { get; set; }
        public string? RequestStatus { get; set; }
        public virtual List<RequestDetailsDTO> RequestDetails { get; set; } = new List<RequestDetailsDTO>();
    }
}
