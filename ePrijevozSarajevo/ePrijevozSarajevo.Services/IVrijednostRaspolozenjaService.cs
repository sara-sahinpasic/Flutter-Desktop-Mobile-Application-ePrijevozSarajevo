using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;

namespace ePrijevozSarajevo.Services
{
    public interface IVrijednostRaspolozenjaService
        :ICRUDService<Model.VrijednostRaspolozenja, VrijednostRaspolozenjaSearchObject,
            VrijednostRaspolozenjaUpsertRequest, VrijednostRaspolozenjaUpsertRequest>
    {
    }
}
