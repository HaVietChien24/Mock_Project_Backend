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
            throw new NotImplementedException();
        }

        public List<Borrowing> GetAllBorrowings()
        {
            return _context.Borrowings.Include(c => c.User).ToList();
        }

        public List<BorrowingDetails> GetBorrowingDetails(int borrowingId)
        {
            var borrowingDetail = _context.BorrowingDetails.Include(c => c.Book).ToList();

            return borrowingDetail;
        }

        public List<Borrowing> GetAllRequestsByUserId(int id)
        {
            var requests = _context.Borrowings.Include(x => x.BorrowingDetails)
                .ThenInclude(bd => bd.Book).Where(x => x.RequestStatus.ToLower() == "pending")
                .ToList();
            return requests;
        }
    }
}
