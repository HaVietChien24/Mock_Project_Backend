using Mock.Core.Models;
using Mock.Repository.Repositories.Generic;

namespace Mock.Repository.Repositories.Repository.Interfaces
{
    public interface IBorrowingRepository : IGenericRepository<Borrowing>
    {
        public List<Borrowing> GetAllBorrowings();
        public string CheckBorrowingStatus(int borrowingId);

    }
}
