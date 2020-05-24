using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Bitukai.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public float TotalPrice { get; set; }
        public int UserId { get; set; }
        public IdentityUser User { get; set; }
        public IList<ComponentCart> ComponentCarts { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }

    }
}
