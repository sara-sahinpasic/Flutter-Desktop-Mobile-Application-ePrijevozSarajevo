using ePrijevozSarajevo.Model;

namespace ePrijevozSarajevo.Services
{
    public class RequestService : IRequestsService
    {
        public List<Request> RequestsList = new List<Request>()
        {
            new Request()
            {
                RequestId = 1,
                Active = true,
                Approved = true,
                DocumentLink = "test"
            }
        };
        public List<Request> GetList()
        {
            return RequestsList;
        }               
    }
};
