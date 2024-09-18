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
    }
}
