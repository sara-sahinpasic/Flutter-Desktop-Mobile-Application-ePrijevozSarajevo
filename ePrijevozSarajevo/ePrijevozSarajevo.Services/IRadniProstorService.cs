using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;

namespace ePrijevozSarajevo.Services
{
    public interface IRadniProstorService : ICRUDService<Model.RadniProstor, RadniProstorSearchObject,
        RadniProstorUpsertRequest, RadniProstorUpsertRequest>
    {
    }
}
