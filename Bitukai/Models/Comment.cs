using System;
using System.ComponentModel.DataAnnotations;

namespace Bitukai.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ComponentId { get; set; }
        public Component Component { get; set; }
        [Required] public string UserId { get; set; }
        public User User { get; set; }
    }
}
