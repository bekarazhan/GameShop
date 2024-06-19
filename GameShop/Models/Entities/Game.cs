using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameShop.Models.Entities
{
    public class Game:BaseEntity
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public string? Description { get; set; } = string.Empty;
        public virtual int? GenreId { get; set; }
        public virtual Genre Genre { get; set; }

        //public virtual IEnumerable<Platform> Platfroms { get; set; }

        
    }

    //public class Platform:BaseEntity {
    
    //    public string Name { get; set; }
    //    public virtual IEnumerable<Game> Games { get; set; }
    //}
}
