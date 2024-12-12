using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ePrijevozSarajevo.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RouteController : BaseCRUDController<Model.Route, RouteSearchObject, RouteInsertRequest, RouteUpdateRequest>
    {
        public RouteController(IRouteService service) : base(service) { }

        [HttpDelete("{id}")]
        public override async Task Delete(int id)
        {
            await (_service as IRouteService).DeleteRouteWithIssuedTickets(id);
        }
        public override async Task<PagedResult<Model.Route>> GetList([FromQuery] RouteSearchObject searchObject)
        {
            var result = await base.GetList(searchObject);

            result.ResultList = result.ResultList.OrderByDescending(departure => departure.Departure).ToList();

            return result;
        }
        [HttpPost]
        public override async Task<Model.Route> Insert(RouteInsertRequest request)
        {
            return await (_service as IRouteService).InsertArrivalDeparture(request);
        }
        [HttpPut("{id}")]
        public override async Task<Model.Route> Update(int id, RouteUpdateRequest request)
        {
            return await (_service as IRouteService).UpdateArrivalDeparture(id, request);
        }
    }
}
