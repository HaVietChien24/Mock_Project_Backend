using Mock.Bussiness.DTO;
using Mock.Bussiness.Service.Base;
using Mock.Core.Models;

namespace Mock.Bussiness.Service.RequestService
{
    public interface IRequestService : IBaseService<Borrowing>
    {
        int CancelRequest(int requestId);
        List<RequestDTO> GetAllByUserId(int id);
    }
}
