namespace GameShop.Models.Entities
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; }

        public virtual IEnumerable<Game> Games { get; set; }

        //public virtual Game Game { get; set; }
    }
}
