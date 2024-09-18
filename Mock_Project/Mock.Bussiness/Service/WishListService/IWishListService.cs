using Mock.Bussiness.DTO;
using Mock.Bussiness.Service.Base;
using Mock.Core.Models;

namespace Mock.Bussiness.Service.WishListService
{
    public interface IWishListService : IBaseService<WishList>
    {
        int AddBookToWishlist(int userId, int bookId);
        WishlistDTO GetDTOByUserId(int id);
    }
}
