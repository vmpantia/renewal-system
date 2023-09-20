using Elsa.ActivityResults;
using Elsa.Services;
using Elsa.Services.Models;
using RS.BAL.Models;
using RS.BAL.Services;

namespace RS.Api.Elsa.Activies
{
    public class GetAllDataForRenewalActivity : Activity
    {
        private readonly SubscriptionService _subscription;
        private readonly DefinitionService _definition;
        public GetAllDataForRenewalActivity(SubscriptionService subscription, DefinitionService definition)
        {
            _subscription = subscription;
            _definition = definition;
        }

        protected override IActivityExecutionResult OnExecute(ActivityExecutionContext context)
        {
            DateTime currentDate = DateTime.Now.Date;
            DateTime expirationDateThreshold = currentDate.AddDays(60);

            // Get subscription hat will expire within the next 60 days in the database
            var subscriptions = _subscription.GetAll<SubscriptionDto>(data => data.ExpirationDate >= currentDate && 
                                                                              data.ExpirationDate <= expirationDateThreshold);

            // Put subscriptions to context variable
            context.SetVariable("subscriptions", subscriptions);

            return Done();
        }
    }
}
