using Microsoft.EntityFrameworkCore;
using Mock.Core.Data;
using Mock.Core.Models;
using Mock.Repository.Repositories.Generic;
using Mock.Repository.Repositories.Repository.Interfaces;

namespace Mock.Repository.Repositories.Repository.Classes
{
    public class BorrowingRepository : GenericRepository<Borrowing>, IBorrowingRepository
    {
        private readonly LivebraryContext _context;
        public BorrowingRepository(LivebraryContext context) : base(context)
        {
            _context = context;
        }

        public string CheckBorrowingStatus(int borrowingId)
        {
            var borrowing = _context.Borrowings
                           .Include(c => c.BorrowingDetails)
                           .Where(c => c.Id == borrowingId)
                           .Select(c => new
                           {
                             BorrowingId = c.Id,
                            Status = c.BorrowingDetails.All(d => d.Status != "Not Returned") ? "Returned" : "Not Returned",
                            ExpectedReturnDate=c.ExpectedReturnDate,
                           }).FirstOrDefault();
           
            return borrowing.Status;
        }
        public int CheckPenalty(int borrowingId) {
            int penalty = 0;
            var borrowing = _context.Borrowings
                          .Include(c => c.BorrowingDetails)
                          .Where(c => c.Id == borrowingId)
                          .Select(c => new
                          {
                              BorrowingId = c.Id,
                              Status = c.BorrowingDetails.All(d => d.Status != "Not Returned") ? "Returned" : "Not Returned",
                              ExpectedReturnDate = c.ExpectedReturnDate,
                          }).FirstOrDefault();
            if (borrowing.Status == "Not Returned" && borrowing.ExpectedReturnDate <= DateTime.UtcNow)
            {
                var overdueDays = (DateTime.UtcNow - borrowing.ExpectedReturnDate).Value.Days;
                penalty = overdueDays * 5000;
            }
            return penalty;
        }
       
        public List<Borrowing> GetAllBorrowings()
        {
            return _context.Borrowings.Include(c => c.User).Where(c=>c.RequestStatus== "Accept").ToList();
        }

        public List<BorrowingDetails> GetBorrowingDetails(int borrowingId)
        {
            var borrowingDetail = _context.BorrowingDetails.Include(c => c.Book).Where(c => c.BorrowingId == borrowingId).ToList();

            return borrowingDetail;
        }
    }
}
