using RS.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace RS.DAL.DataAccess.Entities
{
    public class Subscription
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public Status Status { get; set; }
        public DateTime? RenewDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
        public virtual IEnumerable<Offer> Offers { get; set; }
    }
}
