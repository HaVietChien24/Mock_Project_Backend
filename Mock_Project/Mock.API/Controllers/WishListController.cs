using Microsoft.AspNetCore.Mvc;
using Mock.Bussiness.DTO;
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

        [HttpPost("add-book-to-wish-list")]
        public IActionResult AddBookToWishlist([FromBody] AddWishListDTO dto)
        {
            try
            {
                var result = _wishListService.AddBookToWishlist(dto.UserId, dto.BookId);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Có lỗi xảy ra");
            }
        }

        [HttpPut("update-wishlist-detail-quantity")]
        public IActionResult UpdateDetailQuantity([FromBody] UpdateWishlistDetailDTO dto)
        {
            try
            {
                var result = _wishListService.UpdateDetailQuantity(dto.DetailsId, dto.Quantity);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Có lỗi xảy ra");
            }
        }
    }
}
