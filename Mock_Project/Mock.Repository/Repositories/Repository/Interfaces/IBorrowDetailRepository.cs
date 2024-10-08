using Mock.Core.Models;
using Mock.Repository.ApiResult;
using Mock.Repository.Repositories.Generic;

namespace Mock.Repository.Repositories.Repository.Interfaces
{
    public interface IBorrowDetailRepository : IGenericRepository<BorrowingDetails>
    {
        public APIResult<string> UpdateReturnedBook(int borrowingDetailId, int numberBookReturned);


        public List<BorrowingDetails> ViewListBookBorrowingUser(int userId);


        List<BorrowingDetails> getByRequestId(int requestId);

    }
}