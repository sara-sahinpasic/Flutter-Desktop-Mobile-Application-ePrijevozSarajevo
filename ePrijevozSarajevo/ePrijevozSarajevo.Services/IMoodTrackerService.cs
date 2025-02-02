using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;

namespace ePrijevozSarajevo.Services
{
    public interface IMoodTrackerService
        : ICRUDService<Model.MoodTracker30012025, MoodTracker30012025SearchObject,
            MoodTracker30012025UpsertRequest, MoodTracker30012025UpsertRequest>
    {
        public  Task<CountRaspolozenja> GetCountRaspolozenja();
    }
}
