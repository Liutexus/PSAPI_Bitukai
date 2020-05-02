using System.Collections.Generic;

namespace Bitukai.Models
{
    public class Component
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public IEnumerable<Component> Alternatives { get; set; }
    }
}
