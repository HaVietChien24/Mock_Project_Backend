using Mock.Bussiness.DTO;

namespace Mock.Bussiness.Service.BorrowingService
{
    public interface IBorrowingService
    {
        public PageList<BorrowingDTO> GetAllBorrowing(int page, int pageSize, string userName, string borrowStatus);
        public string UpdateReturnedBook(int borrowingDetailId, int numberBookReturned);

        public PageList<BorrowingDetailDTO> GetAllBorrowingDetail(int borrowingId,int page,int pageSize);
    }
}
