using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;

namespace ePrijevozSarajevo.Services
{
    public class RadniProstorService : BaseCRUDService<Model.RadniProstor, RadniProstorSearchObject,
        Database.RadniProstor, RadniProstorUpsertRequest, RadniProstorUpsertRequest>,
        IRadniProstorService
    {
        public RadniProstorService(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
