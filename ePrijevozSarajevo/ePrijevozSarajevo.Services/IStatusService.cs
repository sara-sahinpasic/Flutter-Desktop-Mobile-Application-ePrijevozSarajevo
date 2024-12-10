using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;

namespace ePrijevozSarajevo.Services
{
    public interface IStatusService : ICRUDService<Model.Status, StatusSearchObject, StatusInsertRequest, StatusUpdateRequest> { }
}
