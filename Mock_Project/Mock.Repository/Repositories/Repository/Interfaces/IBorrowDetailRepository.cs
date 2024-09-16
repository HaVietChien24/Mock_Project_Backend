using Mock.Core.Data;
using Mock.Core.Models;
using Mock.Repository.Repositories.Generic;

namespace Mock.Repository.Repositories.Repository.Interfaces
{
    public interface IBorrowDetailRepository : IGenericRepository<BorrowingDetails>
    {
        public string UpdateReturnedBook(int borrowingDetailId, int numberBookReturned);

    }
}
