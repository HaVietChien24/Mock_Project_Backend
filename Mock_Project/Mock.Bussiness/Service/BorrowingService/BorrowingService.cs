using AutoMapper;
using Mock.Bussiness.DTO;
using Mock.Core.Models;
using Mock.Repository.UnitOfWork;

namespace Mock.Bussiness.Service.BorrowingService
{
    public class BorrowingService : IBorrowingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BorrowingService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public PageList<BorrowingDTO> GetAllBorrowing(int page, int pageSize, string? userName, string? borrowStatus)
        {
            var query = _unitOfWork.BorrowingRepository.GetAllBorrowings().AsQueryable();
            if (!string.IsNullOrEmpty(userName))
            {
                query = query.Where(c => c.User.Username.ToLower().Trim().Contains(userName.ToLower().Trim()));

            }
            if (!string.IsNullOrEmpty(borrowStatus))
            {
                query = query.Where(c => c.BorrowingStatus.ToLower().Trim().Contains(borrowStatus.ToLower().Trim()));
            }
            var borrowingDTO = _mapper.Map<List<BorrowingDTO>>(query);

            var result = PageList<BorrowingDTO>.CreatePage(borrowingDTO, page, pageSize);
            return result;
        }
        public string UpdateReturnedBook(int borrowingDetailId, int numberBookReturned)
        {
           
            var result = _unitOfWork.BorrowDetailRepository.UpdateReturnedBook(borrowingDetailId, numberBookReturned);
            return result;
        }
    }
}
