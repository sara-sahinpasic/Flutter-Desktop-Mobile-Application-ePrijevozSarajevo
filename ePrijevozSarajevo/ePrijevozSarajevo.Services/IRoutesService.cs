using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;

namespace ePrijevozSarajevo.Services
{
    public interface IRoutesService
    {
        public List<Route> GetList();
        public Route Insert(RouteInsertRequest request);
        public Route Update(int id, RouteUpdateRequest request);
    }
}
