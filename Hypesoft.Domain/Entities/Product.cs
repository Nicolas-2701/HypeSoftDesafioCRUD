using Hypesoft.Domain.Common;

namespace Hypesoft.Domain.Entities
{
    public class Product : BaseModel
    {
        public required string name { get; set; }
        public string? desc { get; set; }
        public required string category { get; set; }
        public int price { get; set; }
        public int amout { get; set; }
    }
}
