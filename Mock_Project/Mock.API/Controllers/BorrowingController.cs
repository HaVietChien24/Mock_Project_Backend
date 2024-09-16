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

        public IActionResult GetAllBorrowing(string? userName, string? borrowStatus,int page=1, int pageSize=1) {

          var result=  _service.GetAllBorrowing(page, pageSize, userName, borrowStatus);
            return Ok(result);
        }
    }
}
