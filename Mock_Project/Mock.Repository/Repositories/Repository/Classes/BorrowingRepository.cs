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

        public int? CalculateTotalQuantity(int borrowingId)
        {
            var total= _context.BorrowingDetails.Where(c=>c.BorrowingId==borrowingId).Sum(c=>c.Quantity);
            return total;
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
                              IsBookPickedUp=c.IsBookPickedUp
                          }).FirstOrDefault();
            if (borrowing.Status == "Not Returned" && borrowing.ExpectedReturnDate <= DateTime.UtcNow&& borrowing.IsBookPickedUp== true)
            {
                var overdueDays = (DateTime.UtcNow - borrowing.ExpectedReturnDate).Value.Days;
                penalty = overdueDays * 5000;
            }
            return penalty;
        }
        public List<Borrowing> GetAllBorrowings()
        {

            var borrowing= _context.Borrowings.Include(c => c.User).Where(c => c.RequestStatus == "Accept").ToList();
            foreach (var item in borrowing )
            {
                if (item.ExpectedPickUpDate < DateTime.Now && item.IsBookPickedUp == false&& item.IsRestocked==false)
                {
                    item.IsPickUpLate = false;
                    var borrowingDetail = _context.BorrowingDetails.Where(c => c.BorrowingId == item.Id).ToList();
                    foreach (var br in borrowingDetail)
                    {
                        var book = _context.Books.FirstOrDefault(c => c.Id == br.BookId);
                        book.Amount += (int)br.Quantity;
                    }
                    item.IsRestocked = true;
                }
                else
                {
                    item.IsPickUpLate = true;
                }
            }
            _context.SaveChanges();
            return borrowing;

            return _context.Borrowings.Include(c => c.User).ToList();

        }

        public List<BorrowingDetails> GetBorrowingDetails(int borrowingId)
        {

            var borrowingDetail = _context.BorrowingDetails.Include(c => c.Book).Where(c => c.BorrowingId == borrowingId).ToList();

            var borrowingDetail = _context.BorrowingDetails.Include(c => c.Book).ToList();


            return borrowingDetail;
        }


        public void UpdatePickup(int borrowingId)
        {
           var borrowingPickup=_context.Borrowings.FirstOrDefault(c=>c.Id== borrowingId);
            borrowingPickup.IsBookPickedUp = true;

        public List<Borrowing> GetAllRequestsByUserId(int id)
        {
            var requests = _context.Borrowings.Include(x => x.BorrowingDetails)
                .ThenInclude(bd => bd.Book).Where(x => x.RequestStatus.ToLower() == "pending")
                .ToList();
            return requests;

        }
    }
}
