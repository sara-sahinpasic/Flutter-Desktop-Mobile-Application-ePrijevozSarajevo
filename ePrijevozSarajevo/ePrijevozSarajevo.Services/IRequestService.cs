using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;

namespace ePrijevozSarajevo.Services
{
    public interface IRequestService : ICRUDService<Model.Request, RequestSearchObject, RequestInsertRequest, RequestUpdateRequest>
    {
        
    }
}
