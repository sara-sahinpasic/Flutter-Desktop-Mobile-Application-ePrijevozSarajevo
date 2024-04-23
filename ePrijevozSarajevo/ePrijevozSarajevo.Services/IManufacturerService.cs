using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;

namespace ePrijevozSarajevo.Services
{
    public interface IManufacturerService : ICRUDService<Model.Manufacturer, ManufacturerSearchObject, ManufacturerUpsertRequest, ManufacturerUpsertRequest>
    {
    }
}
