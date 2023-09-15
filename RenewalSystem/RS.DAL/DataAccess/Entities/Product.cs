using RS.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace RS.DAL.DataAccess.Entities
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual IEnumerable<Subscription> Subscriptions { get; set; }
    }
}
