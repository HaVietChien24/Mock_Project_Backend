using AutoMapper;
using Azure;
using Mock.Bussiness.DTO;
using Mock.Core.Models;
using Mock.Repository.ApiResult;
using Mock.Repository.UnitOfWork;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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


        public string CheckBorrowingStatus(int borrowingId)
        {
            var status = _unitOfWork.BorrowingRepository.CheckBorrowingStatus(borrowingId);
            return status.ToString();
        }
        public int CheckPenalty(int borrowingId)
        {
            var penalty=_unitOfWork.BorrowingRepository.CheckPenalty(borrowingId);
            return penalty;

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
            //var borrowingDTO = _mapper.Map<List<BorrowingDTO>>(query);
            var listBorrowingDTO= new List<BorrowingDTO>();
            foreach (var item in query) {
                var borrowingDTO = new BorrowingDTO()
                {
                    Id = item.Id,
                    BorrowingStatus = CheckBorrowingStatus(item.Id),
                    ActualPickUpDate = item.ActualPickUpDate,
                    ExpectedPickUpDate = item.ExpectedPickUpDate,
                    ExpectedReturnDate = item.ExpectedReturnDate,
                    PenaltyFine = CheckPenalty(item.Id),
                    RequestDate = item.RequestDate,
                    RequestStatus = item.RequestStatus,
                    TotalQuantity = CalculateTotalQuantity(item.Id),
                    UserId = item.UserId,
                    Username = item.User.Username ,
                    IsBookPickedUp=item.IsBookPickedUp == true?"Collected":"Not Pickup",
                    IsPickUpLate=(DateTime.Now > item.ExpectedPickUpDate && item.IsBookPickedUp==false)? "Over date" : "On time"
                };
                listBorrowingDTO.Add(borrowingDTO);
            }

            var result = PageList<BorrowingDTO>.CreatePage(listBorrowingDTO, page, pageSize);
            return result;
        }

        public PageList<BorrowingDetailDTO> GetAllBorrowingDetail(int borrowingId, int page, int pageSize)
        {
           var query= _unitOfWork.BorrowingRepository.GetBorrowingDetails(borrowingId);
            var borrowingDetailDTO = _mapper.Map<List<BorrowingDetailDTO>>(query);
            var result = PageList<BorrowingDetailDTO>.CreatePage(borrowingDetailDTO, page, pageSize);
            return result;
        }

        public APIResult<string> UpdateReturnedBook(int borrowingDetailId, int numberBookReturned)
        {
            var result = _unitOfWork.BorrowDetailRepository.UpdateReturnedBook(borrowingDetailId, numberBookReturned);
            _unitOfWork.SaveChanges(); // Lưu thay đổi vào database sau khi cập nhật
            return result;
        }
        public void UpdatePickup(int borrowingId)
        {
            _unitOfWork.BorrowingRepository.UpdatePickup(borrowingId);
            _unitOfWork.SaveChanges();
        }

        public int? CalculateTotalQuantity(int borrowingId)
        {
           var result= _unitOfWork.BorrowingRepository.CalculateTotalQuantity(borrowingId);
            return result;
        }

        public PageList<BorrowingDetailDTO> ViewListBookBorrowingUser(int userId,int page=1,int pageSize=5)
        {
            var query = _unitOfWork.BorrowDetailRepository.ViewListBookBorrowingUser(userId);
            var borrowingDetailDTO = _mapper.Map<List<BorrowingDetailDTO>>(query);
            var result = PageList<BorrowingDetailDTO>.CreatePage(borrowingDetailDTO, page, pageSize);
            return result;

        }
    }
}
