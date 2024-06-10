using System.ComponentModel.DataAnnotations;

namespace GameShop.Models.Entities
{
    public class Game:BaseEntity
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }


    }
}
