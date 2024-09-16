using Mock.Bussiness.DTO;
using Mock.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Bussiness.Service.BorrowingService
{
    public interface IBorrowingService
    {
        public PageList<BorrowingDTO> GetAllBorrowing(int page, int pageSize, string userName, string borrowStatus);
    }
}
