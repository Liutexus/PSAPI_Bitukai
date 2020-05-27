using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Bitukai.Models
{
    public class UserFavoriteComponent
    {
        [Key]
        public string UserId { get; set; }
        public User User { get; set; }
        
        [Key]
        public int ComponentId { get; set; }
        public Component Component { get; set; }
    }
}
