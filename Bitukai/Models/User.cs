using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Bitukai.Models
{
    public class User : IdentityUser
    {
        public int? CartId { get; set; }
        public Cart Cart { get; set; }
        public IList<UserFavoriteComponent> FavoriteComponents { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}