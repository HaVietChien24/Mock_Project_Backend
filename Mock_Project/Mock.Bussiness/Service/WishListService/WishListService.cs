using AutoMapper;
using Mock.Bussiness.DTO;
using Mock.Bussiness.Service.Base;
using Mock.Core.Models;
using Mock.Repository.UnitOfWork;

namespace Mock.Bussiness.Service.WishListService
{
    public class WishListService : BaseService<WishList>, IWishListService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public WishListService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public WishlistDTO GetDTOByUserId(int id)
        {
            var item = _unitOfWork.WishListRepository.GetByUserId(id);
            return _mapper.Map<WishlistDTO>(item);
        }

        public int AddBookToWishlist(int userId, int bookId)
        {
            var wishlist = _unitOfWork.WishListRepository.GetByUserId(userId);
            if (wishlist == null)
            {
                var newWishlist = new WishList() { UserId = userId };
                _unitOfWork.WishListRepository.Add(newWishlist);
                _unitOfWork.SaveChanges();
                wishlist = _unitOfWork.WishListRepository.GetByUserId(userId);

                var wishListDetail = new WishListDetails() { WishListId = wishlist.Id, BookId = bookId, Quantity = 1 };
                _unitOfWork.WishListDetailRepository.Add(wishListDetail);
            }
            else
            {
                var findDetails = wishlist.WishListDetails.Find(x => x.BookId == bookId);
                if (findDetails == null)
                {
                    var wishListDetail = new WishListDetails() { WishListId = wishlist.Id, BookId = bookId, Quantity = 1 };
                    _unitOfWork.WishListDetailRepository.Add(wishListDetail);
                }
                else
                {
                    findDetails.Quantity += 1;
                    _unitOfWork.WishListDetailRepository.Update(findDetails);
                }
            }
            return _unitOfWork.SaveChanges();
        }

        public int UpdateDetailQuantity(int detailsId, int quantity)
        {
            var detail = _unitOfWork.WishListDetailRepository.GetByID(detailsId);
            if (detail == null)
                throw new Exception("Not Found");
            detail.Quantity = quantity;
            _unitOfWork.WishListDetailRepository.Update(detail);
            return _unitOfWork.SaveChanges();
        }
    }
}
