using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;

namespace ePrijevozSarajevo.Services
{
    public interface IMalfunctionService :ICRUDService
        <Model.Malfunction, MalfunctionSearchObject, MalfunctionInsertRequest,
        MalfunctionUpdateRequest>
    {
    }
}
