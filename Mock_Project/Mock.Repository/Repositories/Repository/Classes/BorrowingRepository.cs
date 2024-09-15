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

        public List<Borrowing> GetAllBorrowings()
        {
           return _context.Borrowings.Include(c=>c.User).ToList();
        }
    }
}
