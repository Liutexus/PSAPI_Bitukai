using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bitukai.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public float TotalPrice { get; set; }
        public IList<ComponentCart> ComponentCarts { get; set; }
        public Order Order { get; set; }


    }
}
