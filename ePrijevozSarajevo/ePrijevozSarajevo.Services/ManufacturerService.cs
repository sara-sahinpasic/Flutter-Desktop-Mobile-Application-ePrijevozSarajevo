using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;

namespace ePrijevozSarajevo.Services
{
    public class ManufacturerService : BaseCRUDService<Model.Manufacturer, ManufacturerSearchObject, Database.Manufacturer,
        ManufacturerInsertRequest, ManufacturerUpdateRequest>, IManufacturerService
    {
        public ManufacturerService(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
