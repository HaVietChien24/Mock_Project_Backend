using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mock.Bussiness.Service.BookService;

namespace Mock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("get-all-books")]
        public IActionResult GetAll()
        {
            try
            {
                var list = _bookService.GetAllDTO();
                if (list.Count == 0)
                {
                    return Ok("Không có dữ liệu");
                }
                return Ok(list);
            }
            catch (Exception)
            {
                return BadRequest("Có lỗi xảy ra");
            }
        }
    }
}
