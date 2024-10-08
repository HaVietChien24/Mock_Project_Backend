﻿using Mock.Bussiness.DTO;
using Mock.Core.Models;
using Mock.Repository.ApiResult;

namespace Mock.Bussiness.Service.BorrowingService
{
    public interface IBorrowingService
    {
        public PageList<BorrowingDTO> GetAllBorrowing(int page, int pageSize, string userName, string borrowStatus);
        public APIResult<string> UpdateReturnedBook(int borrowingDetailId, int numberBookReturned);

        public string CheckBorrowingStatus(int borrowingId);
        public int CheckPenalty(int borrowingId);

        public PageList<BorrowingDetailDTO> GetAllBorrowingDetail(int borrowingId,int page,int pageSize);
        public void UpdatePickup(int borrowingId);
        public int? CalculateTotalQuantity(int borrowingId);
        public PageList<BorrowingDetailDTO> ViewListBookBorrowingUser(int userId, int page=1,int pageSize=5);
    }
}
