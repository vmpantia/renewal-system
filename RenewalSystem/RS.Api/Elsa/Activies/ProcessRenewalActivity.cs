using Elsa.Activities.ControlFlow;
using Elsa.ActivityResults;
using Elsa.Services;
using Elsa.Services.Models;
using RS.BAL.Models;
using RS.BAL.Services;

namespace RS.Api.Elsa.Activies
{
    public class ProcessRenewalActivity : Activity
    {
        private readonly SubscriptionService _subscription;
        public ProcessRenewalActivity(SubscriptionService subscription)
        {
            _subscription = subscription;
        }

        protected override IActivityExecutionResult OnExecute(ActivityExecutionContext context)
        {
            var subscription = context.ForEachScope<SubscriptionDto>().CurrentValue!;
            
            // Put action to context variable
            context.SetVariable("action", new
            {
                data = subscription,
                action = ""
            });

            return Done();
        }

        private void ProcessRenewal(SubscriptionDto subscription)
        {
            DateTime currentDate = DateTime.Now.Date;
            var daysRemaining = (subscription.ExpirationDate - currentDate).Days;
            switch(daysRemaining)
            {
                case 60:
                    {

                        break;
                    }
            }
        }
    }
}
