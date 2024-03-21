using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;

namespace ePrijevozSarajevo.Services
{
    public interface IRequestsService
    {
        public List<Request> GetList();
        //public Request Insert(RequestInsertRequest request);
        //public Request Update(int id, RequestUpdateRequest request);
    }
}
