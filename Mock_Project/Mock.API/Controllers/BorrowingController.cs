using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mock.Bussiness.RequestBody;
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
        public IActionResult UpdateReturnedBook(ReturnedBook returnbooked)
        {
            var result = _service.UpdateReturnedBook(returnbooked.borrowingDetailId, returnbooked.numberBookReturned);

            if (result.Success) 
            {
                return Ok(result); 
            }

            return BadRequest(result); 
        }
        [HttpPut]
        public IActionResult ConfirmPickedUp(int borrowingId)
        {
            try
            {
                _service.UpdatePickup(borrowingId);

            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
            return Ok(new
            {
                Message = "Xác nhận đã trả"
            });
        }

        [HttpGet]
        public IActionResult GetBorrowingDetail(int borrowingId, int page = 1, int pageSize = 5)
        {
            var result = _service.GetAllBorrowingDetail(borrowingId,page, pageSize);
            return Ok(result);
        }
    }
}
