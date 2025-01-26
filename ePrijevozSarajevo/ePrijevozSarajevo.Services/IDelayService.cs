using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;

namespace ePrijevozSarajevo.Services
{
    public interface IDelayService : ICRUDService<Model.Delay, DelaySearchObject, DelayInsertRequest, 
        DelayUpdateRequest>
    {
    }
}
