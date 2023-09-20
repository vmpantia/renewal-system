using Microsoft.EntityFrameworkCore;
using RS.Common.Models;

namespace RS.DAL.DataAccess.Entities
{
    [PrimaryKey(nameof(Section), nameof(Key))]
    public class Definition
    {
        public string Section { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string? Description { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
