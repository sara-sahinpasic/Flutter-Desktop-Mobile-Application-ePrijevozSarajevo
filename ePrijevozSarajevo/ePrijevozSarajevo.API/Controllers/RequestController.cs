using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ePrijevozSarajevo.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RequestController : BaseCRUDController<Model.Request,
        RequestSearchObject, RequestInsertRequest, RequestUpdateRequest>
    {
        public RequestController(IRequestService service) : base(service) { }

        [HttpPut("Approve/{requestId}")]
        public async Task<IActionResult> ApproveRequest(int requestId, RequestUpdateRequest requestRequest)
        {
            await (_service as IRequestService).ApproveRequest(requestId, requestRequest.ExpirationDate);
            return Ok("Uspješno odobren zahtjev.");
        }

        [HttpPut("Reject/{requestId}")]
        public async Task<IActionResult> RejectRequest(int requestId, RequestUpdateRequest requestRequest)
        {
            bool isRejectedSuccessfully = await (_service as IRequestService).RejectRequest(requestId, requestRequest.RejectionReason);

            if (!isRejectedSuccessfully)
            {
                return BadRequest("Zahtjev nije aktivan");
            }
            return Ok("Uspješno odbijen zahtjev.");
        }
    }
}

