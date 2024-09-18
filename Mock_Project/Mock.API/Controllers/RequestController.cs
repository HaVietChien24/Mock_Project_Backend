using Microsoft.AspNetCore.Mvc;
using Mock.Bussiness.Service.RequestService;

namespace Mock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;
        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpGet("get-all-by-user-id/{userId}")]
        public IActionResult GetAllByUserId(int userId)
        {
            try
            {
                var list = _requestService.GetAllByUserId(userId);
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
