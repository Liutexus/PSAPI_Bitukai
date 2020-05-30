using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Bitukai.Models
{
    public class User : IdentityUser
    {
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public IList<UserFavoriteComponent> FavoriteComponents { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}