using Microsoft.AspNetCore.Mvc;
using Mock.Bussiness.Service.WishListService;

namespace Mock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishListController : ControllerBase
    {
        private readonly IWishListService _wishListService;
        public WishListController(IWishListService wishListService)
        {
            _wishListService = wishListService;
        }

        [HttpGet("get-wish-list-by-user-id")]
        public IActionResult GetByUserId([FromQuery] int id)
        {
            try
            {
                var item = _wishListService.GetDTOByUserId(id);
                if (item == null)
                {
                    return Ok("Không có dữ liệu");
                }
                return Ok(item);
            }
            catch (Exception)
            {
                return BadRequest("Có lỗi xảy ra");
            }
        }
    }
}
