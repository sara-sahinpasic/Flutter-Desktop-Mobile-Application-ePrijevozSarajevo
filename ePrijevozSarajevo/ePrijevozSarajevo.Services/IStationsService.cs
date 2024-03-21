using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;

namespace ePrijevozSarajevo.Services
{
    public interface IStationsService
    {
        public List<Station> GetList();
        public Station Insert(StationInsertRequest request);
        public Station Update(int id, StationUpdateRequest request);
    }
}
