using ePrijevozSarajevo.Model;

namespace ePrijevozSarajevo.Services
{
    public interface IRecommenderService
    {
        public Task<IEnumerable<Route>> RecommendRoutesAsync(int userId, int numberOfRecommendations);
    }

}
