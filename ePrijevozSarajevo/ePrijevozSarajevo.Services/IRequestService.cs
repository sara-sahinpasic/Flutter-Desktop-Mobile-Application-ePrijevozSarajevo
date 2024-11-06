using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;

namespace ePrijevozSarajevo.Services
{
    public interface IRequestService : ICRUDService<Model.Request, RequestSearchObject, RequestInsertRequest, RequestUpdateRequest>
    {
        public Task ApproveRequest(int requestId, DateTime expirationDate);
        public Task<bool> RejectRequest(int requestId, string rejectionReason);
    }
}
