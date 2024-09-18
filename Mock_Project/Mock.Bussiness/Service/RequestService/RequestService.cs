using AutoMapper;
using Mock.Bussiness.DTO;
using Mock.Bussiness.Service.Base;
using Mock.Core.Models;
using Mock.Repository.UnitOfWork;

namespace Mock.Bussiness.Service.RequestService
{
    public class RequestService : BaseService<Borrowing>, IRequestService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RequestService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<RequestDTO> GetAllByUserId(int id)
        {
            var list = _unitOfWork.BorrowingRepository.GetAllRequestsByUserId(id);
            return _mapper.Map<List<RequestDTO>>(list);
        }
        public int CancelRequest(int requestId)
        {
            var request = _unitOfWork.BorrowingRepository.GetByID(requestId);
            var requestDetails = _unitOfWork.BorrowDetailRepository.getByRequestId(requestId);
            foreach (var item in requestDetails)
            {
                _unitOfWork.BorrowDetailRepository.Delete(item);
            }
            _unitOfWork.BorrowingRepository.Delete(request);
            return _unitOfWork.SaveChanges();
        }

        public int CreateRequest(RequestDTO requestDTO)
        {
            requestDTO.RequestDate = DateTime.Now;
            requestDTO.RequestStatus = "Pending";

            var borrowing = _mapper.Map<Borrowing>(requestDTO);
            _unitOfWork.BorrowingRepository.Add(borrowing);
            _unitOfWork.SaveChanges();

            var wishlist = _unitOfWork.WishListRepository.GetByUserId(requestDTO.UserId);
            var wishlistDetails = wishlist.WishListDetails;

            var borrowingDetails = _mapper.Map<List<BorrowingDetails>>(wishlistDetails);

            foreach (var item in borrowingDetails)
            {
                item.Id = 0;
                item.BorrowingId = borrowing.Id;
                _unitOfWork.BorrowDetailRepository.Add(item);
            }
            _unitOfWork.SaveChanges();

            foreach (var item in wishlistDetails)
            {
                _unitOfWork.WishListDetailRepository.Delete(item);
            }
            _unitOfWork.WishListRepository.Delete(wishlist);

            return _unitOfWork.SaveChanges();

        }
    }
}
