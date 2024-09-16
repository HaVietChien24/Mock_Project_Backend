using Mock.Bussiness.DTO;
using Mock.Bussiness.Service.Base;
using Mock.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Bussiness.Service.BookService
{
    public interface IBookService: IBaseService<Book>
    {
        List<BookDTO> GetAllDTO();
        BookDTO GetDTOById(int id);
    }
}
