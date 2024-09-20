using Mock.Core.Models;
using Mock.Repository.Repositories.Generic;

namespace Mock.Repository.Repositories.Repository.Interfaces
{
    public interface IBorrowingRepository : IGenericRepository<Borrowing>
    {
        public List<Borrowing> GetAllBorrowings();
        public string CheckBorrowingStatus(int borrowingId);

        public int CheckPenalty(int borrowingId);
        public List<BorrowingDetails> GetBorrowingDetails(int borrowingId);

        public void UpdatePickup(int borrowingId);
        public int? CalculateTotalQuantity(int borrowingId);

      


        List<Borrowing> GetAllRequestsByUserId(int id);
        List<Borrowing> GetAllRequestsByAllUser();
        Borrowing GetBorrowingById(int borrowingId);  // Lấy yêu cầu mượn sách dựa trên ID
        void UpdateBorrowing(Borrowing borrowing);    // Cập nhật yêu cầu mượn sách
    }
}
