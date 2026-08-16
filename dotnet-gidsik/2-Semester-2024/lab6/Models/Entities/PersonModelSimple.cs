

namespace Lab6.Models
{
    public class PersonModelSimple
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Birthday { get; set; } = DateTime.MinValue;
    }
}
