using System.Collections.Generic;

namespace Bitukai.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public float TotalPrice { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public IList<ComponentCart> ComponentCarts { get; set; }
        public int? OrderId { get; set; }
        public Order Order { get; set; }

    }
}
