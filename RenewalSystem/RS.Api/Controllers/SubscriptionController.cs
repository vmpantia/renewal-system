using Microsoft.AspNetCore.Mvc;
using RS.BAL.Models;
using RS.BAL.Services;

namespace RS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly SubscriptionService _subscription;
        public SubscriptionController(SubscriptionService subscription)
        {
            _subscription = subscription;   
        }

        [HttpGet]
        public IActionResult GetOne()
        {
            var result = _subscription.GetAll<SubscriptionDto>();
            return Ok(result);
        }

        [HttpGet("{subscriptionId}")]
        public IActionResult GetOne(Guid subscriptionId)
        {
            var result = _subscription.GetOne<SubscriptionDto>(data => data.Id == subscriptionId);
            return Ok(result);
        }
    }
}
