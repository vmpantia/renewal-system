using Elsa.ActivityResults;
using Elsa.Services;
using Elsa.Services.Models;
using RS.BAL.Models;
using RS.BAL.Services;

namespace RS.Api.Elsa.Activies
{
    public class DataForRenewalActivity : Activity
    {
        private readonly SubscriptionService _subscription;
        public DataForRenewalActivity(SubscriptionService subscription)
        {
            _subscription = subscription;
        }

        protected override IActivityExecutionResult OnExecute(ActivityExecutionContext context)
        {
            // Get subscription needed for renewal in database
            var subscriptions = _subscription.GetAll<SubscriptionDto>();

            // Put subscriptions to context variable
            context.SetVariable("subscriptions", subscriptions);

            return Done();
        }
    }
}
