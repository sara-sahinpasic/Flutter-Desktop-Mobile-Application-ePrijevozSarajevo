using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;

namespace ePrijevozSarajevo.Services
{
    public interface IStatusRezervacijeService : ICRUDService<Model.StatusRezervacije,
        StatusRezervacijeSearchObject, StatusRezervacijeUpsertRequest,
        StatusRezervacijeUpsertRequest>
    {
    }
}
