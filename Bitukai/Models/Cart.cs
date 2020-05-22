using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Bitukai.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public IdentityUser User { get; set; }
        public float TotalPrice { get; set; }
        public IList<ComponentCart> ComponentCarts { get; set; }
        public Order Order { get; set; }


    }
}
