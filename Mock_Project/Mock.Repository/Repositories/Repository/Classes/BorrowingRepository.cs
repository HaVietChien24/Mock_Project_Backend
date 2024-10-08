﻿using Microsoft.EntityFrameworkCore;
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
            var total = _context.BorrowingDetails.Where(c => c.BorrowingId == borrowingId).Sum(c => c.Quantity);
            return total;
        }
        public string CheckBorrowingStatus(int borrowingId)
        {
            var c = _context.Borrowings
                           .Include(c => c.BorrowingDetails)
            .FirstOrDefault(x => x.Id == borrowingId);
            var status = c.IsBookPickedUp == false || c.IsBookPickedUp == null
                                       ? ""
                                       : (
                                       c.BorrowingDetails.Sum(x => x.NumberReturnedBook) == c.BorrowingDetails.Sum(x => x.Quantity) ? "Returned"
                                       : (
                                       c.BorrowingDetails.Sum(x => x.NumberReturnedBook) == 0 ? "Not Returned" : "Not Returned Enough"
                                       )
                                       );
            //đã trả = trả đủ hết => total returned =total mượn
            //chưa trả => total returned =0
            //chưa trả đủ=> total returned >0 và < total mượn


            return status;
        }
        public int CheckPenalty(int borrowingId)
        {
            int penalty = 0;
            var c = _context.Borrowings
                          .Include(c => c.BorrowingDetails)
           .FirstOrDefault(x => x.Id == borrowingId);
            var status = c.IsBookPickedUp == false || c.IsBookPickedUp == null
                                       ? ""
                                       : (
                                       c.BorrowingDetails.Sum(x => x.NumberReturnedBook) == c.BorrowingDetails.Sum(x => x.Quantity) ? "Returned"
                                       : (
                                       c.BorrowingDetails.Sum(x => x.NumberReturnedBook) == 0 ? "Not Returned" : "Not Returned Enough"
                                       )
                                       );

            if ((status == "Not Returned" || status == "Not Returned Enough") && c.ExpectedReturnDate < DateTime.UtcNow && c.IsBookPickedUp == true)
            {
                var overdueDays = (DateTime.UtcNow - c.ExpectedReturnDate).Value.Days;
                penalty = overdueDays * 5000;
                c.PenaltyFine = penalty;
            }
            var returnedDate = c.BorrowingDetails.Max(x => x.ActualReturnDate);
            if (status == "Returned" && c.ExpectedReturnDate < returnedDate && c.IsBookPickedUp == true)
            {
                var overdueDays = (returnedDate - c.ExpectedReturnDate).Value.Days;
                penalty = overdueDays * 5000;
                c.PenaltyFine = penalty;
            }

            return penalty;
        }
        public List<Borrowing> GetAllBorrowings()
        {

            var borrowing = _context.Borrowings.Include(c => c.User).Where(c => c.RequestStatus.ToLower() == "Accept").ToList();
            foreach (var item in borrowing)
            {

                if (item.ExpectedPickUpDate < DateTime.Now && item.IsBookPickedUp == false && item.IsRestocked == false)
                {
                    item.IsPickUpLate = true;
                    var borrowingDetail = _context.BorrowingDetails.Where(c => c.BorrowingId == item.Id).ToList();
                    foreach (var br in borrowingDetail)
                    {
                        var book = _context.Books.FirstOrDefault(c => c.Id == br.BookId);
                        book.Amount += (int)br.Quantity;
                    }
                    item.IsRestocked = true;
                }
            }
            _context.SaveChanges();
            return borrowing;
        }
        public List<BorrowingDetails> GetBorrowingDetails(int borrowingId)
        {
            var borrowingDetail = _context.BorrowingDetails.Include(c => c.Borrowing).Include(c => c.Book).Where(c => c.BorrowingId == borrowingId).ToList();
            return borrowingDetail;
        }
        public void UpdatePickup(int borrowingId)
        {
            var borrowingPickup = _context.Borrowings.Include(x => x.BorrowingDetails).FirstOrDefault(c => c.Id == borrowingId);
            borrowingPickup.ActualPickUpDate = DateTime.Now;
            borrowingPickup.IsBookPickedUp = true;

            var borrowingDetail = borrowingPickup.BorrowingDetails;
            foreach (var item in borrowingDetail)
            {
                item.Status = "Not Returned";
            }

        }
        public List<Borrowing> GetAllRequestsByUserId(int id)
        {
            var requests = _context.Borrowings.Include(x => x.BorrowingDetails)
                .ThenInclude(bd => bd.Book).Where(x => x.UserId == id && x.RequestStatus.ToLower() == "pending")
                .ToList();
            return requests;
        }

        public List<Borrowing> GetAllRequestsByAllUser()
        {
            var requests = _context.Borrowings.Include(u => u.User).Include(x => x.BorrowingDetails).ThenInclude(b => b.Book)
                .Where(u => u.RequestStatus.ToLower() == "pending")
                .ToList();
            return requests;
        }
        public Borrowing GetBorrowingById(int borrowingId)
        {
            return _context.Borrowings.FirstOrDefault(b => b.Id == borrowingId);
        }
        public void UpdateBorrowing(Borrowing borrowing)
        {
            _context.Borrowings.Update(borrowing);
            _context.SaveChanges();  // Lưu thay đổi vào cơ sở dữ liệu
        }
    }
}
