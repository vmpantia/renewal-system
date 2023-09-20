using Elsa.Activities.ControlFlow;
using Elsa.Activities.Email;
using Elsa.Activities.Temporal;
using Elsa.Builders;
using Elsa.Services.Models;
using NodaTime;
using RS.Api.Elsa.Activies;
using RS.BAL.Models;

namespace RS.Api.Elsa.Workflows
{
    public class RenewalNotificationWorkflow : IWorkflow
    {
        private readonly IConfiguration _configuration;
        public RenewalNotificationWorkflow(IConfiguration configuration) => _configuration = configuration;

        public void Build(IWorkflowBuilder builder)
        {
            builder.Timer(Duration.FromSeconds(10))
                   .Then<GetAllDataForRenewalActivity>()
                   .ForEach(context => context.GetVariable<ICollection<SubscriptionDto>>("subscriptions")!,
                            interate => interate.SendEmail(activity => SetupEmail(activity)));
        }

        private void SetupEmail(ISetupActivity<SendEmail> activity)
        {
            activity.WithSender(_configuration["Elsa:Smtp:Username"]!)
                    .WithRecipient(context => GetRecipient(context))
                    .WithSubject(context => GetSubject(context))
                    .WithBody(context => GetBody(context));
        }

        private string GetRecipient(ActivityExecutionContext context)
        {
            var subscription = context.ForEachScope<SubscriptionDto>().CurrentValue!;
            return subscription.CustomerEmail;
        }

        private string GetSubject(ActivityExecutionContext context)
        {
            var subscription = context.ForEachScope<SubscriptionDto>().CurrentValue!;
            return $"[Renewal] Your subscription will expire on {subscription.ExpirationDate.ToString("yyyy-MM-dd")}";
        }

        private string GetBody(ActivityExecutionContext context)
        {
            var subscription = context.ForEachScope<SubscriptionDto>().CurrentValue!;
            return $"[Renewal] Your subscription will expire on {subscription.ExpirationDate.ToString("yyyy-MM-dd")}";
        }
    }
}
