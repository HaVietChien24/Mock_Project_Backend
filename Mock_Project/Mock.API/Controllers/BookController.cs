using Microsoft.AspNetCore.Mvc;
using Mock.Bussiness;
using Mock.Bussiness.DTO;
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
        public IActionResult GetAll(int? pageNumber, int? pageSize)
        {
            try
            {
                var list = _bookService.GetAllDTO();
                if (list.Count == 0)
                {
                    return Ok("Không có dữ liệu");
                }
                if (!pageNumber.HasValue && !pageSize.HasValue)
                {
                    return Ok(list);
                }
                if (pageNumber.HasValue && pageSize.HasValue)
                {
                    PageList<BookDTO> pageList = PageList<BookDTO>.CreatePage(list, pageNumber.Value, pageSize.Value);
                    return Ok(pageList);
                }
                throw new Exception("Thiếu tham số truyền vào");
            }
            catch (Exception e)
            {
                return BadRequest("Có lỗi xảy ra: " + e.Message);
            }
        }

        [HttpGet("get-by-genre-id/{id}")]
        public IActionResult GetByGenreId(int id, int? pageNumber, int? pageSize)
        {
            try
            {
                var list = _bookService.GetBookDTOByGenreId(id);
                if (list.Count == 0)
                {
                    return Ok("Không có dữ liệu");
                }
                if (!pageNumber.HasValue && !pageSize.HasValue)
                {
                    return Ok(list);
                }
                if (pageNumber.HasValue && pageSize.HasValue)
                {
                    PageList<BookDTO> pageList = PageList<BookDTO>.CreatePage(list, pageNumber.Value, pageSize.Value);
                    return Ok(pageList);
                }
                throw new Exception("Thiếu tham số truyền vào");
            }
            catch (Exception)
            {
                return BadRequest("Có lỗi xảy ra");
            }
        }

        [HttpGet("search-by-title-or-author")]
        public IActionResult SearchByTitleOrAuthor([FromQuery] string search, int? pageNumber, int? pageSize)
        {
            try
            {
                var list = _bookService.SearchByTitleOrAuthor(search);
                if (list.Count == 0)
                {
                    return Ok("Không có dữ liệu");
                }
                if (!pageNumber.HasValue && !pageSize.HasValue)
                {
                    return Ok(list);
                }
                if (pageNumber.HasValue && pageSize.HasValue)
                {
                    PageList<BookDTO> pageList = PageList<BookDTO>.CreatePage(list, pageNumber.Value, pageSize.Value);
                    return Ok(pageList);
                }
                throw new Exception("Thiếu tham số truyền vào");
            }
            catch (Exception)
            {
                return BadRequest("Có lỗi xảy ra");
            }
        }
        [HttpPost("add-book")]
        public async Task<IActionResult> AddBook([FromBody] AddBookRequestDTO request)
        {
            try
            {
                // Gọi service để thêm sách và nhận lại đối tượng sách sau khi thêm
                var addedBook = await _bookService.AddBookAsync(request);

                // Trả về đối tượng sách dưới dạng JSON
                return Ok(addedBook);
            }
            catch (Exception ex)
            {
                // Trả về phản hồi lỗi dưới dạng JSON với thông tin chi tiết hơn
                var errorResponse = new
                {
                    message = "Failed to add book",
                    details = ex.Message
                };
                return BadRequest(errorResponse);
            }
        }

        [HttpPost("update-book")]
        public async Task<IActionResult> UpdateBook([FromBody] UpdateBookRequestDTO request)
        {
            try
            {
                // Gọi service để cập nhật sách và nhận lại đối tượng sách sau khi cập nhật
                var updatedBook = await _bookService.UpdateBookAsync(request);

                // Trả về đối tượng sách dưới dạng JSON
                return Ok(updatedBook);
            }
            catch (Exception ex)
            {
                // Trả về phản hồi lỗi dưới dạng JSON với thông tin chi tiết hơn
                var errorResponse = new
                {
                    message = "Failed to update book",
                    details = ex.Message
                };
                return BadRequest(errorResponse);
            }
        }

        [HttpGet("get-by-id/{bookId}")]
        public IActionResult GetById(int bookId)
        {
            try
            {
                var bookDTO = _bookService.GetById(bookId);
                if (bookDTO == null)
                {
                    return Ok("Không có dữ liệu");
                }
                return Ok(bookDTO);
            }
            catch (Exception)
            {
                return BadRequest("Có lỗi xảy ra");
            }
        }
    }
}
