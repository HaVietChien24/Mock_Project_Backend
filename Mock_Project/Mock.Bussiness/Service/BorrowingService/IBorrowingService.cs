using Mock.Bussiness.DTO;

namespace Mock.Bussiness.Service.BorrowingService
{
    public interface IBorrowingService
    {
        public PageList<BorrowingDTO> GetAllBorrowing(int page, int pageSize, string userName, string borrowStatus);
    }
}
