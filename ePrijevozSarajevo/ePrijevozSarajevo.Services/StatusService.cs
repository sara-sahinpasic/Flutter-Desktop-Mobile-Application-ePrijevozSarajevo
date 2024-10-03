using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;

namespace ePrijevozSarajevo.Services
{
    public class StatusService : BaseCRUDService<Model.Status, StatusSearchObject, Database.Status, StatusInsertRequest, StatusUpdateRequest>, IStatusService
    {
        public StatusService(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
