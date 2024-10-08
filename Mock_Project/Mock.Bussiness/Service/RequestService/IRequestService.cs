﻿using Mock.Bussiness.DTO;
using Mock.Bussiness.Service.Base;
using Mock.Core.Models;

namespace Mock.Bussiness.Service.RequestService
{
    public interface IRequestService : IBaseService<Borrowing>
    {
        int CancelRequest(int requestId);
        int CreateRequest(RequestDTO requestDTO);
        List<RequestDTO> GetAllByUserId(int id);


        List<RequestByAllUserDTO> GetAllRequestByAllUsers();

        // Các phương thức khác...
        string UpdateRequestStatus(int borrowingId, string action);  // Cập nhật trạng thái yêu cầu
    }
}
