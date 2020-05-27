using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bitukai.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ComponentId { get; set; }
        public Component Component { get; set; }

    }
}
