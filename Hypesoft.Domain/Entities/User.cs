using Hypesoft.Domain.Common;

namespace Hypesoft.Domain.Entities
{
    public class User : BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
