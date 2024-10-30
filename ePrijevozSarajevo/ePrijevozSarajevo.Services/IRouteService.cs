using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;

namespace ePrijevozSarajevo.Services
{
    public interface IRouteService : ICRUDService<Model.Route, RouteSearchObject, RouteInsertRequest, RouteUpdateRequest>
    {
        public Task DeleteRouteWithIssuedTickets(int id);
    }
}
