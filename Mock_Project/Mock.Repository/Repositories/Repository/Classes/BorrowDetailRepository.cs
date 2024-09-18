using Mock.Core.Data;
using Mock.Core.Models;
using Mock.Repository.Repositories.Generic;
using Mock.Repository.Repositories.Repository.Interfaces;

namespace Mock.Repository.Repositories.Repository.Classes
{
    public class BorrowDetailRepository : GenericRepository<BorrowingDetails>, IBorrowDetailRepository
    {
        private readonly LivebraryContext _context;
        public BorrowDetailRepository(LivebraryContext context) : base(context)
        {
            _context = context;
        }

        public string UpdateReturnedBook(int borrowingDetailId, int numberBookReturned)
        {
            var borrowingDetail = _context.BorrowingDetails.FirstOrDefault(c => c.Id == borrowingDetailId);
            if (borrowingDetail == null)
            {
                return "Không tìm thấy chi tiết mượn sách.";
            }

            if (borrowingDetail.Quantity < numberBookReturned)
            {
                return "Số lượng sách trả về không phù hợp.";
            }

            borrowingDetail.NumberReturnedBook += numberBookReturned;

            borrowingDetail.Quantity -= numberBookReturned;

            _context.SaveChanges();

            if (borrowingDetail.NumberReturnedBook == borrowingDetail.Quantity)
            {
                return "Đã trả xong tất cả sách.";
            }

            return "Cập nhật số lượng sách trả thành công.";
        }

        public List<BorrowingDetails> getByRequestId(int requestId)
        {
            return _context.BorrowingDetails.Where(x => x.BorrowingId == requestId).ToList();
        }
    }
}
