using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;

namespace ePrijevozSarajevo.Services
{
    public class VrijednostRaspolozenjaService : BaseCRUDService<Model.VrijednostRaspolozenja,
        VrijednostRaspolozenjaSearchObject, Database.VrijednostRaspolozenja,
        VrijednostRaspolozenjaUpsertRequest, VrijednostRaspolozenjaUpsertRequest>
        , IVrijednostRaspolozenjaService
    {
        public VrijednostRaspolozenjaService(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
