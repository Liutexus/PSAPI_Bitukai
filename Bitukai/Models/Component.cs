﻿using System.Collections.Generic;

namespace Bitukai.Models
{
    public class Component
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string AlternativeIds { get; set; }
        public decimal Price { get; set; }
        public IEnumerable<Component> Alternatives { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public IList<ComponentCart> ComponentCarts { get; set; }
        public IList<UserFavoriteComponent> FavoriteComponents { get; set; }
    }
}
