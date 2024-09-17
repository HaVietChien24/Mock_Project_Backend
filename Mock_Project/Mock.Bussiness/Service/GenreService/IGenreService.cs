using Mock.Bussiness.DTO;
using Mock.Bussiness.Service.Base;
using Mock.Core.Models;

namespace Mock.Bussiness.Service.GenreService
{
    public interface IGenreService : IBaseService<Genre>
    {
        List<GenreDTO> GetAllDTO();
    }
}
