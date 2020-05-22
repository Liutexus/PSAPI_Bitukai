using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Bitukai.Models.Enums;

namespace Bitukai.Models
{
    public class Order
    {
        public int Id { get; set; }
        public OrderStatus OrderStatus { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

    }
}
