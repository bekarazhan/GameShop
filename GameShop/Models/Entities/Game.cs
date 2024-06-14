using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameShop.Models.Entities
{
    public class Game:BaseEntity
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public string? Description { get; set; } = string.Empty;

    }
}
