using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bitukai.Models
{
    public class ComponentCart
    {
        [Key]
        public int ComponentId { get; set; }
        public Component Component { get; set; }

        [Key]
        public int CartId { get; set; }
        public Cart Cart { get; set; }

    }
}
