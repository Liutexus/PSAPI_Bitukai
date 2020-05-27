using System.Collections.Generic;

namespace Bitukai.Models
{
    public class Component
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string AlternativeIds { get; set; }
        public IEnumerable<Component> Alternatives { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
<<<<<<< HEAD
        public ICollection<Comment> Comments { get; set; }
=======
        public IList<ComponentCart> ComponentCarts { get; set; }
>>>>>>> 1d8d6239bbb09280d05e2f47fa2dbcf953247e0b
    }
}
