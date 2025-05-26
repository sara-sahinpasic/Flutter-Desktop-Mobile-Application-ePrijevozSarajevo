using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;

namespace ePrijevozSarajevo.Services
{
    public interface IRezervacijeProstoraService : ICRUDService<Model.RezervacijaProstora20022025,
        RezervacijaProstora20022025SearchObject, RezervacijaProstora20022025UpsertRequest,
        RezervacijaProstora20022025UpsertRequest>
    {
        public Task<List<TotalDto>> TotalList(RezervacijaProstora20022025SearchObject search); // labela ispod tabele

    }
}
