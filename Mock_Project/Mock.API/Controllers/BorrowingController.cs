using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mock.Bussiness.Service.BorrowingService;
using System.Runtime.InteropServices;

namespace Mock.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BorrowingController : ControllerBase
    {
        private readonly IBorrowingService _service;
        public BorrowingController(IBorrowingService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult GetAllBorrowing(string? userName, string? borrowStatus,int page=1, int pageSize=5) {

          var result=  _service.GetAllBorrowing(page, pageSize, userName, borrowStatus);
            return Ok(result);
        }
        [HttpPut]
        public IActionResult UpdateReturnedBook(int borrowingDetailId, int numberBookReturned)
        {
            var result = _service.UpdateReturnedBook(borrowingDetailId, numberBookReturned);
            if (result == "Cập nhật số lượng sách trả thành công." || result == "Đã trả xong tất cả sách.")
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet]
        public IActionResult GetBorrowingDetail(int borrowingId, int page = 1, int pageSize = 5)
        {
            var result = _service.GetAllBorrowingDetail(borrowingId,page, pageSize);
            return Ok(result);
        }
    }
}
