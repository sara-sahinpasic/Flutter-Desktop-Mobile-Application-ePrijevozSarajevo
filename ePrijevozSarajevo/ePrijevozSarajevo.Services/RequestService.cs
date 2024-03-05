using ePrijevozSarajevo.Model;

namespace ePrijevozSarajevo.Services
{
    public class RequestService : IRequestsService
    {
        public List<Requests> RequestsList = new List<Requests>()
        {
            new Requests()
            {
                RequestId = 1,
                Active = true,
                Approved = true,
                DocumentLink = "test"
            }
        };
        public List<Requests> GetRequestsList()
        {
            return RequestsList;
        }
    }
};
