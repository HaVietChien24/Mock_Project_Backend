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
    }
}
