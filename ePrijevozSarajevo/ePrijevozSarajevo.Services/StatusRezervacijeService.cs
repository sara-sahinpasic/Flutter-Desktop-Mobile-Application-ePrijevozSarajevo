using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;

namespace ePrijevozSarajevo.Services
{
    public class StatusRezervacijeService : BaseCRUDService<Model.StatusRezervacije,
        StatusRezervacijeSearchObject, Database.StatusRezervacije, StatusRezervacijeUpsertRequest,
        StatusRezervacijeUpsertRequest>, IStatusRezervacijeService
    {
        public StatusRezervacijeService(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
