using ePrijevozSarajevo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ePrijevozSarajevo.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RecommendationController : ControllerBase
    {
        private readonly IRecommenderService _recommenderService;

        public RecommendationController(IRecommenderService recommenderService)
        {
            _recommenderService = recommenderService;
        }


        [AllowAnonymous]
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetRecommendations(int userId, int maxRecommendations = 5)
        {
            var recommendations = await _recommenderService.RecommendRoutesAsync(userId, maxRecommendations);
            return Ok(recommendations);
        }

    }
}

