using Microsoft.EntityFrameworkCore;
using Mock.Core.Data;
using Mock.Core.Models;
using Mock.Repository.ApiResult;
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

        public APIResult<string> UpdateReturnedBook(int borrowingDetailId, int numberBookReturned)
        {
            var borrowingDetail = _context.BorrowingDetails.FirstOrDefault(c => c.Id == borrowingDetailId);
            var bookAvailibile = _context.Books.FirstOrDefault(c => c.Id == borrowingDetail.BookId);
            if (borrowingDetail == null)
            {
                return APIResult<string>.FailureResult("Không tìm thấy chi tiết mượn sách.");
            }
            if (numberBookReturned < 0)
            {
                return APIResult<string>.FailureResult("Số sách trả về phải lớn hơn 0.");
            }
            if (borrowingDetail.Quantity < numberBookReturned)
            {
                return APIResult<string>.FailureResult("Số lượng sách trả về không phù hợp.");
            }
            borrowingDetail.NumberReturnedBook = numberBookReturned;

            if (borrowingDetail.NumberReturnedBook == borrowingDetail.Quantity)
            {
                borrowingDetail.Status = "Returned";
                borrowingDetail.ActualReturnDate = DateTime.Now;
                return APIResult<string>.SuccessResult("Đã trả xong tất cả sách.");
            }
            if (borrowingDetail.NumberReturnedBook < borrowingDetail.Quantity)
            {
                borrowingDetail.Status = "Not Returned";
                borrowingDetail.ActualReturnDate = DateTime.Now;
                borrowingDetail.Quantity -= numberBookReturned;
                bookAvailibile.Amount += numberBookReturned;
                return APIResult<string>.SuccessResult("Đã trả sách.");
            }
            var borrowing = _context.Borrowings.FirstOrDefault(c => c.Id == borrowingDetail.BorrowingId).BorrowingDetails.ToList();

            return APIResult<string>.SuccessResult("Cập nhật số lượng sách trả thành công.");
        }
        public List<BorrowingDetails> ViewListBookBorrowingUser(int userId)
        {
            return _context.BorrowingDetails.Include(c => c.Book).Include(c => c.Borrowing).Where(c => c.Borrowing.UserId == userId && c.Borrowing.RequestStatus=="Accept").ToList();
        }

           
        }
        public List<BorrowingDetails> getByRequestId(int requestId)
        {
            return _context.BorrowingDetails.Where(x => x.BorrowingId == requestId).ToList();
        }
    } 
}
