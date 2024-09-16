using Microsoft.AspNetCore.Mvc;
using Mock.Bussiness.Service.GenreService;

namespace Mock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet("get-all-genres")]
        public IActionResult GetAll()
        {
            try
            {
                var list = _genreService.GetAllDTO();
                if (list.Count==0)
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
