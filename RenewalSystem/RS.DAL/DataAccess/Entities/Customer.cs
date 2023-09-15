using RS.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace RS.DAL.DataAccess.Entities
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; } 
        public string? MiddleName { get; set; } 
        public string LastName { get; set; } 
        public string Email { get; set; }
        public string Gender { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual IEnumerable<Subscription> Subscriptions { get; set; }
    }
}
