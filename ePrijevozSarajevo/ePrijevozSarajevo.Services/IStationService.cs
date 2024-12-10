using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;

namespace ePrijevozSarajevo.Services
{
    public interface IStationService : ICRUDService<Model.Station, StationSearchObject, StationInsertRequest, StationUpdateRequest> { }
}
