using RS.Common.Models;

namespace RS.DAL.DataAccess.Entities
{
    public class Offer
    {
        public Guid Id { get; set; }
        public Guid SubscriptionId { get; set; }
        public OfferType Type { get; set; }
        public OfferStatus Status { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Subscription Subscription { get; set; }
    }
}
