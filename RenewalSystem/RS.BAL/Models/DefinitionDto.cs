
namespace RS.BAL.Models
{
    public class DefinitionDto
    {
        public string Section { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string? Description { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
